using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum NodeType : byte
{
    Action,
    Condition,
    Selector,
    Sequence
}

public enum NodeState : byte
{
    Idle,
    Running,
    Success,
    Failure,
    Interrupted,
}

namespace Assets.Scripts.Tree
{
    class TreeNode
    {
        public TreeNode parentNode;

        public LinkedList<TreeNode> children;

        public BehaviourTree Tree { get; set; }
        public NodeType nodeType { get; set; }
        public NodeState nodeState { get; set; }

        public bool isRoot = false;

        public TreeNode(BehaviourTree tree)
        {
            Tree = tree;
            nodeState = NodeState.Idle;

            //nodeType = type;
            //parentNode = parent;
            //isRoot = root;
        }

        public virtual NodeState Execute()
        {
            return NodeState.Idle;
        }
    }
}
