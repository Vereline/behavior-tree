using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class Selector : Composite
    {
        public Selector(BehaviourTree tree, TreeNode parent, List<TreeNode> children) : base(tree, parent, children)
        {
 
        }

        public override NodeState Execute()
        {
            foreach (TreeNode child in Children)
            {
                switch (child.Execute())
                {
                    case NodeState.Failure:
                        continue;
                    case NodeState.Success:
                        nodeState = NodeState.Success;
                        Debug.Log("Selector returned " + nodeState);
                        return nodeState;
                    case NodeState.Running:
                        nodeState = NodeState.Running;
                        Debug.Log("Selector returned " + nodeState);
                        return nodeState;
                    default:
                        continue;
                }
            }

            nodeState = NodeState.Failure;

            Debug.Log("Selector returned " + nodeState);
            return nodeState;
        }
    }
}
