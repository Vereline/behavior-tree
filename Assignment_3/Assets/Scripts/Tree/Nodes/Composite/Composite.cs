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
        public Composite(BehaviourTree tree, TreeNode parent, TreeNode[] children) : base(tree, parent) {
            Children = new List<TreeNode>();

            foreach (TreeNode child in children)
            {
                AttachChild(child);
            }
        }

        public void AttachChild(TreeNode node)
        {
            node.parentNode = this;
            Children.Add(node);
        }
    }
}
