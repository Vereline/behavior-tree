using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class RandomWalk: Task
    {
        public RandomWalk(BehaviourTree tree, TreeNode parent, ComputerPlayer player) : base(tree, parent, player)
        {

        }

        public override NodeState Execute()
        {
            return NodeState.Success;
        }
    }
}
