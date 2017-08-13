using System;

namespace Model.Interfaces
{
    /// <summary>
    /// Defines the interface for collection which can be cleared.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    public interface IClearable
    {
        /// <summary>
        /// Clears the collection.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        void Clear();
    }
}
