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
            //Repeater treeRoot = new Repeater(this, null, null);
            //treeRoot.AttachChild(new RandomWalk(this, root, Player));

            // works
            //RandomWalk randomWalknew = new RandomWalk(this, root);

            // works
            //FollowTarget ft = new FollowTarget(this, root);

            FindClosestItem ft = new FindClosestItem(this, root);

            //if (c.GetType() == typeof(TForm))

            //treeRoot.AttachChild(randomWalknew);
            root = ft;
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
