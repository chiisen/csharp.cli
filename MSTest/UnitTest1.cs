using FluentAssertions;

namespace MSTest
{
    public class TestClass
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Add()
        {
            int num1 = 1;
            int num2 = 2;
            var actual = TestClass.Add(num1, num2);

            actual.Should().Be(num1 + num2, because: $"{num1}+{num2}={num1 + num2}");
        }
        [TestMethod]
        public void TestMethod_Basic()
        {
            // object
            object? obj = null;
            obj.Should().BeNull("because the obj is null");
            //obj.Should().NotBeNull();

            // string 
            var something = "something";
            //something.Should().BeEmpty();
            something.Should().NotBeEmpty();

            // datetime 
            /*
            var time = new DateTime();
            time.Should().HaveYear(2023);
            time.Should().HaveDay(26);
            time.Should().HaveMonth(6);
            time.Should().HaveHour(11);
            time.Should().HaveMinute(25);
            time.Should().HaveSecond(0);
            */

            // dictionary 
            var dic = new Dictionary<int, string>()
            {
                {1, "Marcus"},
                {2, "Flash"},
                {3, "Neil"}
            };
            dic.Should().NotBeEmpty();

            // type
            something.Should().BeOfType<string>("because a {0} is set", typeof(string));
            something.Should().BeOfType(typeof(string), "because a {0} is set", typeof(string));

            // equal 
            string otherObject = "whatever";
            //something.Should().Be(otherObject, "because they have the same values");
            something.Should().NotBe(otherObject);

            // exception 
            /*
            something.Should().BeOfType<Exception>()
                .Which.Message.Should().Be("Other Message");
            */
        }
    } 
}