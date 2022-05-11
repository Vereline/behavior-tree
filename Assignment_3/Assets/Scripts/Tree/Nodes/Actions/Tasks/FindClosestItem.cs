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

            if (spawnedCollectibles.Count == 0)
            {
                nodeState = NodeState.Failure;
                Debug.Log("FindClosestItem returned " + nodeState);
                return nodeState;
            }

            List<Vector2Int> shortestPath = Tree.Player.GetPathFromTo(Tree.Player.CurrentTile, spawnedCollectibles[0].TileLocation);
            CollectibleItem closestCollectible = spawnedCollectibles[0];

            for (int i = 1; i < spawnedCollectibles.Count; i++)
            {
                List<Vector2Int> path = Tree.Player.GetPathFromTo(Tree.Player.CurrentTile, spawnedCollectibles[i].TileLocation);

                if (shortestPath.Count > path.Count)
                {
                    shortestPath = path;
                    closestCollectible = spawnedCollectibles[i];
                }
            }

            // shortestPath.ForEach(tile => Tree.Player.pathTilesQueue.Enqueue(tile));
            Tree.SetBlackboardData("shortestPath", shortestPath);
            Tree.SetBlackboardData("lastItem", closestCollectible);
            Tree.SetBlackboardData("itemType", closestCollectible.Type);
            Tree.SetBlackboardData("currentItemPosition", shortestPath[shortestPath.Count - 1]);

            nodeState = NodeState.Success;
            Debug.Log("FindClosestItem returned " + nodeState);
            return nodeState;
        }
    }
}
