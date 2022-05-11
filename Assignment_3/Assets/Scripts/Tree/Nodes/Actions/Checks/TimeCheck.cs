using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class TimeCheck: Check
    {
        public float desiredTime = 15; 

        public TimeCheck(BehaviourTree tree, TreeNode parent, TreeNode child, float time) : base(tree, parent, child) {
            desiredTime = time;
            Debug.Log("TimeCheck initiated");
        }

        public override bool CheckCondition(float time)
        {
            if (desiredTime >= time)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public override NodeState Execute()
        {
            float time = (float)Tree.GetBlackboardData("remainingGameTime");
            bool statusCheck = CheckCondition(time);
            
            Debug.Log("TimeCheck status " + statusCheck.ToString());

            if (Child != null)
            {
                nodeState = statusCheck == true ? Child.Execute() : NodeState.Failure;
            }
            else
            {
                nodeState = statusCheck == true ? NodeState.Success : NodeState.Failure;
            }

            Debug.Log("TimeCheck returned " + nodeState);

            return nodeState;
        }
    }
}
