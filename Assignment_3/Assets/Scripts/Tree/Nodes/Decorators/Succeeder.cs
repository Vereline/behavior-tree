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
        public Succeeder(BehaviourTree tree, TreeNode child) : base(tree, child) {
            
        }

        public override NodeState Execute()
        {
            Debug.Log("Succeeder returned" + Child.Execute());
            return NodeState.Success;
        }
    }
}
