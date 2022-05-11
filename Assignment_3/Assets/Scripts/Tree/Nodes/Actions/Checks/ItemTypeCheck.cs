using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class ItemTypeCheck: Check
    {
        public CollectibleItemType desiredObjectType = CollectibleItemType.RespawnAll; 

        public ItemTypeCheck(BehaviourTree tree, TreeNode parent, TreeNode child, CollectibleItemType itemType) : base(tree, parent, child) {
            desiredObjectType = itemType;
            Debug.Log("ItemTypeCheck initiated");
        }

        public override bool CheckCondition(int time)
        {
            return true;
        }

        public override NodeState Execute()
        {
            CollectibleItemType itemType = (CollectibleItemType)Tree.GetBlackboardData("itemType");
            bool statusCheck = itemType == desiredObjectType ? true : false;
            
            Debug.Log("ItemTypeCheck status " + statusCheck.ToString());

            if (Child != null)
            {
                nodeState = statusCheck == true ? Child.Execute() : NodeState.Failure;
            } else
            {
                nodeState = statusCheck == true ? NodeState.Success : NodeState.Failure;
            }

            Debug.Log("ItemTypeCheck returned " + nodeState);

            return nodeState;
        }
    }
}
