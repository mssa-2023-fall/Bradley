using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListLib;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void LinkedListAddFirstAddsToBeginning()
        {
            //Arrange
            var linkedList = new LinkedListLib.LinkedList<int>();
            linkedList.AddFirst(new Node<int>(1));

            //Act
            var head = linkedList.Head;
            var tail = linkedList.Tail;

            //Assert
            Assert.AreEqual(1, head.Content);
            Assert.AreEqual(1, tail.Content);
        }

        [TestMethod]
        public void LinkedListAddLastAddsToEnd()
        {
            //Arrange
            var linkedList = new LinkedListLib.LinkedList<int>();
            linkedList.AddLast(new Node<int>(1));
            linkedList.AddLast(new Node<int>(2));

            //Act
            var head = linkedList.Head;
            var tail = linkedList.Tail;

            //Assert
            Assert.AreEqual(1, head.Content);
            Assert.AreEqual(2, tail.Content);
        }

        [TestMethod]
        public void LinkedListRemoveFirstRemovesFromBeginning()
        {
            //Arrange
            var linkedList = new LinkedListLib.LinkedList<int>();
            linkedList.AddFirst(new Node<int>(1));
            linkedList.AddFirst(new Node<int>(2));

            //Act
            linkedList.RemoveFirst();

            //Assert
            var head = linkedList.Head;
            Assert.AreEqual(1, head.Content);
        }

        [TestMethod]
        public void LinkedListRemoveLastRemovesFromEnd()
        {
            //Arrange
            var linkedList = new LinkedListLib.LinkedList<int>();
            linkedList.AddLast(new Node<int>(1));
            linkedList.AddLast(new Node<int>(2));

            //Act
            linkedList.RemoveLast();

            //Assert
            var tail = linkedList;
            Assert.AreEqual(1, tail.Count);
        }
        [TestMethod]
        public void LinkedListRemoveAtRemovesInSpecificPosition()
        {
            //Arrange
            var linkedList = new LinkedListLib.LinkedList<int>();
            linkedList.AddFirst(new Node<int>(1));
            linkedList.AddLast(new Node<int>(2));
            linkedList.AddLast(new Node<int>(3));

            //Act
            linkedList.RemoveAt(2);

            //Assert
            Assert.AreEqual(2, linkedList.Count);

        }
        [TestMethod]
        public void ClearEmptiesLinkedList()
        {
            //Arrange
            var linkedList = new LinkedListLib.LinkedList<int>();
            linkedList.AddFirst(new Node<int>(1));
            linkedList.AddLast(new Node<int>(2));
            linkedList.AddLast(new Node<int>(3));

            //Act
            linkedList.Clear();

            //Assert
            Assert.AreEqual(0, linkedList.Count);
            Assert.AreNotEqual(2, linkedList.Count);

        }
        // Add more test methods for other operations...
    }
}
