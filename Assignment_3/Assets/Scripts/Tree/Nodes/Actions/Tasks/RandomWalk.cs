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
            // get random point (max 1 step)
            // go to it
            // get new random point
            if (Tree.Player.MovementTransitionFinished())
            {
                Maze maze = (Maze)Tree.GetBlackboardData("maze");
                Vector2Int destTile = new Vector2Int();
                do
                {
                    // absolute random position in a range
                    destTile.x = random.Next(maze.MazeTiles[0].Count);
                    destTile.y = random.Next(maze.MazeTiles.Count);

                    // random position in range 1 tile
                    //destTile.x = random.Next(Tree.Player.CurrentTile.x - 2, Tree.Player.CurrentTile.x + 2);
                    //destTile.y = random.Next(Tree.Player.CurrentTile.y - 2, Tree.Player.CurrentTile.y + 2);
                } while (!maze.IsAccessibleTile(destTile));

                List<Vector2Int> path = Tree.Player.GetPathFromTo(Tree.Player.CurrentTile, destTile);

                Tree.Player.pathTilesQueue.Clear();
                path.ForEach(tile => Tree.Player.pathTilesQueue.Enqueue(tile));
                nodeState = NodeState.Running;
            } else
            {
                // the path was composed and we assume that character is already moving
                nodeState = NodeState.Failure;
            }
            Debug.Log("Random walk returned " + nodeState);
            return nodeState;
        }
    }
}
