using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tree
{
    class CollectCollectibleItem: TreeNode
    {
        private CollectibleItemType type;


        public CollectCollectibleItem(BehaviourTree tree) : base(tree)
        {

        }

        public virtual NodeState Execute()
        {
            return NodeState.Success;
        }
    }
}
