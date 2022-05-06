using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class Task: TreeNode
    {
        public ComputerPlayer Player { get; set; } // the one who is going to perform a task

        public Task(BehaviourTree tree, TreeNode parent, ComputerPlayer player) : base(tree, parent)
        {
            Player = player;
        }

        public override NodeState Execute()
        {
            return NodeState.Success;
        }
    }
}
