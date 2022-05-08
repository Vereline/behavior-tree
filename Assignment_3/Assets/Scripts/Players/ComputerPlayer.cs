﻿using Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComputerPlayer : AbstractPlayer
{
    public Queue<Vector2Int> pathTilesQueue = new Queue<Vector2Int>();

    protected PathFinder pathFinder;

    public override void OnGameStarted()
    {
        base.OnGameStarted();
        pathFinder = gameObject.AddComponent<PathFinder>();

        pathFinder.InitializeData(parentMaze);
    }

    protected override void Update()
    {
        base.Update();

        EvaluateDecisions(
            parentMaze,
            GameManager.Instance.Players,
            GameManager.Instance.SpawnedCollectibles,
            GameManager.Instance.TimeRemaining
            );
    }

    protected override Vector2Int GetNextPathTile()
    {
        if (pathTilesQueue.Count > 0)
        {
            return pathTilesQueue.Dequeue();
        }

        return base.GetNextPathTile();
    }

    public List<Vector2Int> GetPathFromTo(Vector2Int srcTile, Vector2Int destTile)
    {
        // TODO: Implement this method to make it retrieve the path from the source tile to destination tile
        //       so you can use it in the "derived bots"
        pathFinder.ResetCostMaze();
        List<Vector2Int> newPath = pathFinder.FindPath(srcTile, destTile);
        return newPath;
        //return new List<Vector2Int> { srcTile };
    }

    // TODO: To complete this assignment, you will need to write 
    //       a fair amount of code. It is recommended to create
    //       custom classes/functions to decouple the computations.

    //       The method EvaluateDecisions should be the place where the final decision
    //       should be computed. The bot automatically follows the path which is
    //       described in the "pathTilesQueue" variable. All neighboring values inside
    //       this queue must be 4-neighbors, i.e., the bot can walk only
    //       up/down/left/right with a step of one.
    //      
    //       You do not have to use all arguments of this function 
    //       and you can add even more parameters if you would like to do so.
    //       Tiles of the maze can be accessed via maze.MazeTiles.
    //       Human player is the first player in the "players" list.
    //       CollectibleItem class contains TileLocation property providing information about collectible's position
    //       and Type property retrieving its type.
    //       Good luck. May your bots remain unbeaten by a human player. :)
    protected abstract void EvaluateDecisions(Maze maze, List<AbstractPlayer> players,
        List<CollectibleItem> spawnedCollectibles, float remainingGameTime);
}
