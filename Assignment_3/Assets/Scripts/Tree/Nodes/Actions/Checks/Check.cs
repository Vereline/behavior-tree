using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class Check : TreeNode
    {
        public TreeNode Child { get; set; }
        public ComputerPlayer Player { get; set; } // the one for whom we are checking the 

        public Check(BehaviourTree tree, TreeNode parent, TreeNode child, ComputerPlayer player) : base(tree, parent)
        {
            Child = child;
            Debug.Log("Check initiated");
        }

        public void AttachChild(TreeNode node)
        {
            node.parentNode = this;
            Child = node;
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
