using System;
using Xunit;
using ArtModel;

namespace Tests
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            Artist a = new Artist();
            a.Id=2;
            Assert.Equal(3, a.Id);
        }
    }
}
