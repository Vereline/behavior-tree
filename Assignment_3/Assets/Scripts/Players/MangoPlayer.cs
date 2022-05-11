using Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangoPlayer : ComputerPlayer
{

    private MangoBehaviourTree mangoBehaviourTree;

    public override void OnGameStarted()
    {
        base.OnGameStarted();

        // Did you know that Mango is a tree?
        mangoBehaviourTree = new MangoBehaviourTree(this);

    }

    protected override void EvaluateDecisions(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
    {
        // TODO Replace with your own code

        //if (pathTilesQueue.Count == 0)
        //{
        //    for (var i = 0; i < spawnedCollectibles.Count; ++i)
        //    {
        //        if (Vector2Int.Distance(CurrentTile, spawnedCollectibles[i].TileLocation) <= 1.0f)
        //        {
        //            pathTilesQueue.Enqueue(spawnedCollectibles[i].TileLocation);
        //            break;
        //        }
        //    }
        //}
        if (pathTilesQueue.Count == 0)
        {
            mangoBehaviourTree.RunBehaviourTree(maze, players, spawnedCollectibles, remainingGameTime);
        }
    }
}
