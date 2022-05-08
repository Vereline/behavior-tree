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
        public int desiredRadius = 15; 

        public RadiusCheck(BehaviourTree tree, TreeNode parent, TreeNode child, ComputerPlayer player, int radius) : base(tree, parent, child, player) {
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
    }
}
