/* Scheduler.cs
 * Author: Josh Weese and Rod Howell
 * 
 * Edited By: Ian Flores
 */
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using Ksu.Cis300.TaskScheduler;
using Ksu.Cis300.Graphs;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.CodeDom;

namespace Ksu.Cis300.Scheduler
{
    /// <summary>
    /// Contains the methods for reading, computing, and writing a schedule.
    /// </summary>
    public class Scheduler
    {
        /// <summary>
        /// the most tasks scheduled for any worker
        /// </summary>
        public int MostScheduledTasks { get; private set; }
        /// <summary>
        /// the average number of tasks scheduled for all workers
        /// </summary>
        public double AverageScheduledTasks { get; private set; }
        /// <summary>
        /// the number of workers left unscheduled
        /// </summary>
        public int WorkersUnscheduled { get; private set; }

        /// <summary>
        /// The maximum number of workers
        /// </summary>
        private const int _maxNumWorkers = 100;

        /// <summary>
        /// The maximum number of tasks
        /// </summary>
        private const int _maxNumTasks = 50;

        /// <summary>
        /// An array of nodes that replaces the worker queue
        /// </summary>
        private Node[] _workers;

        /// <summary>
        /// The tasks
        /// </summary>
        private Node[] _tasks;

        /// <summary>
        /// Maps a worker's name to a node with the same name
        /// </summary>
        private Dictionary<string, Node> _nameAndNode;

        /// <summary>
        /// Maps a task to a node with the same name
        /// </summary>
        private Dictionary<string, Node> _taskAndNode;

        /// <summary>
        /// Will be used to sort the worker or task array
        /// </summary>
        private TimesScheduledComparer _comparer;

        /// <summary>
        /// The biparte graph whose edges connect workers with the tasks they are qualified for
        /// </summary>
        private DirectedGraph<Node, bool> _biparteGraph;

        /// <summary>
        /// gives the least number of times any worker has been scheduled
        /// </summary>
        public int LeastTimesScheduled { get; private set; }

        /// <summary>
        /// gives the greatest number of times any worker has been scheduled
        /// </summary>
        public int MostTimesScheduled { get; private set; }

        /// <summary>
        /// gives the least number of times any task has been assigned a worker
        /// </summary>
        public int leastTimesAssigned { get; private set; }

        /// <summary>
        /// The task names
        /// </summary>
        public IEnumerable<string> TaskNames
        {
            get
            {
                foreach (Node task in _tasks)
                {
                    yield return task.Name;
                }
            }
        }

        /// <summary>
        /// The worker names
        /// </summary>
        public IEnumerable<string> WorkerNames
        {
            get
            {
                foreach (Node worker in _workers)
                {
                    yield return worker.Name;
                }
            }
        }

        /// <summary>
        /// The constructor for the class that reads in task and worker information into the scheduler
        /// </summary>
        /// <param name="dataFileName">the input file path</param>
        public Scheduler(string dataFileName)
        {
            ReadInput(dataFileName);
        }

        /// <summary>
        /// adds a worker to the graph
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="fields"></param>
        private void AddWorkerToGraph(Node worker, string[] fields)
        {
            _biparteGraph.AddNode(worker);
            string task;
            for (int i = 0; i < fields.Length; i++)
            {
                task = fields[i + 1];
                if(task.Length > 0)
                {
                    _biparteGraph.AddEdge(worker, _tasks[i], true);
                }
            }
        }

        /// <summary>
        /// Gets a list of the workers qualified to complete a task
        /// </summary>
        /// <param name="taskName">The task to check for</param>
        /// <returns>The list of workers</returns>
        public List<string> GetQualifiedWorkers(string taskName)
        {
            Node taskNode = _taskAndNode[taskName];
            List<string> qualifiedWorkers = new List<string>();
            foreach(Node worker in _workers)
            {
                _biparteGraph.TryGetEdge(taskNode, worker, out bool isConnected);
                if(isConnected)
                {
                    qualifiedWorkers.Add(worker.Name);
                }
            }
            return qualifiedWorkers;
        }


