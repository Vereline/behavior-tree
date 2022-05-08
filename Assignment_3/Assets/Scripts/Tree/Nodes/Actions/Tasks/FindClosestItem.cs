using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class FindClosestItem : Task
    {
        public FindClosestItem(BehaviourTree tree, TreeNode parent) : base(tree, parent)
        {
            Debug.Log("FindClosestItem initiated");

        }

        public override NodeState Execute()
        {
            List<CollectibleItem> spawnedCollectibles = (List<CollectibleItem>)Tree.GetBlackboardData("spawnedCollectibles");
            object lastItem = Tree.GetBlackboardData("lastItem");

            bool tileWithColectible = false;

            if (lastItem != null)
            {
                Vector2Int lastItemLocation = (Vector2Int)lastItem;
                for (int i = 0; i < spawnedCollectibles.Count; i++)
                {
                    if (lastItemLocation == spawnedCollectibles[i].TileLocation)
                    {
                        tileWithColectible = true;
                        break;
                    }
                }
            }

            if ((Tree.Player.pathTilesQueue.Count == 0 || !tileWithColectible) && spawnedCollectibles.Count > 0 && Tree.Player.MovementTransitionFinished())
            {
                List<Vector2Int> shortestPath = Tree.Player.GetPathFromTo(Tree.Player.CurrentTile, spawnedCollectibles[0].TileLocation);

                for (int i = 1; i < spawnedCollectibles.Count; i++)
                {
                    List<Vector2Int> path = Tree.Player.GetPathFromTo(Tree.Player.CurrentTile, spawnedCollectibles[i].TileLocation);

                    if (shortestPath.Count > path.Count)
                    {
                        shortestPath = path;
                    }
                }

                shortestPath.ForEach(tile => Tree.Player.pathTilesQueue.Enqueue(tile));
                Tree.SetBlackboardData("lastItem", shortestPath[shortestPath.Count - 1]);
            }

            nodeState = NodeState.Success;

            return nodeState;
        }
    }
}
