using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _802FindEventualSafeStates
    {
        public void Test()
        {
            //Case 1
            int[][] graph = [[1, 2], [2, 3], [5], [0], [5], [], []];
            Program.PrintCollection(EventualSafeNodes(graph));

            //Case 2
            graph = [[1, 2, 3, 4], [1, 2], [3, 4], [0, 4], []];
            Program.PrintCollection(EventualSafeNodes(graph));
        }
        //GPT提供的解法，Rumtime: 31ms
        //public IList<int> EventualSafeNodes(int[][] graph)
        //{
        //    int n = graph.Length;

        //    List<int>[] reverseGraph = new List<int>[n];
        //    for (int i = 0; i < n; i++)
        //        reverseGraph[i] = new List<int>();

        //    int[] indegree = new int[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        foreach (int neighbor in graph[i])
        //        {
        //            reverseGraph[neighbor].Add(i);
        //            indegree[i]++;
        //        }
        //    }

        //    Queue<int> queue = new Queue<int>();
        //    for (int i = 0; i < n; i++)
        //        if (indegree[i] == 0)
        //            queue.Enqueue(i);

        //    List<int> safeNodes = new List<int>();
        //    while (queue.Count > 0)
        //    {
        //        int node = queue.Dequeue();
        //        safeNodes.Add(node);
        //        foreach (int neighbor in reverseGraph[node])
        //        {
        //            indegree[neighbor]--;
        //            if (indegree[neighbor] == 0)
        //            {
        //                queue.Enqueue(neighbor);
        //            }
        //        }
        //    }

        //    safeNodes.Sort();
        //    return safeNodes;
        //}

        //Rumtime: 7ms
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            int n = graph.Length;

            List<int> safeNodes = new List<int>();
            int[] stage = new int[n];
            bool DFS(int cur)
            {
                if (stage[cur] != 0) return (stage[cur] == 2);

                stage[cur] = 1;
                foreach (int neighbor in graph[cur])
                    if (!DFS(neighbor)) return false;

                stage[cur] = 2;
                return true;
            }

            for (int i = 0; i < n; i++)
                if (DFS(i)) safeNodes.Add(i);

            return safeNodes;
        }
    }
}