using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class CollectCollectibleItem: Task
    {
        public CollectCollectibleItem(BehaviourTree tree, TreeNode parent) : base(tree, parent)
        {
            Debug.Log("CollectCollectibleItem initiated");
        }

        public override NodeState Execute()
        {
            CollectibleItem lastItem = (CollectibleItem)Tree.GetBlackboardData("lastItem");

            if (lastItem != null && Tree.Player.MovementTransitionFinished())
            {
                Tree.Player.pathTilesQueue.Clear();
                List<Vector2Int> shortestPath = (List<Vector2Int>)Tree.GetBlackboardData("shortestPath");
                shortestPath.ForEach(tile => Tree.Player.pathTilesQueue.Enqueue(tile));

                //                Tree.SetBlackboardData("runningTask", "CollectCollectibleItem");

                Debug.Log("CollectCollectibleItem path COUNT" + Tree.Player.pathTilesQueue.Count);
                nodeState = NodeState.Running;
                Debug.Log("CollectCollectibleItem returned " + nodeState);
                return nodeState;
            }

            nodeState = NodeState.Failure;
            Debug.Log("CollectCollectibleItem returned " + nodeState);

            return nodeState;
        }
    }
}
