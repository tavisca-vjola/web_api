using System;
using webapi.Controllers;
using Xunit;

namespace apitests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var Values = new ValuesController();
            Assert.Equal("Hello",Values.Get("Hi").Value);
        }
        [Fact]
        public void Test2()
        {
            var Values = new ValuesController();
            Assert.Equal("Hi", Values.Get("Hello").Value);
        }
    }
}
