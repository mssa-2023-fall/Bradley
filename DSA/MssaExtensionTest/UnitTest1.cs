using MssaExtension;


namespace MssaExtensionTest
{
    [TestClass]
    public class UnitTest1
    {
        #region File Sha1 Extension test
        [TestMethod]
        public void TestGetShaStringExtension()
        {
            var _file = new FileInfo(@"C:\Test\oscar_age_male.csv");
            Assert.AreEqual("alC05d5TVHGwBd/uPVqX0aHexwQ=", _file.GetSHAString(StringFormat.Base64));
            Assert.AreEqual("6a50b4e5de535471b005dfee3d5a97d1a1dec704", _file.GetSHAString(StringFormat.Hex));
        }
        #endregion

        #region Finding Median Test
        [TestMethod]
        public void CustomLinqMethods()
        {
            //Arrange
            IEnumerable<int> inputs = new[] { 1, 2, 3, 4, 5, 6, 7000 };
            //Act
            float median = inputs.Median();
            //Assert
            Assert.AreEqual(median, 4);
        }
        [TestMethod]
        public void CustomLinqMethods2()
        {
            //Arrange
            IEnumerable<float> inputs2 = new[] { 1.5f, 2.3f, 3.1f, 4.5f, 5.72f, 6.12f, 7.99f, 8.26f };
            //Act
            var median2 = inputs2.Median();
            //Assert
            Assert.AreEqual(median2, 5.72f);
        }
        [TestMethod]
        public void CustomLinqMethods3()
        {
            //Arrange
            IEnumerable<double> inputs2 = new[] { 1.5, 2.3, 3.1, 4.5, 5.72, 6.12, 7.99, 8.26 };
            //Act
            var median2 = inputs2.Median();
            //Assert
            Assert.AreEqual(median2, 5.72d);
        }
        [TestMethod]
        public void CustomLinqMethods4()
        {
            //Arrange
            IEnumerable<decimal> inputs2 = new[] { 1.5m, 2.4m, 3.1m, 4.5m, 5.72m, 6.12m, 7.99m, 8.26m };
            //Act
            var median2 = inputs2.Median();
            //Assert
            Assert.AreEqual(median2, 5.72m);
        }
        #endregion

        #region Indexer Test
        [TestMethod]
        public void TestDictionaryIndexer()
        {
            Dictionary<FileInfo, Stream> dictionary = new Dictionary<FileInfo, Stream>();
            var _file = new FileInfo(@"C:\Test\oscar_age_male.csv");
            dictionary.Add(_file,_file.OpenRead());
            Assert.IsTrue(dictionary[_file].Length == _file.Length);
        }
        #endregion
    }
}