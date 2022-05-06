﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class MangoBehaviourTree : BehaviourTree
    {
        public override void InitTree()
        {
            Repeater root = new Repeater(this, null);
            Root.children.AddLast(root);
        }
    }
}
