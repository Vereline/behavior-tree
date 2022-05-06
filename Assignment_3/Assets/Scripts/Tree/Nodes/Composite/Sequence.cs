using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class Sequence : Composite
    {
        public Sequence(BehaviourTree tree, TreeNode parent, TreeNode[] children) : base(tree, parent, children)
        {
 
        }

        public override NodeState Execute()
        {
            bool isRunning = false;

            foreach (TreeNode child in Children)
            {
                switch (child.Execute())
                {
                    case NodeState.Failure:
                        nodeState = NodeState.Failure;
                        return nodeState;
                    case NodeState.Success:
                        continue;
                    case NodeState.Running:
                        isRunning = true;
                        continue;
                    default:
                        nodeState = NodeState.Success;
                        return nodeState;
                }
            }

            nodeState = isRunning ? NodeState.Running : NodeState.Success;
            return nodeState;
        }
    }
}
