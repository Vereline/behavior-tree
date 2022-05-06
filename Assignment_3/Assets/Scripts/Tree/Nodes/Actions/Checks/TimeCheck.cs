using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class TimeCheck: Check
    {
        public int desiredTime = 15; 

        public TimeCheck(BehaviourTree tree, TreeNode parent, TreeNode child, ComputerPlayer player, int time) : base(tree, parent, child, player) {
            desiredTime = time;
        }

        public override bool CheckCondition(int time)
        {
            if (desiredTime >= time)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
