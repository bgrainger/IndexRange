using System;
using Xunit;

namespace IndexRange.UnitTests
{
    public class IndexTests2
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void ConstructFromBeginning(int value)
        {
            Index index = value;
            Assert.Equal(value, index.Value);
            Assert.False(index.IsFromEnd);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void ConstructFromEnd(int value)
        {
            Index index = ^value;
            Assert.Equal(value, index.Value);
            Assert.True(index.IsFromEnd);
        }

        [Fact]
        public void ToStringFromBeginning()
        {
            Assert.Equal("0", ((Index) 0).ToString());
            Assert.Equal("100", ((Index) 100).ToString());
        }

        [Fact]
        public void ToStringFromEnd()
        {
            Assert.Equal("^0", (^0).ToString());
            Assert.Equal("^100", (^100).ToString());
        }
    }
}
