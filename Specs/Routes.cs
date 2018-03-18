using System;
using System.Linq;
using Xunit;

namespace Specs
{
    public class When_calculating_routes_in_space
    {
        [Fact]
        public void x()
        {
            var space = new Space();
            space.AddSector(1, new[] { 2 });
            space.AddSector(2, new[] { 1, 3 });
            space.AddSector(3, new[] { 2, 4 });
            space.AddSector(4, new[] { 1, 5 });
            space.AddSector(5, new[] { 2 });

            var r = Movement.Route(1, 2, space).ToArray();
            Assert.Equal(r[0], 2);
        }
    }

}
