namespace LearnImmutableTest
{
    [TestClass]
    public class SampleRecordTest
    {
        [TestMethod]
        public void TestRecprdTypeEqualityWithPositionParameters()
        {
            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }
        [TestMethod]
        public void TestRecprdTypeInequalityWithPositionParameters()
        {
            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 2, ParamDate: new DateTime(2023, 9, 5));
            //assert
            Assert.AreNotEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }
        [TestMethod]
        public void TestRecprdTypeSamenessWithPositionParameters()
        {
            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = record1;
            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreSame(record1, record2);
        }
        [TestMethod]
        public void TestRecordTypeAutoImplementedProperties()
        {
            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreEqual("Test", record1.ParamString);
            Assert.AreEqual(1, record1.ParamInt);
            Assert.AreEqual(new DateTime(2023, 9, 5), record1.ParamDate);
        }
        [TestMethod]
        public void TestRecordTypeMutibility()
        {
            //arrange
            string expected = "Testing";
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //act
            record1.MutableProperty = expected;
            //assert
            Assert.AreEqual(record1, record1);
        }
        [TestMethod]
        public void TestRecordTypeHaveDestructMethodWithOutParam()
        {
            //arrange
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            string outString = String.Empty;
            int outInt = 0;
            DateTime outDateTime = new DateTime();

            //act
            record1.Deconstruct(out outString, out outInt, out outDateTime);

            //assert
            Assert.AreEqual(outString, "Test");
            Assert.AreEqual(outInt, 1);
            Assert.AreEqual(outDateTime, new DateTime(2023, 9, 5));


        }
    }
}