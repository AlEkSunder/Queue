using System;

namespace Model.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueue<T> : IClearable, ICountable
    {
        /// <summary>
        /// Returns the first item in the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>The first item in queue.</returns>
        T Dequeue();

        /// <summary>
        /// Adds the item to the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="item">The new item for the queue.</param>
        void Enqueue(T item);

        /// <summary>
        /// Gets the first item from the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>The first item from the queue.</returns>
        T Peek();
    }
}