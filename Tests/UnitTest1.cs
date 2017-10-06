using System;
using Xunit;
using appLanche.Services;

namespace appLanche.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var service = new Class1();

            Assert.True(1 == service.funcao(1));            
        }
    }
}
