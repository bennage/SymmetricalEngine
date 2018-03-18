using System.Collections.Generic;

public class Sector
{
    public IEnumerable<int> JumpRoutes { get; private set; }
    public int Id { get; private set; }

    public Sector(int sectorId, IEnumerable<int> routes)
    {
        this.Id = sectorId;
        this.JumpRoutes = routes;
    }
}