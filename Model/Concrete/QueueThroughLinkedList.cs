using System;
using Model.Interfaces;
using Model.Concrete.QueueThroughLinkedListUtility;
using System.Text;

namespace Model.Concrete
{
    /// <summary>
    /// Provides functionality for queue.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    /// <seealso cref="IQueue{T}" />
    public class QueueThroughLinkedList<T> : IQueue<T>
    {
        /// <summary>
        /// Holds the head of the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private Node<T> head;

        /// <summary>
        /// Holds the name of the type.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        public static string Name = "Queue_linked_list";

        /// <summary>
        /// Holds the tail of the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private Node<T> tail;

        /// <summary>
        /// Clears the collection.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        public void Clear()
        {
            this.head.Value = default(T);
            this.head.Next = this.tail;
            this.tail.Value = default(T);
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
        /// <returns>
        /// The first item in queue.
        /// </returns>
        public T Dequeue()
        {
            var peekedValue = this.Peek();

            if (this.head.Next.Next == null)
                this.head.Next = this.tail;
            else
                this.head.Next = this.head.Next.Next;
            this.Count--;

            return peekedValue;
        }

        /// <summary>
        /// Adds the item to the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="item">The new item for the queue.</param>
        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);

            if (this.head.Next == tail)
            {
                this.head.Next = newNode;
                this.tail.Prev = newNode;
            }
            else
            {
                var old = this.tail.Prev;
                this.tail.Prev = newNode;
                old.Next = newNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Gets the string of the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="stringPart">The string part.</param>
        /// <param name="item">The item.</param>
        /// <returns>The string of the queue.</returns>
        private StringBuilder GetString(StringBuilder stringPart, Node<T> item)
        {
            if (item == null || item.Value == null)
                return stringPart;

            stringPart.Append($"{item.Value}; ");

            if (item.Next == null)
                return stringPart;

            return this.GetString(stringPart, item.Next);
        }

        /// <summary>
        /// Gets the first item from the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>
        /// The first item from the queue.
        /// </returns>
        public T Peek()
        {
            if (this.head.Next == this.tail)
                throw new InvalidOperationException("The queue is empty");

            return this.head.Next.Value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueThroughLinkedList{T}"/> class.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        public QueueThroughLinkedList()
        {
            this.head = new Node<T>();
            this.tail = new Node<T>();
            this.head.Next = this.tail;
            this.tail.Prev = this.head;
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
            return this.GetString(new StringBuilder(), this.head.Next).ToString();
        }
    }
}