using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Model.Interfaces;

namespace Model.Concrete
{
    /// <summary>
    /// Provides functionality for queue.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    /// <seealso cref="IQueue{T}" />
    public sealed class QueueThroughArray<T> : IQueue<T>
    {
        /// <summary>
        /// Holds the default length of the array for queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private const int defaultLength = 4;

        /// <summary>
        /// Holds the default multiplier for array increment.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private const int defaultMultiplier = 2;

        /// <summary>
        /// Holds the position of head of the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private int head;

        /// <summary>
        /// Holds the custom length of array.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private readonly int length;

        /// <summary>
        /// Holds the custom multiplier for array increment.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private readonly int multiplier;

        /// <summary>
        /// Holds the name of the type.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        public static string Name = "Queue_array";

        /// <summary>
        /// Holds the array of elements which provides collection for queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private T[] queue;

        /// <summary>
        /// Holds the position of tail of the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private int tail;

        /// <summary>
        /// Clears all items in queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        public void Clear()
        {
            this.head = 0;
            this.tail = 0;
            this.queue = new T[this.length];
        }

        /// <summary>
        /// Gets or sets the count of elements in queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The count of elements in queue.
        /// </value>
        public int Count { get; private set; }

        /// <summary>
        /// Returns the first item in the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>The first item in queue.</returns>
        public T Dequeue()
        {
            var result = this.Peek();
            this.RemovePeekedItem();
            this.head++;
            this.Count--;

            return result;
        }

        /// <summary>
        /// Adds the item to the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="item">The new item for the queue.</param>
        public void Enqueue(T item)
        {
            this.SetItem(item);
            this.tail++;
            this.Count++;
        }

        /// <summary>
        /// Increases the current array for much more items.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void IncreaseArray()
        {
            T[] increasedArray = new T[this.queue.Length * this.multiplier];
            this.queue.CopyTo(increasedArray, 0);
            this.head = 0;
            this.tail = this.queue.Length;
            this.queue = increasedArray;
        }

        /// <summary>
        /// Determines whether the specified position exist in the current array.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>True if position exists, otherwise - false.</returns>
        private bool IsPositionExist(int position)
        {
            if (this.queue.Length > position)
                return true;

            return false;
        }

        /// <summary>
        /// Gets the first item from the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>The first item from the queue.</returns>
        public T Peek()
        {
            if (this.head == this.tail)
                throw new InvalidOperationException("The queue is empty");

            return this.queue[this.head];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueThroughArray{T}"/> class.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        public QueueThroughArray()
            : this(QueueThroughArray<T>.defaultLength, QueueThroughArray<T>.defaultMultiplier)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueThroughArray{T}"/> class.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        public QueueThroughArray(int length)
            : this(length, QueueThroughArray<T>.defaultMultiplier)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueThroughArray{T}" /> class.
        /// </summary>
        /// 
        /// <param name="length">The length.</param>
        /// <param name="multiplier">The multiplier for embedded array increment.</param>
        public QueueThroughArray(int length, byte multiplier)
        {
            this.length = length > 0
                ? length
                : QueueThroughArray<T>.defaultLength;

            this.multiplier = multiplier > 0
                ? multiplier
                : QueueThroughArray<T>.defaultMultiplier;

            this.queue = new T[length];
        }

        /// <summary>
        /// Removes the peeked item of the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void RemovePeekedItem()
        {
            this.queue[this.head] = default(T);
        }

        /// <summary>
        /// Sets the item to the tail of the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void SetItem(T item)
        {
            if (!this.IsPositionExist(this.tail))
                this.IncreaseArray();

            this.queue[this.tail] = item;
        }

        /// <summary>
        /// Returns a <see cref="String" /> that represents this instance.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>
        /// A <see cref="String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (T item in this.queue)
            {
                if (item == null)
                    continue;

                result.Append($"{item}; ");
            }

            return result.ToString();
        }
    }
}