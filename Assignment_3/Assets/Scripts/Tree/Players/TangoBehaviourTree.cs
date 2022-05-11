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
            Selector selector = new Selector(this, null, new List<TreeNode>());

            Sequence sequence1 = new Sequence(this, null, new List<TreeNode>());

            Inverter inverter = new Inverter(this, null, null);
            inverter.AttachChild(new TimeCheck(this, null, null, Player.GameLengthSeconds - 30));

            sequence1.AttachChild(inverter);
            sequence1.AttachChild(new FindClosestItem(this, null));
            sequence1.AttachChild(new ItemTypeCheck(this, null, null, CollectibleItemType.IncreaseMovementSpeed));
            sequence1.AttachChild(new CollectCollectibleItem(this, null));

            Sequence sequence2 = new Sequence(this, null, new List<TreeNode>());
            sequence2.AttachChild(new FindClosestItem(this, null));
            sequence2.AttachChild(new ItemTypeCheck(this, null, null, CollectibleItemType.RespawnAll));
            sequence2.AttachChild(new CollectCollectibleItem(this, null));

            selector.AttachChild(sequence1);
            selector.AttachChild(sequence2);
            selector.AttachChild(new RandomWalk(this, root));
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
