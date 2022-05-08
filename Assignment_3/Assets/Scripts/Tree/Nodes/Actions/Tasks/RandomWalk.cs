using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class RandomWalk: Task
    {

        private System.Random random;
        public RandomWalk(BehaviourTree tree, TreeNode parent) : base(tree, parent)
        {
            random = new System.Random();
            Debug.Log("Random initiated");
        }

        public override NodeState Execute()
        {
            // get random point
            // go to it
            // get new random point
            
            if (Tree.Player.pathTilesQueue.Count == 0 && Tree.Player.MovementTransitionFinished())
            {

                Maze maze = (Maze)Tree.GetBlackboardData("maze");
                Vector2Int destTile = new Vector2Int();
                nodeState = NodeState.Running;
                do
                {
                    destTile.x = random.Next(maze.MazeTiles[0].Count);
                    destTile.y = random.Next(maze.MazeTiles.Count);
                } while (!maze.IsAccessibleTile(destTile));

                List<Vector2Int> path = Tree.Player.GetPathFromTo(Tree.Player.CurrentTile, destTile);

                //Player.pathTilesQueue.Clear();
                path.ForEach(tile => Tree.Player.pathTilesQueue.Enqueue(tile));
                nodeState = NodeState.Success;
            } else
            {
                // the path was composed and we assume that character is already moving
                nodeState = NodeState.Success;
            }
            Debug.Log("Random walk returned " + nodeState);
            return nodeState;
        }
    }
}
