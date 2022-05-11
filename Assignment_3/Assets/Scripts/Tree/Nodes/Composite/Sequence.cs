using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class Sequence : Composite
    {
        public Sequence(BehaviourTree tree, TreeNode parent, List<TreeNode> children) : base(tree, parent, children)
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
                        Debug.Log("Sequence returned " + nodeState);
                        return nodeState;
                    case NodeState.Success:
                        continue;
                    case NodeState.Running:
                        isRunning = true;
                        continue;
                    default:
                        nodeState = NodeState.Success;
                        Debug.Log("Sequence returned " + nodeState);
                        return nodeState;
                }
            }

            nodeState = isRunning ? NodeState.Running : NodeState.Success;

            Debug.Log("Sequence returned " + nodeState);
            return nodeState;
        }
    }
}
