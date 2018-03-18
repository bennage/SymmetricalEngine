
using System;
using System.Collections.Generic;
using System.Linq;

using SectorMap = System.Collections.Generic.Dictionary<int, int>;
public static class Movement
{
    // TODO: rather than depend on `Space`, I'd like to have a graph abstraction
    // this could also be an NPC's memory of space
    public static IEnumerable<int> Route(int start, int goal, Space space)
    {
        // A*
        var openSet = new Queue<int>(new[] { start });

        var closedSet = new Dictionary<int, bool>();

        var gScore = new SectorMap();
        var cameFrom = new SectorMap();

        gScore[start] = 0;

        Sector current = null;

        while (openSet.Count > 0)
        {
            // we should use an fscore to pick the best guess from the open set
            var currentId = openSet.Dequeue();
            current = space.FindById(currentId);
            closedSet[currentId] = true;

            if (current == null) continue;

            if (current.Id == goal)
            {
                return ConstructPath(cameFrom, current.Id);
            }

            foreach (var neighbor in current.JumpRoutes)
            {
                // have we already closed the neighbor?
                if (closedSet.ContainsKey(neighbor)) continue;

                var costToMoveToNeighbor = 1;
                var tentativeScore = gScore[current.Id] + costToMoveToNeighbor;

                // if the neighbor is not in the open set, we'll add it
                if (!openSet.Contains(neighbor))
                {
                    openSet.Enqueue(neighbor);
                }
                else if (tentativeScore >= gScore[neighbor])
                {
                    // we've seen it, but the cost is higher
                    continue;
                }

                cameFrom[neighbor] = current.Id;
                gScore[neighbor] = tentativeScore;
                // fScore[neighbor] = gScore[neighbor] + heuristic_cost_estimate(neighbor, goal)
            }
        }
        throw new Exception("we couldn't find a path!");
    }

    private static IEnumerable<int> ConstructPath(SectorMap cameFrom, int currentId)
    {
        var path = new[] { currentId };

        while (cameFrom.ContainsKey(currentId))
        {
            currentId = cameFrom[currentId];
            path = path.Append(currentId).ToArray();
        }

        // remove starting sector id since we're already there
        return path.Reverse().Skip(1);
    }
}