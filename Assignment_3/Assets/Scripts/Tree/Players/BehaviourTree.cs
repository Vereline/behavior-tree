using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree
{
    class BehaviourTree: MonoBehaviour
    {
        private TreeNode root;
        private ComputerPlayer character;

        public ComputerPlayer Character { get { return character; } }

        public LinkedList<TreeNode> nodes;
        public bool started = false;
        public Dictionary<string, object> Blackboard { get; set; }
        public TreeNode Root { get { return root; } }
        private Coroutine behavior;

        private void Start()
        {
            Blackboard = new Dictionary<string, object>();
            SetBlackboardData("InitTree", null);
            InitTree();

            //root = new TreeNode(this);
            started = false;
        }

        private void Update()
        {
            if (!started)
            {
                behavior = StartCoroutine(RunBehaviourTree());
                started = true;
            }

        }

        public void SetBlackboardData(string key, object value)
        {
            Blackboard[key] = value;
        }

        public void ClearData(string key)
        {
            if (Blackboard.ContainsKey(key))
            {
                Blackboard.Remove(key);
            }
        }

        private IEnumerator RunBehaviourTree()
        {
            NodeState state = Root.Execute();
            while (state == NodeState.Running)
            {
                Debug.Log("Doing Something. State " + state);
                yield return null;
                state = Root.Execute();
            }

            Debug.Log("Behaviour finished. State " + state);
        }


        //public void InsertNode()
        //{

        //}

        public virtual void InitTree()
        {

        }

        //public void RemoveNode()
        //{

        //}
        //public void SearchNode()
        //{

        //}

        //public void GetBehaviorString()
        //{

        //}
    }
}
