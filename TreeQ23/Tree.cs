using System;
using System.Collections.Generic;

namespace TreeQ23
{
    class Branch
    {
        public List<Branch> branches;
    }


    class Tree
    {
        readonly Branch tree = null;

        private int _answer = 0;
        private int MaxDepth
        {
            set
            {
                if(_answer < value)
                {
                    _answer = value;
                }
            }
        }

        public Tree()
        {
            tree = BuildTree();
        }

        public void GetDepth()
        {
            SolveDepth(new List<Branch> { tree }, 0);
            Console.WriteLine("the trees maximum depth is: " + _answer);
        }

        private void SolveDepth(IList<Branch> currentNodes, int currentDepth)
        {
            List<Branch> nextRoundNodes = new();

            int activeDepth = currentDepth + 1;
            foreach(var node in currentNodes)
            {
                if(node.branches != null)
                {
                    nextRoundNodes.Clear();
                    nextRoundNodes.AddRange(node.branches);
                }
            }

            if(nextRoundNodes.Count != 0)
            {
                currentDepth++;
                SolveDepth(nextRoundNodes, currentDepth);
            }
            MaxDepth = activeDepth;
        }

        private static Branch BuildTree()
        {
            IList<Branch> node = new List<Branch>();

            for(int i = 0; i < 11; i++)
            {
                node.Add(new Branch());
            }

            AddNode(node[0], new[] { node[1], node[2] });
            AddNode(node[1], new[] { node[3] });
            AddNode(node[2], new[] { node[4], node[5], node[6] });
            AddNode(node[4], new[] { node[7] });
            AddNode(node[5], new[] { node[8], node[9] });
            AddNode(node[8], new[] { node[10] });

            return node[0];
        }

        private static void AddNode(Branch parent, Branch[] children)
        {
            parent.branches = new();
            for(int i = 0; i < children.Length; i++)
            {
                parent.branches.Add(children[i]);
            }
        }
    }
}
