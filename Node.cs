/* Worker.cs
 * Author: Josh Weese and Rod Howell
 * 
 * Edited By: Ian Flores
 */

namespace Ksu.Cis300.Scheduler
{
    /// <summary>
    /// A representation of a worker qualified for certain tasks.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets the name of the worker.
        /// </summary>
        public string Name
        {
            get; private set;
        }

        /// <summary>
        /// Gets or sets the number of times this worker has been scheduled.
        /// </summary>
        public int TimesScheduled
        {
            get;
            set;
        }


        /// <summary>
        /// Constructs a Worker given a single string
        /// </summary>
        /// <param name="data">The mane</param>
        public Node(string data)
        {
            Name = data;
        }
    }
}