        /// <summary>
        /// Find the path from a given node 
        /// </summary>
        /// <param name="start">The node</param>
        /// <param name="matching">the current matching</param>
        /// <param name="assignments">the fixed assignments</param>
        /// <param name="end">The end of the path</param>
        /// <returns>The path taken</returns>
        private Dictionary<Node, Node> FindAugmentingPath(Node start, Dictionary<Node, Node> matching, Dictionary<Node, Node> assignments, out Node end)
        {
            Dictionary<Node, Node> path = new Dictionary<Node, Node>();
            Queue<Edge<Node, bool>> queue = new Queue<Edge<Node, bool>>();
            path.Add(start, start);
            foreach(Edge<Node, bool> edge in _biparteGraph.OutgoingEdges(start))
            {
                if(!assignments.ContainsKey(edge.Destination))
                {
                    queue.Enqueue(edge);
                }
            }

            while(queue.Count != 0)
            {
                Edge<Node, bool> currentEdge = queue.Dequeue();
                Node destination = currentEdge.Destination;
                if (!path.ContainsKey(destination))
                {
                    path.Add(destination, currentEdge.Source);
                    if (matching.TryGetValue(destination, out Node node))
                    {
                        path.Add(node, destination);
                        foreach (Edge<Node, bool> edge in _biparteGraph.OutgoingEdges(node))
                        {
                            if (!assignments.ContainsKey(edge.Destination))
                            {
                                queue.Enqueue(edge);
                            }
                        }
                    }
                    else
                    {
                        end = destination;
                        return path;
                    }
                }
            }
            end = null;
            return null;
        }

        
        /// <summary>
        /// Finds a matching
        /// </summary>
        /// <param name="source">The source set</param>
        /// <param name="destination">The destination set</param>
        /// <param name="assignments">The assignments</param>
        /// <returns>The matching</returns>
        private Dictionary<Node, Node> FindMatching(Node[] source, Node[] destination, Dictionary<Node, Node> assignments)
        {
            Dictionary<Node, Node> matching = new Dictionary<Node, Node>();
            Array.Sort(source, _comparer);
            foreach(KeyValuePair<Node, Node> entry in assignments)
            {
                matching.Add(entry.Key, entry.Value);
            }
            Node node;
            for(int i = 0; i < source.Length; i++)
            {
                node = source[i];
                if(matching.Count == source.Length || matching.Count == destination.Length)
                {
                    return matching;
                }
                else if(!assignments.TryGetValue(node, out Node value))
                {
                    Dictionary<Node, Node> path = FindAugmentingPath(node, matching, assignments, out Node end);
                    if(path != null)
                    {
                        matching.Add(node, source[i - 1]);
                    }
                }
            }
            return null;  //If there are problems look at this line
        }

        /// <summary>
        /// Gets a row of a schedule that is selected by the user
        /// </summary>
        /// <param name="row">The row</param>
        /// <returns>A dictionary whose keys are the worksers and tasks assigned in the DataRow</returns>
        private Dictionary<Node, Node> GetFixedAssginment(DataRow row)
        {
            Dictionary<Node, Node> assignments = new Dictionary<Node, Node>();
            foreach(DataColumn column in row.Table.Columns)
            {
                string taskName = column.ColumnName;
                object workerName = row[taskName];
                string name = (string)row[taskName];
                if(!(name == null))
                {
                    Node worker = _nameAndNode[name];
                    Node task = _taskAndNode[taskName];
                    assignments[worker] = task;
                    assignments[task] = worker;
                }
            }
            return assignments;
        }



        /// <summary>
        /// Reads the given input file and stores the data in the schedule worker queue and task array
        /// </summary>
        /// <param name="fn">The name of the file to read.</param>
        private void ReadInput(string fn)
        {
            _workers = new Node[_maxNumWorkers];
            using (StreamReader input = new StreamReader(fn))
            {
                string s = input.ReadLine();
                if (s == null)
                {
                    throw new IOException("Invalid File Format: The input file is empty.");
                }

                string[] fields = s.Split(',');
                if (fields.Length < 2)
                {
                    throw new IOException("Invalid File Format: The input file must contain at least one task.");
                }
                _tasks = new Node[_maxNumTasks];
                for (int i = 0; i < fields.Length; i++)
                {
                    Node task = new Node(fields[i + 1]);
                    _tasks[i] = task;
                    _biparteGraph.AddNode(task);
                    _taskAndNode.Add(task.Name, task);
                }
                int j = 0;
                while (!input.EndOfStream)
                {
                    s = input.ReadLine();
                    fields = s.Split(',');
                    if (fields.Length != _tasks.Length + 1)
                    {
                        throw new IOException("Invalid File Format: Not all lines have the same number of fields.");
                    }
                    Node worker = new Node(fields[0]);
                    _workers[j] = worker;
                    _biparteGraph.AddNode(worker);
                    for (int i = 1; i < fields.Length; i++)
                    {
                        if (fields[i] == "1")
                        {
                            _biparteGraph.AddEdge(worker, _tasks[i - 1], true);
                            _tasks[i - 1].TimesScheduled++;
                        }

                    }
                    _workers[j] = worker;
                    j++;
                }
            }
        }

