using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class Decorator: TreeNode
    {
        public TreeNode Child { get; set; }
        public Decorator(BehaviourTree tree, TreeNode child) : base(tree) {
            Child = child;
        }
    }
}
