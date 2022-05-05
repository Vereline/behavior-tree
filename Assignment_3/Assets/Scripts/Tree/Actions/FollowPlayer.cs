using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class FollowPlayer: TreeNode
    {
        private ComputerPlayer player;


        public FollowPlayer(BehaviourTree tree) : base(tree)
        {

        }

        public virtual NodeState Execute()
        {
            return NodeState.Success;
        }
    }
}
