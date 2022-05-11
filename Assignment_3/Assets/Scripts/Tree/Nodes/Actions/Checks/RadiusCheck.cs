using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class RadiusCheck : Check
    {
        public int desiredRadius = 5; 

        public RadiusCheck(BehaviourTree tree, TreeNode parent, TreeNode child, int radius) : base(tree, parent, child) {
            desiredRadius = radius;
            Debug.Log("RadiusCheck initiated");
        }

        public override bool CheckCondition(int radius)
        {
            if (desiredRadius >= radius)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public override NodeState Execute()
        {
            // TEMP
            SetBlackboardData("currentPlayerPosition", Tree.Player.CurrentTile);

            Vector2Int currentItemPosition = (Vector2Int)Tree.GetBlackboardData("currentItemPosition");
            Vector2Int currentPlayerPosition = (Vector2Int)Tree.GetBlackboardData("currentPlayerPosition");
            bool statusCheck = CheckCondition((int)Vector2Int.Distance(currentPlayerPosition, currentItemPosition));

            Debug.Log("RadiusCheck status " + statusCheck.ToString());

            if (Child != null)
            {
                nodeState = statusCheck == true ? Child.Execute() : NodeState.Failure;
            }
            else
            {
                nodeState = statusCheck == true ? NodeState.Success : NodeState.Failure;
            }

            Debug.Log("RadiusCheck returned " + nodeState);
            return nodeState;
        }
    }
}
