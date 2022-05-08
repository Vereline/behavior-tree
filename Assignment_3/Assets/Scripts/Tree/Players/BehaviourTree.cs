using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class BehaviourTree
    {
        protected TreeNode root;
        private ComputerPlayer player;

        public ComputerPlayer Player { get { return player; } }

        public Dictionary<string, object> Blackboard { get; set; }
        public TreeNode Root { get { return root; } }
        
        public BehaviourTree(ComputerPlayer computerPlayer)
        {
            player = computerPlayer;
            Blackboard = new Dictionary<string, object>();
            Debug.Log("Tree initiate started");
            
            InitTree();

            Debug.Log("Tree initiated");

        }

        public void SetBlackboardData(string key, object value)
        {
            Blackboard[key] = value;
        }

        public object GetBlackboardData(string key)
        {
            Blackboard.TryGetValue(key, out object value);
            return value;
        }

        public void ClearData(string key)
        {
            if (Blackboard.ContainsKey(key))
            {
                Blackboard.Remove(key);
            }
        }

        public void RunBehaviourTree(Maze maze, List<AbstractPlayer> players, List<CollectibleItem> spawnedCollectibles, float remainingGameTime)
        {
            SetBlackboardData("maze", maze);
            SetBlackboardData("players", players);
            SetBlackboardData("spawnedCollectibles", spawnedCollectibles);
            SetBlackboardData("remainingGameTime", remainingGameTime);

            PrepareBlackboardData();

            Debug.Log("Start execution");

            NodeState state = Root.Execute();

            Debug.Log("Behaviour finished. State " + state);
        }

        public virtual void PrepareBlackboardData()
        {

        }

        public virtual void InitTree()
        {

        }
    }
}
