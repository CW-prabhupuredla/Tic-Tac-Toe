using System;
using WebApplication2.Models;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        public void Test1(int x)
        {
            Test t = new Test();
            Assert.True(t.func(x) == 1);
        }
        [Fact]
        public void Test2()
        {
            Test t = new Test();
            Assert.True(t.func(-1) == -1);
        }
    }
}
