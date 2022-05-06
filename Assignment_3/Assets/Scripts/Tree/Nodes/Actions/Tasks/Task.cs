using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class Task: TreeNode
    {
        public Task(BehaviourTree tree) : base(tree)
        {

        }

        public override NodeState Execute()
        {
            return NodeState.Success;
        }
    }
}
