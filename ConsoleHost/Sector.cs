using System.Collections.Generic;

public class Sector
{
    public IEnumerable<int> JumpRoutes { get; private set; }
    public int Id { get; private set; }

    public List<NPC> Actors { get; private set; }

    public Sector(int sectorId, IEnumerable<int> routes)
    {
        Id = sectorId;
        JumpRoutes = routes;
        Actors = new List<NPC>();
    }
}