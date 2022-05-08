using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class RepeateUntilFail: Decorator
    {
        public RepeateUntilFail(BehaviourTree tree, TreeNode parent, TreeNode child) : base(tree, parent, child)
        {

        }

        public override NodeState Execute()
        {

            Debug.Log("Repeater until fail returned ");
            //NodeState state = Child.Execute();
            //if (state == NodeState.Failure)
            //{
            //    nodeState = state;

            //} else
            //{
            //    nodeState = NodeState.Running;
            //}

            NodeState state;
            do
            {
                state = Child.Execute();
            } while (state != NodeState.Failure);

            nodeState = state;
            return nodeState;
        }
    }
}
