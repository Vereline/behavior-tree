using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum NodeState : byte
{
    //Idle,
    Running,
    Success,
    Failure,
    //Interrupted,
}

namespace Assets.Scripts.Tree
{
    class TreeNode
    {
        public TreeNode parentNode;

        public LinkedList<TreeNode> children;

        public BehaviourTree Tree { get; set; }
        public NodeState nodeState { get; set; }

        public bool isRoot = false;

        public TreeNode(BehaviourTree tree, TreeNode parent)
        {
            Tree = tree;
            if (parent != null)
            {
                parentNode = parent;
            }
            //nodeState = NodeState.Idle;

            //isRoot = root;
        }

        public virtual NodeState Execute()
        {
            return NodeState.Failure;
        }

        public void SetBlackboardData(string key, object value)
        {
            Tree.SetBlackboardData(key, value);
        }
    }
}
