using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class ReduceItem: Task
    {

        private System.Random random;
        public ReduceItem(BehaviourTree tree, TreeNode parent) : base(tree, parent)
        {
            random = new System.Random();
            Debug.Log("ReduceItem initiated");
        }

        public override NodeState Execute()
        {
            CollectibleItem lastItem = (CollectibleItem)Tree.GetBlackboardData("lastItem");
            List<CollectibleItem> spawnedCollectibles = (List<CollectibleItem>)Tree.GetBlackboardData("spawnedCollectibles");

            if (lastItem != null && spawnedCollectibles.Contains(lastItem))
            {
                spawnedCollectibles.Remove(lastItem);

                SetBlackboardData("lastItem", null);
                SetBlackboardData("spawnedCollectibles", spawnedCollectibles);
                nodeState = NodeState.Success;

                Debug.Log("ReduceItem returned " + nodeState);
                return nodeState;
            }

            nodeState = NodeState.Failure;
            
            Debug.Log("ReduceItem returned " + nodeState);
            return nodeState;
        }
    }
}
