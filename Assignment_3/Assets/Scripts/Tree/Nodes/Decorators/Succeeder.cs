using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class Succeeder: Decorator
    {
        public Succeeder(BehaviourTree tree, TreeNode parent, TreeNode child) : base(tree, parent, child)
        {

        }

        public override NodeState Execute()
        {
            NodeState state = Child.Execute();
            if (state == NodeState.Failure)
                nodeState = NodeState.Success;

            Debug.Log("Succeeder returned " + nodeState);
            return nodeState;
        }
    }
}
