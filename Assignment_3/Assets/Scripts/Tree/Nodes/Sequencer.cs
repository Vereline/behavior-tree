using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class Sequencer : Composite
    {
        private int currentNode = 0;
        public List<TreeNode> Children { get; set; }
        public Sequencer(BehaviourTree tree, TreeNode [] children) : base(tree, children) {
            Children = new List<TreeNode>(children);
        }

        public override NodeState Execute()
        {
            if (currentNode < Children.Count)
            {
                NodeState state = Children[currentNode].Execute();
                
                if (state == NodeState.Running)
                    return state;
                else if (state == NodeState.Failure) {
                    currentNode = 0;
                    return state;
                }
                else
                {
                    currentNode++;

                    if (currentNode < Children.Count)
                    {
                        return NodeState.Running;
                    } else
                    {
                        currentNode = 0;
                        return NodeState.Success;
                    }
                }
            }
             return NodeState.Success;
        }
    }
}
