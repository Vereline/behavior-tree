using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class FollowPlayer: Task
    {
        public FollowPlayer(BehaviourTree tree, TreeNode parent, ComputerPlayer player) : base(tree, parent, player)
        {

        }

        public override NodeState Execute()
        {
            return NodeState.Success;
        }
    }
}
