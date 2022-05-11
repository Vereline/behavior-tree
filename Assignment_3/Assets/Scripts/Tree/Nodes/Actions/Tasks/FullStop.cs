using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class FullStop: Task
    {
        public FullStop(BehaviourTree tree, TreeNode parent) : base(tree, parent)
        {
            Debug.Log("FullStop initiated");

        }

        public override NodeState Execute()
        {

            Debug.Log("Inside FullStop returned " + NodeState.Success);


            Tree.Player.pathTilesQueue.Clear();
            Tree.SetBlackboardData("runningTask", "FullStop");

            nodeState = NodeState.Success;

            return nodeState;
        }
    }
}
