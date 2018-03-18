
using System.Linq;
using Xunit;

public class an_npc_with_a_plan
{
    NPC npc;
    Space space;

    public an_npc_with_a_plan()
    {
        space = new Space();
        space.AddSector(1, new[] { 2 });
        space.AddSector(2, new[] { 1 });

        npc = new NPC("x", 1, (decide: 1, move: 1), space);

        // first update sets a plan
        npc.Update(0, space);

        // we expect the npc to move
        npc.Update(0, space);
    }
    [Fact]
    public void should_know_its_sector_after_jumping()
    {
        Assert.Equal(2, npc.SectorId);
    }

    [Fact]
    public void should_remember_where_it_came_from()
    {
        Assert.Contains(1, npc.Memory);
    }

    [Fact]
    public void should_be_found_it_the_sector_it_moved_to()
    {
        Assert.Contains(npc, space.FindById(2).Actors);
    }
}