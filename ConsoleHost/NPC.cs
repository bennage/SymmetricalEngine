
using System.Collections.Generic;
using System.Linq;

public class NPC
{
    public int SectorId { get; private set; }
    public IEnumerable<int> Memory { get { return _memory; } }
    public Plans Plan { get; private set; }

    private Queue<int> _memory = new Queue<int>();

    public NPC(string name, int sectorId, (double decide, double move) traits, Space space)
    {
        this.SectorId = sectorId;
        _memory.Enqueue(sectorId);
    }
    public void Update(double elapsed, Space space)
    {
        switch (Plan)
        {
            case Plans.None:
                Plan = Plans.Explore;
                break;

            case Plans.Explore:
                Explore(elapsed, space);
                break;

        }
    }
    private void Explore(double elapsed, Space space)
    {
        var currentSector = space.FindById(SectorId);

        // what sector have we not seen?
        var possible = currentSector.JumpRoutes.Where(x => !Memory.Contains(x));

        if (!possible.Any())
        {
            // nothing left to explore
            Plan = Plans.None;
            return;
        }

        Jump(possible.First(), space);
    }
    private void Jump(int sectorId, Space space)
    {
        var currentSector = space.FindById(SectorId);
        var targetSector = space.FindById(sectorId);

        SectorId = sectorId;
        currentSector.Actors.Remove(this);
        targetSector.Actors.Add(this);
    }

    public enum Plans
    {
        None = 0,
        Explore = 1,
    }
}