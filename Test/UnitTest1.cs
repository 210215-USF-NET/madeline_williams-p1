using System;
using Xunit;
using ArtModel;

namespace Test
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            Artist a = new Artist();
            a.Id = 2;
            Assert.Equal(2, a.Id);
        }
    }
}