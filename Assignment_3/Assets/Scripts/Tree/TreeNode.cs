using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum NodeType : byte
{
    Action,
    Condition,
    Selector,
    Sequence
}

namespace Assets.Scripts.Tree
{
    class TreeNode
    {
        public NodeType nodeType;
    }
}
