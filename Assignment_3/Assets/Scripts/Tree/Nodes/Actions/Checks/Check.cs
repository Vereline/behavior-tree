using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class Check : TreeNode
    {
        public TreeNode Child { get; set; }

        public Check(BehaviourTree tree, TreeNode child) : base(tree) {
            Child = child;
        }

        public virtual bool CheckCondition()
        {
            return true;
        }

        public virtual bool CheckCondition(int value)
        {
            return true;
        }
    }
}
