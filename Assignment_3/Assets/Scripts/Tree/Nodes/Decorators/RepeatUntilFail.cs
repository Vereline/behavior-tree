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
            Debug.Log("Repeater returned " + Child.Execute());
            return NodeState.Running;
        }
    }
}
