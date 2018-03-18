using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

public class Space
{
    private IDictionary<int, Sector> Sectors = new ConcurrentDictionary<int, Sector>();

    public Sector FindById(int sectorId)
    {
        return Sectors.ContainsKey(sectorId)
         ? Sectors[sectorId]
         : null;
    }

    public void AddSector(int sectorId, IEnumerable<int> routes)
    {
        var sector = new Sector(sectorId, routes);
    }
}