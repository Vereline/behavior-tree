using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    protected int moveDiagonalCost = 14;
    protected int moveStraigtCost = 10;
    
    public List<Vector2Int> path;

    protected Maze parentMaze;

    protected List<List<MazeTile>> costMaze;

    //Coroutine routine;
    public void InitializeData(Maze maze)
    {
        parentMaze = maze;

        costMaze = new List<List<MazeTile>>();

        // we assume that maze is always a square or a rectangle
        for (int i = 0; i < parentMaze.MazeTiles[0].Count; i++)
        {
            costMaze.Add(new List<MazeTile>());

            for (int j = 0; j < parentMaze.MazeTiles.Count; j++)
            {
                MazeTile tile = new MazeTile(new Vector2Int(i, j));
                costMaze[i].Add(tile);
            }
        }

    }

    public List<Vector2Int> FindPath(Vector2Int currentTile, Vector2Int targetTile)
    {
        // Main code

        MazeTile start = costMaze[currentTile.x][currentTile.y];
        MazeTile target = costMaze[targetTile.x][targetTile.y];

        List<MazeTile> openSet = new List<MazeTile>();
        List<MazeTile> closeSet = new List<MazeTile>();
        openSet.Add(start);

        while (openSet.Count > 0)
        {
            MazeTile current = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost <= current.fCost)
                {
                    if (openSet[i].hCost < current.hCost)
                        current = openSet[i];
                }
            }

            openSet.Remove(current);
            closeSet.Add(current);
            
            if (current.tile == targetTile)
            {
                path = RetracePath(start, target);
                return path;
            }

            List<Vector2Int> neighbourTiles = parentMaze.GetNeighbourTiles(current.tile);

            foreach (Vector2Int neighbourTile in neighbourTiles)
            {
                MazeTile neighbour = costMaze[neighbourTile.x][neighbourTile.y];

                if (!parentMaze.IsValidTileOfType(neighbourTile, MazeTileType.Free) || closeSet.Contains(neighbour))
                {
                    continue;
                }

                int newMovementCostToNeighbour = current.gCost + ComputeEuclideanHeuristics(current.tile, neighbourTile);
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = ComputeEuclideanHeuristics(neighbourTile, targetTile);
                    neighbour.parentTile = current;

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
                }
            }
        }

        throw new Exception("Unable to find optimal path");
    }

    protected int ComputeEuclideanHeuristics(Vector2Int currentTile, Vector2Int targetTile)
    {
        int distX = Mathf.Abs(currentTile.x - targetTile.x);
        int distY = Mathf.Abs(currentTile.y - targetTile.y);

        if (distX > distY)
        {
            return moveDiagonalCost * distY + moveStraigtCost * (distX - distY);
        }
        return moveDiagonalCost * distX + moveStraigtCost * (distY - distX);
    }

    public void ResetCostMaze()
    {
        for (int i = 0; i < costMaze.Count; i++)
        {
            for (int j = 0; j < costMaze[i].Count; j++)
            {
                costMaze[i][j].gCost = 0;
                costMaze[i][j].hCost = 0;
            }
        }
    }

    public List<Vector2Int> RetracePath(MazeTile startTile, MazeTile endTile)
    {
        List<Vector2Int> path = new List<Vector2Int>();

        MazeTile currentTile = endTile;

        while (currentTile != startTile)
        {
            path.Add(currentTile.tile);
            currentTile = currentTile.parentTile;
        }

        path.Add(currentTile.tile);
        path.Reverse();

        return path;
    }
}
