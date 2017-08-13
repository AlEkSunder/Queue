using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Concrete;

namespace ModelUnitTest.UnitTests
{
    /// <summary>
    /// Represents the test class for the <see cref="QueueThroughLinkedList"/> class.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    [TestClass]
    public class QueueThroughLinkedListTest
    {
        /// <summary>
        /// Represents the tests executed towards the <see cref="QueueThroughLinkedList.Dequeue"/> method, 
        /// in the case where the queue contains several elements, deletes returned element.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        [TestMethod]
        public void Dequeue_QueueContainsSeveralElements_DeletesReturnedElement()
        {
            //
            // Arrange.
            //
            bool expectedResult = false;
            bool actualResult = false;
            string firstElement = "First";
            QueueThroughLinkedList<string> queue = new QueueThroughLinkedList<string>();
            queue.Enqueue(firstElement);
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            //
            // Act.
            //
            queue.Dequeue();
            string[] arrayOfLeftItems = new string[]
            {
                queue.Dequeue(),
                queue.Dequeue()
            };
            actualResult = arrayOfLeftItems.Contains(firstElement);

            //
            // Assert.
            //
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Represents the tests executed towards the <see cref="QueueThroughLinkedList.Dequeue"/> method, 
        /// in the case where the queue contains several elements, returns the first one.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        [TestMethod]
        public void Dequeue_QueueContainsSeveralElements_ReturnsFirstElement()
        {
            //
            // Arrange.
            //
            string expectedResult = "First";
            string actualResult = string.Empty;
            QueueThroughLinkedList<string> queue = new QueueThroughLinkedList<string>();
            queue.Enqueue(expectedResult);
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            //
            // Act.
            //
            actualResult = queue.Dequeue();

            //
            // Assert.
            //
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Represents the tests executed towards the <see cref="QueueThroughLinkedList.Dequeue"/> method, 
        /// in the case where the queue is empty, throws the <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_QueueIsEmpty_ThrowsInvalidOperationException()
        {
            //
            // Arrange.
            //
            QueueThroughLinkedList<string> queue = new QueueThroughLinkedList<string>();

            //
            // Act.
            //
            queue.Dequeue();
        }

        /// <summary>
        /// Represents the tests executed towards the <see cref="QueueThroughLinkedList.Peek"/> method, 
        /// in the case where the queue contains several elements, deletes returned element.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        [TestMethod]
        public void Peek_QueueContainsSeveralElements_DoesntDeleteReturnedElement()
        {
            //
            // Arrange.
            //
            bool expectedResult = true;
            bool actualResult = false;
            string firstElement = "First";
            QueueThroughLinkedList<string> queue = new QueueThroughLinkedList<string>();
            queue.Enqueue(firstElement);
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            //
            // Act.
            //
            queue.Peek();
            string[] arrayOfLeftItems = new string[]
            {
                queue.Dequeue(),
                queue.Dequeue()
            };
            actualResult = arrayOfLeftItems.Contains(firstElement);

            //
            // Assert.
            //
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Represents the tests executed towards the <see cref="QueueThroughLinkedList.Peek"/> method, 
        /// in the case where the queue contains several elements, returns the first element.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        [TestMethod]
        public void Peek_QueueContainsSeveralElements_ReturnesFirstElement()
        {
            //
            // Arrange.
            //
            string expectedResult = "First";
            string actualResult = string.Empty;
            QueueThroughLinkedList<string> queue = new QueueThroughLinkedList<string>();
            queue.Enqueue(expectedResult);
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            //
            // Act.
            //
            actualResult = queue.Peek();

            //
            // Assert.
            //
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}