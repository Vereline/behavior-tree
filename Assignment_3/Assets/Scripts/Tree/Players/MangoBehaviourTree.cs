using System;
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
        public MangoBehaviourTree(ComputerPlayer computerPlayer) : base(computerPlayer)
        {

        }
        public override void InitTree()
        {
            Selector selector = new Selector(this, null, new List<TreeNode>());

            Sequence sequence1 = new Sequence(this, null, new List<TreeNode>());
            Sequence sequence2 = new Sequence(this, null, new List<TreeNode>());

            Inverter inverter = new Inverter(this, null, null);
            RepeateUntilFail repeateUntilFail = new RepeateUntilFail(this, null, null);

            Sequence sequence3 = new Sequence(this, null, new List<TreeNode>());
            sequence3.AttachChild(new FindClosestItem(this, null));
            sequence3.AttachChild(new ItemTypeCheck(this, null, null, CollectibleItemType.RespawnAll));
            sequence3.AttachChild(new ReduceItem(this, null));

            repeateUntilFail.AttachChild(sequence3);
            inverter.AttachChild(repeateUntilFail);

            sequence1.AttachChild(new TimeCheck(this, null, null, Player.GameLengthSeconds - 15));
            sequence1.AttachChild(inverter);
            sequence1.AttachChild(new CollectCollectibleItem(this, null));


            sequence2.AttachChild(new FindClosestItem(this, null));
            sequence2.AttachChild(new CollectCollectibleItem(this, null));

            selector.AttachChild(sequence1);
            selector.AttachChild(sequence2);

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
