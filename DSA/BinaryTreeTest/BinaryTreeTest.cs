using BinaryTree;

namespace BinaryTreeTest
{
    [TestClass]
    public class BinaryTreeTesting
    {
        [TestMethod]
        public void CountShouldReturnAccurateNumberOfNodes()
        {
            //Arrange
            BradTree<int> bradTree = new BradTree<int>();

            //Act
            bradTree.Add(2);
            bradTree.Add(3);
            bradTree.CountNodes();
            
            //Assert
            Assert.AreEqual(2,bradTree.CountNodes());
        }
        [TestMethod]
        public void NodeShouldHaveDataAttached()
        {
            //Arrange
            BradTree<int> bradTree = new BradTree<int>();

            //Act
            bradTree.Add(2);
            bradTree.Add(3);
            

            //Assert
            Assert.AreEqual(3, bradTree.Contains(3));
            Assert.AreNotEqual(4, bradTree.Contains(2));
        }
        [TestMethod]
        public void CreationOfNodeShouldDistinguishLeftChildORRightChild()
        {
            //Arrange

            //Act

            //Assert

        }
        [TestMethod]
        public void NodeShouldRecognizedAsRoot()
        {
            //Arrange
            BradTree<int> bradTree = new BradTree<int>();

            //Act
            
            
            //Assert

        }
        [TestMethod]
        public void TreeShouldFindMax()
        {
            //Arrange

            //Act

            //Assert

        }
        [TestMethod]
        public void TreeSHouldFindMin()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}