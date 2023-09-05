using System.ComponentModel.Design;
using Kitchen;

namespace Lab1Test
{
    [TestClass]
    public class UnitTest1
    { 
        [TestMethod]
        [DataRow("beef")]
        [DataRow("pepperoni")]
        [DataRow("tofu")]
        public void TestWithExpectedProteinShouldReturnExpected(string proteinChoices)
        {
            string dish = proteinChoices;
            Assert.AreEqual(dish, true);
        }
        [TestMethod]
        public void TestWith_UNExpected_ProtenTypeShoulddReturnNull()
        {
            string dish = "fish";
            Assert.AreEqual("You must not have seen our menu try again.", dish, true);
        }
    }
}