        /// <summary>
        /// Returns the schedule input data (uncomputed) as a DataTable
        /// </summary>
        /// <returns>A data table of the raw schedule data</returns>
        public DataTable GetRawScheduleData()
        {
            DataTable data = new DataTable();
            int workerCount = _workers.Length;

            for (int i = 0; i < _tasks.Length; i++)
            {
                data.Columns.Add(_tasks[i].Name); //Not sure if using _tasks[i].Name was correct
            }

            for (int i = 0; i < workerCount; i++)
            {
                Node w = _workers[i];
                string[] row = new string[_tasks.Length + 1];
                row[0] = w.Name;
                for (int j = 1; j <= _tasks.Length; j++)
                {
                    List<string> list = GetQualifiedWorkers(_tasks[j].Name);
                    row[j] = list.Contains(w.Name) ? "X" : "";
                }
                data.Rows.Add(row);
            }
            return data;
        }

        /// <summary>
        /// Computes a schedule of the given length using the workers in the given WorkerQueue and the task names
        /// </summary>
        /// <param name="len">The length of the schedule</param>
        public void ComputeSchedule(decimal len, bool balanceCriterion, DataTable assignments)
        {
            bool uconstrainedSchedule;
            ResetStats();
            for (int i = 1; i <= len; i++)
            {
                Dictionary<Node, Node> fixedAssignments = GetFixedAssginment(assignments.Rows[i]);
                if(fixedAssignments.Count == _tasks.Length)
                {
                    uconstrainedSchedule = true;
                }
                else
                {
                    uconstrainedSchedule = false;
                }
                bool balancing = balanceCriterion;
                if (!uconstrainedSchedule && fixedAssignments.Count > 0)
                {
                    balancing = !balancing;
                }
                Node[] source;
                Node[] destination;
                if (balancing)
                {
                    source = _workers;
                    destination = _tasks;
                }
                else
                {
                    source = _tasks;
                    destination = _workers;
                }
                Dictionary<Node, Node> matching = FindMatching(source, destination, fixedAssignments);
                foreach(KeyValuePair<Node, Node> pair in matching)
                {
                    Node task = balancing ? pair.Value : pair.Key;
                    Node worker = balancing ? pair.Key : pair.Value;
                    _taskAndNode[task.Name].TimesScheduled++;
                    _nameAndNode[worker.Name].TimesScheduled++;
                    assignments.Rows[i][task.Name] = worker;
                }
            }
            ComputeScheduleStats();
        }

        /// <summary>
        /// A method that computes the statistics for the computed schedule (assumed to be computed)
        /// </summary>
        private void ComputeScheduleStats()
        {
            double total = 0;
            int workerCount = _workers.Length;
            for (int i = 0; i < workerCount; i++)
            {
                Node w = _workers[i];
                total += w.TimesScheduled;
                if (w.TimesScheduled == 0)
                {
                    WorkersUnscheduled++;
                }
                if (w.TimesScheduled > MostScheduledTasks)
                {
                    MostScheduledTasks = w.TimesScheduled;
                }
                _workers[i] = w;
            }
            AverageScheduledTasks = Math.Round(total / _workers.Length, 2);
        }

        /// <summary>
        /// Resets schedule statistics between computed schedules.
        /// </summary>
        private void ResetStats()
        {
            MostScheduledTasks = WorkersUnscheduled = 0;
            AverageScheduledTasks = 0;
            int workerCount = _workers.Length;
            for (int i = 0; i < workerCount; i++)
            {
                Node w = _workers[i];
                w.TimesScheduled = 0;
                _workers[i] = w;
            }
        }

    }
}
