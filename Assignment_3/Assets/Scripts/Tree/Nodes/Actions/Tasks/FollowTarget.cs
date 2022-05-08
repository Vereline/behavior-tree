using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class FollowTarget: Task
    {
        public FollowTarget(BehaviourTree tree, TreeNode parent) : base(tree, parent)
        {

        }

        public override NodeState Execute()
        {

            if (Tree.Player.pathTilesQueue.Count == 0 && Tree.Player.MovementTransitionFinished())
            {
                AbstractPlayer target = (AbstractPlayer)Tree.GetBlackboardData("target");

                if (Vector2Int.Distance(Tree.Player.CurrentTile, target.CurrentTile) > 1.0f)
                {
                    Tree.Player.pathTilesQueue.Clear();
                    List<Vector2Int> path = Tree.Player.GetPathFromTo(Tree.Player.CurrentTile, target.CurrentTile);
                    path.ForEach(tile => Tree.Player.pathTilesQueue.Enqueue(tile));
                }
            }
            
            nodeState = NodeState.Success;

            Debug.Log("Follow target returned " + nodeState);
            return nodeState;
        }
    }
}
