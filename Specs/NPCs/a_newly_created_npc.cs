using System.Collections.Generic;
using System.Linq;
using Xunit;

public class a_newly_created_npc
{
    NPC npc;
    Space space;
    public a_newly_created_npc()
    {
        space = new Space();
        space.AddSector(1, new[] { 2 });
        space.AddSector(2, new[] { 1 });

        npc = new NPC("x", 1, (decide: 1, move: 1), space);
    }

    [Fact]
    public void should_know_its_starting_sector()
    {
        Assert.Equal(1, npc.SectorId);
    }

    [Fact]
    public void should_not_know_about_sector_2()
    {
        Assert.DoesNotContain(2, npc.Memory);
    }

    [Fact]
    public void should_start_off_without_a_plan()
    {
        Assert.Equal(NPC.Plans.None, npc.Plan);
    }
}