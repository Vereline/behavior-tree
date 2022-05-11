using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class DjangoBehaviourTree : BehaviourTree
    {
        public DjangoBehaviourTree(ComputerPlayer computerPlayer): base(computerPlayer)
        {

        }

        public override void InitTree()
        {
            // TREE
            Selector selector = new Selector(this, null, new List<TreeNode>());

            Sequence sequence = new Sequence(this, null, new List<TreeNode>());

            RadiusCheck rc = new RadiusCheck(this, sequence, null, 3);
 
            sequence.AttachChild(new FindClosestItem(this, sequence));
            sequence.AttachChild(rc);
            sequence.AttachChild(new CollectCollectibleItem(this, null));

            selector.AttachChild(sequence);
            selector.AttachChild(new FollowTarget(this, root));

            root = selector;

        }

        public override void PrepareBlackboardData()
        {
            
            // Move this stuff to the node 
            List<AbstractPlayer> players = (List<AbstractPlayer>)GetBlackboardData("players");
            foreach (AbstractPlayer player in players)
            {
                if (player.GetType() == typeof(HumanPlayer))
                {
                    SetBlackboardData("target", player);
                    break;
                }
            }
        }
    }
}
