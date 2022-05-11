using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class Task: TreeNode
    {
        public Task(BehaviourTree tree, TreeNode parent) : base(tree, parent)
        {
        }

        public override NodeState Execute()
        {
            nodeState = NodeState.Success;
            return nodeState;
        }
    }
}
