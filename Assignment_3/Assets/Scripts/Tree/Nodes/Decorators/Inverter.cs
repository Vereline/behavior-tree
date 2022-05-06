using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class Inverter: Decorator
    {
        public Inverter(BehaviourTree tree, TreeNode child) : base(tree, child) {
            
        }

        public override NodeState Execute()
        {
            NodeState nodeState = Child.Execute();
            
            if (nodeState == NodeState.Success)
            {
                return NodeState.Failure;
            } else if (nodeState == NodeState.Failure)
            {
                return NodeState.Success;
            }

            return nodeState;
        }
    }
}
