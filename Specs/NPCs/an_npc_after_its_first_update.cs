
using Xunit;

public class an_npc_after_its_first_update
{
    NPC npc;
    Space space;
    public an_npc_after_its_first_update()
    {
        space = new Space();
        space.AddSector(1, new[] { 2 });
        space.AddSector(2, new[] { 1 });

        npc = new NPC("x", 1, (decide: 1, move: 1), space);

        npc.Update(0, space);
    }

    [Fact]
    public void should_have_a_plan()
    {
        Assert.Equal(NPC.Plans.Explore, npc.Plan);
    }
}