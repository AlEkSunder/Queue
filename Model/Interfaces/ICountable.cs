using System;

namespace Model.Interfaces
{
    /// <summary>
    /// Defines the interface for collection which can be counted.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    public interface ICountable
    {
        /// <summary>
        /// Gets the count of items in collection.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The of items in collection.
        /// </value>
        int Count { get; }
    }
}
