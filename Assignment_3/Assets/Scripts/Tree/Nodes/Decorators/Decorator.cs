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
        public Decorator(BehaviourTree tree, TreeNode parent, TreeNode child) : base(tree, parent) {
            
        }

        public virtual void AttachChild(TreeNode node)
        {
            node.parentNode = this;
            Child = node;
        }
    }
}
