/* WorkerQueue.cs
 * Author: Josh Weese and Rod Howell
 * 
 * Edited By: Ian Flores
 */
using System;
using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.Scheduler
{
    /// <summary>
    /// A queue of workers that may be searched for the next worker qualified for a given task.
    /// </summary>
    public class WorkerQueue
    {
        /// <summary>
        /// A header cell at the front of the queue.
        /// </summary>
        private LinkedListCell<Node> _front = new LinkedListCell<Node>();

        /// <summary>
        /// The back of the queue.
        /// </summary>
        private LinkedListCell<Node> _back;


        /// <summary>
        /// Gets the number of workers in the queue.
        /// </summary>
        public int Count
        {
            get; private set; 
        }

        /// <summary>
        /// Constructs an empty queue.
        /// </summary>
        public WorkerQueue()
        {
            _back = _front;
        }

        /// <summary>
        /// Places the given worker at the back of the queue.
        /// </summary>
        /// <param name="x">The worker to enqueue.</param>
        public void Enqueue(Node x)
        {
            LinkedListCell<Node> cell = new LinkedListCell<Node>();
            cell.Data = x;
            _back.Next = cell;
            _back = cell;
            Count++;
        }

        /// <summary>
        /// Removes the worker from the front of the queue.
        /// </summary>
        /// <returns>The worker removed.</returns>
        public Node Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return RemoveNext(_front);
        }

        /// <summary>
        /// Removes the cell following the given cell from the queue.
        /// </summary>
        /// <param name="p">The cell preceding the cell to be removed.</param>
        /// <returns>The worker in the cell removed.</returns>
        private Node RemoveNext(LinkedListCell<Node> p)
        {
            Node w = p.Next.Data;
            p.Next = p.Next.Next;
            Count--;
            if (p.Next == null)
            {
                _back = p;
            }
            return w;
        }

        /// <summary>
        /// Removes the first worker qualified for the given task. If no workers are qualifed,
        /// throws an InvalidOperationException.
        /// </summary>
        /// <param name="i">The task.</param>
        /// <returns>The first worker qualified for task i, or null if no workers are qualified.</returns>
        public Node GetFirstQualified(int i)
        {
            for (LinkedListCell<Node> p = _front; p.Next != null; p = p.Next)
            {
                /*if (p.Next.Data.IsQualified(i))
                {
                    return RemoveNext(p);
                }*/
            }
            return null;
        }
    }
}
