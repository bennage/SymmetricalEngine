using System;
using System.Linq;
using Xunit;

namespace Specs
{
    public class When_calculating_routes_in_space
    {
        Space space;

        public When_calculating_routes_in_space()
        {
            space = new Space();
            space.AddSector(1, new[] { 2 });
            space.AddSector(2, new[] { 1, 3 });
            space.AddSector(3, new[] { 2, 4 });
            space.AddSector(4, new[] { 1, 5 });
            space.AddSector(5, new[] { 2 });
        }

        [Fact]
        public void from_1_to_2()
        {
            var r = Movement.Route(1, 2, space).ToArray();
            Assert.Equal(2, r[0]);
        }

        [Fact]
        public void from_1_to_3()
        {
            var r = Movement.Route(1, 3, space).ToArray();
            Assert.Equal(2, r[0]);
            Assert.Equal(3, r[1]);
        }

        [Fact]
        public void from_1_to_5()
        {
            var r = Movement.Route(1, 5, space).ToArray();
            Assert.Equal(2, r[0]);
            Assert.Equal(3, r[1]);
            Assert.Equal(4, r[2]);
            Assert.Equal(5, r[3]);
        }

        [Fact]
        public void from_5_to_1()
        {
            var r = Movement.Route(5, 1, space).ToArray();
            Assert.Equal(2, r[0]);
            Assert.Equal(1, r[1]);
        }

        [Fact]
        public void from_5_to_4()
        {
            var r = Movement.Route(5, 4, space).ToArray();
            Assert.Equal(2, r[0]);
            Assert.Equal(3, r[1]);
            Assert.Equal(4, r[2]);
        }
    }

}
