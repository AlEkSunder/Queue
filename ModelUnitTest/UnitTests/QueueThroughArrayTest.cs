using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Concrete;

namespace ModelUnitTest.UnitTests
{
    /// <summary>
    /// Represents the test class for the <see cref="QueueThroughArray"/> class.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    [TestClass]
    public class QueueThroughArrayTest
    {
        /// <summary>
        /// Represents the tests executed towards the <see cref="QueueThroughArray.Dequeue"/> method, 
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
            QueueThroughArray<string> queue = new QueueThroughArray<string>();
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
        /// Represents the tests executed towards the <see cref="QueueThroughArray.Dequeue"/> method, 
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
            QueueThroughArray<string> queue = new QueueThroughArray<string>();
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
        /// Represents the tests executed towards the <see cref="QueueThroughArray.Dequeue"/> method, 
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
            QueueThroughArray<string> queue = new QueueThroughArray<string>();

            //
            // Act.
            //
            queue.Dequeue();
        }

        /// <summary>
        /// Represents the tests executed towards the <see cref="QueueThroughArray.Enqueue"/> method, 
        /// in the case where the amount of added elements is more than length, adds all elements, returns the first one.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        [TestMethod]
        public void Enqueue_AmountOfAddedElementsIsMoreThanLength_AddsAllElementsReturnsFirstOne()
        {
            //
            // Arrange.
            //
            string expectedResult = "First";
            string actualResult = string.Empty;
            int length = 2;
            QueueThroughArray<string> queue = new QueueThroughArray<string>(length);
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
        /// Represents the tests executed towards the <see cref="QueueThroughArray.Peek"/> method, 
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
            QueueThroughArray<string> queue = new QueueThroughArray<string>();
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
        /// Represents the tests executed towards the <see cref="QueueThroughArray.Peek"/> method, 
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
            QueueThroughArray<string> queue = new QueueThroughArray<string>();
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