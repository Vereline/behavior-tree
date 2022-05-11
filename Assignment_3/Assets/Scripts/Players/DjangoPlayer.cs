using Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjangoPlayer : ComputerPlayer
{

    private DjangoBehaviourTree djangoBehaviourTree;
    public override void OnGameStarted()
    {
        base.OnGameStarted();

        // This will be the real Django Unchained!

        // Django is my favorite Web framework <3
        djangoBehaviourTree = new DjangoBehaviourTree(this);
    }


    protected override void EvaluateDecisions(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
    {
        // TODO Replace with your own code

        //if (pathTilesQueue.Count == 0)
        //{
        //    for (var i = 0; i < players.Count; ++i)
        //    {
        //        if (players[i] != this)
        //        {
        //            if (Vector2Int.Distance(CurrentTile, players[i].CurrentTile) <= 1.0f)
        //            {
        //                pathTilesQueue.Enqueue(players[i].CurrentTile);
        //                break;
        //            }
        //        }
        //    }
        //}

        if (pathTilesQueue.Count == 0) {
            djangoBehaviourTree.RunBehaviourTree(maze, players, spawnedCollectibles, remainingGameTime);
        }
        
    }
}
