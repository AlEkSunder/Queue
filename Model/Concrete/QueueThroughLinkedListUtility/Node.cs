using System;

namespace Model.Concrete.QueueThroughLinkedListUtility
{
    /// <summary>
    /// Provides functionality for item of linked list.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    public class Node<T>
    {
        /// <summary>
        /// Gets or sets the next node.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The link to the next node.
        /// </value>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        public Node()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="value">The value.</param>
        public Node(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the previous node.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The link to the previous node.
        /// </value>
        public Node<T> Prev { get; set; }

        /// <summary>
        /// Gets the current node value.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }
    }
}
