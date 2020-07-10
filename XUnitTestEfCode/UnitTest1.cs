using System;

using Xunit;

namespace XUnitTestEfCode {
    public class UnitTest1 {
        public int Modulo(int a, int b) {
            return a % b;
        }
        [Fact]
        public void TestFact() {
            Assert.Equal(1, Modulo(3,2));
        }
        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public void TestEven(int nbr) {
            Assert.True(Modulo(nbr, 2) == 0);
        }
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public void TestOdd(int nbr) {
            Assert.True(Modulo(nbr, 2) == 1);
        }
    }
}
