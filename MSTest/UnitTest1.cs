namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int num1 = 1;
            int num2 = 2;
            bool result = num1 == num2;

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}