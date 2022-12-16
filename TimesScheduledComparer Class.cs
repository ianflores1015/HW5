/* Author: Ian Flores
 * 
 */
using Ksu.Cis300.Scheduler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TaskScheduler
{
    /// <summary>
    /// The TimesScheduledComparer Class
    /// </summary>
    class TimesScheduledComparer : IComparer<Node>
    {
        /// <summary>
        /// The implementation of the interface
        /// </summary>
        /// <param name="x">The first node to compare</param>
        /// <param name="y">The second node to compare</param>
        /// <returns>The result of the comparison</returns>
        public int Compare(Node x, Node y)
        {
            return x.TimesScheduled.CompareTo(y.TimesScheduled);
        }
    }
}
