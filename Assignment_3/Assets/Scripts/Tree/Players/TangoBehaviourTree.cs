using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class TangoBehaviourTree : BehaviourTree
    {
        public TangoBehaviourTree(ComputerPlayer computerPlayer) : base(computerPlayer)
        {

        }

        public override void InitTree()
        {
            Repeater root = new Repeater(this, null, null);
            Root.children.AddLast(root);
        }
    }
}
