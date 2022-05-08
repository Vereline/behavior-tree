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
        public Inverter(BehaviourTree tree, TreeNode parent, TreeNode child) : base(tree, parent, child) {
            
        }

        public override NodeState Execute()
        {
            NodeState state = Child.Execute();
            
            if (state == NodeState.Success)
            {
                nodeState = NodeState.Failure;
                
            } else if (state == NodeState.Failure)
            {
                nodeState = NodeState.Success;
            }

            return nodeState;
        }
    }
}
