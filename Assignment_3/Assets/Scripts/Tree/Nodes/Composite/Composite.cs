using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class Composite : TreeNode
    {
        public List<TreeNode> Children { get; set; }
        public Composite(BehaviourTree tree, TreeNode [] children) : base(tree) {
            Children = new List<TreeNode>(children);
        }
    }
}
