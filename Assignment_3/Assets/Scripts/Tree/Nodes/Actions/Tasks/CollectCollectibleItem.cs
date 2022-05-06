using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class CollectCollectibleItem: Task
    {
        private CollectibleItemType type;
        private Vector2Int collectibleItemLocation;

        public CollectCollectibleItem(BehaviourTree tree) : base(tree)
        {

        }

        public void FindCollectibleItemOnMap()
        {
           
        }

        public override NodeState Execute()
        {
            //if (Tree.character.currentPosition == collectibleItemLocation)
            //{
            //    if (!FindCollectibleItemOnMap())
            //    {
            //        return NodeState.Failure;
            //    }
            //    else
            //    {
            //        return NodeState.Success;
            //    }
            //} else { // TODO make runnung return NodeState.Running}

            // TEMP 
            return NodeState.Running;
        }
    }
}
