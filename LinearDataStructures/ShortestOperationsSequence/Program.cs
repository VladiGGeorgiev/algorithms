using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestOperationsSequence
{
    class Program
    {
        static int n = 5;
        static int m = 30;
        static Queue<int[]> queue = new Queue<int[]>();
        static Stack<int> current = new Stack<int>();

        static void Main(string[] args)
        {
            Queue<int> operationsSequence = new Queue<int>();
            
            Tree tree = new Tree(n);
            var realTree = CreateTree(tree, n, m);

            DFS(realTree.Root);

            var orderedOperations = queue.OrderBy(x => x.Count());
            int minPathLength = orderedOperations.First().Count();
            var minPaths = orderedOperations.Where(x => x.Count() == minPathLength);

            foreach (var path in minPaths)
            {
                var currentPath = path.Reverse();
                foreach (var num in currentPath)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }

        private static void DFS(TreeNode node)
        {
            current.Push(node.Value);
            if (node.Value == m)
            {
                queue.Enqueue(current.ToArray());
            }
            foreach (var child in node.Children)
            {
                DFS(child);
            }
            current.Pop();
        }
  
        private static Tree CreateTree(Tree tree, int n, int m)
        {
            int currentElement = n;

            if (currentElement > m)
            {
                return tree;
            }

            Tree currentChild = new Tree(currentElement * 2);
            if (currentElement * 2 <= m)
            {
                var currentTree = CreateTree(currentChild, currentElement * 2, m);
                tree.Root.AddChild(currentTree);
            }

            currentChild = new Tree(currentElement + 2);
            if (currentElement + 2 <= m )
            {
                var currentTree = CreateTree(currentChild, currentElement + 2, m);
                tree.Root.AddChild(currentTree);
            }

            currentChild = new Tree(currentElement + 1);
            if (currentElement + 1 <= m)
            {
                var currentTree = CreateTree(currentChild, currentElement + 1, m);
                tree.Root.AddChild(currentTree);   
            }

            return tree;
        }
    }
}
