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

        public TimeCheck(BehaviourTree tree, TreeNode child, int time) : base(tree, child) {
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
