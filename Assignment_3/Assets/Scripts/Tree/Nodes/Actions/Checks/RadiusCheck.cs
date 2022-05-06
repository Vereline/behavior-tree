using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class RadiusCheck : Check
    {
        public int desiredRadius = 15; 

        public RadiusCheck(BehaviourTree tree, TreeNode child, int radius) : base(tree, child) {
            desiredRadius = radius;
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
