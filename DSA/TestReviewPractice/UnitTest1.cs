using ReviewPractice;

namespace TestReviewPractice
{
    [TestClass]
    public class ReviewTestSortedList
    {
        [TestMethod]
        public void SortedListReallySortsGivenSets()
        {
            //Arrange
            SortedSet<int> Set1 = new() { 10, 12, 15, 17, 20, 21 };
            SortedSet<int> Set2 = new() { 8, 9, 11, 14, 19 };

            //Act
            SortedSet<int> Set3 = new(Set1.Concat(Set2));
            List<int> result = SortList.Merge(Set1, Set2);

            //Assert
            CollectionAssert.AreEqual(Set3, result);
        }
    }
}