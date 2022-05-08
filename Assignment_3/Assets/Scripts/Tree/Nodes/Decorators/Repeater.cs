using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class Repeater: Decorator
    {
        public Repeater(BehaviourTree tree, TreeNode parent, TreeNode child) : base(tree, parent, child) {
            Debug.Log("Repeater initiated");
        }

        public override NodeState Execute()
        {
            int? repeats = (int)Tree.GetBlackboardData("repeats");

            if (repeats != null)
            {
                NodeState state = nodeState;
                
                for (int i = 0; i < repeats; i++)
                {
                    state = Child.Execute();
                }

                nodeState = state;
                return nodeState;
            } else
            {
                while (true)
                {
                    Child.Execute();
                }
            }
            
            //Debug.Log("Repeater returned " + Child.Execute());
            //nodeState = NodeState.Running;
            //return nodeState;
        }
    }
}
