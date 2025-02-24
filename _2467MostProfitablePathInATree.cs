using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Program;

namespace Leetcode
{
    internal class _2467MostProfitablePathInATree
    {
        public void Test()
        {
            //Case 1
            int[][] edges = [[0, 1], [1, 2], [1, 3], [3, 4]];
            int bob = 3;
            int[] amount = [-2, 4, 2, -4, 6];
            Console.WriteLine(MostProfitablePath(edges, bob, amount));

            //Case 2
            edges = [[0, 1]];
            bob = 1;
            amount = [-7280, 2350];
            Console.WriteLine(MostProfitablePath(edges, bob, amount));

            //Case 3
            edges = [[0, 2], [0, 5], [1, 3], [1, 5], [2, 4]];
            bob = 4;
            amount = [5018, 8388, 6224, 3466, 3808, 3456];
            Console.WriteLine(MostProfitablePath(edges, bob, amount));

            //Case 4
            edges = [[0, 1], [0, 2]];
            bob = 2;
            amount = [-3360, -5394, -1146];
            Console.WriteLine(MostProfitablePath(edges, bob, amount));

            //Case 5
            edges = [[0, 2], [1, 4], [1, 6], [2, 4], [3, 6], [3, 7], [5, 7]];
            bob = 4;
            amount = [-6896, -1216, -1208, -1108, 1606, -7704, -9212, -8258];
            Console.WriteLine(MostProfitablePath(edges, bob, amount));
        }
        public int MostProfitablePath(int[][] edges, int bob, int[] amount)
        {
            int n = amount.Length;
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();

            // 建立树结构
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            // 找到 Bob 到根节点的路径
            int[] bobTime = new int[n];
            Array.Fill(bobTime, int.MaxValue);
            FindBobPath(bob, 0, graph, bobTime, 0, new HashSet<int>());

            // 计算 Alice 的最大收益
            return DFS(0, -1, graph, amount, bobTime, 0);
        }

        private bool FindBobPath(int curr, int target, List<int>[] graph, int[] bobTime, int time, HashSet<int> visited)
        {
            if (curr == target)
            {
                bobTime[curr] = time;
                return true;
            }

            visited.Add(curr);
            foreach (int next in graph[curr])
            {
                if (!visited.Contains(next) && FindBobPath(next, target, graph, bobTime, time + 1, visited))
                {
                    bobTime[curr] = time;
                    return true;
                }
            }
            visited.Remove(curr);
            return false;
        }

        private int DFS(int curr, int parent, List<int>[] graph, int[] amount, int[] bobTime, int time)
        {
            int income = 0;
            if (time < bobTime[curr]) income += amount[curr];
            else if (time == bobTime[curr]) income += amount[curr] / 2;

            int maxProfit = int.MinValue;
            bool isLeaf = true;

            foreach (int next in graph[curr])
            {
                if (next == parent) continue;
                isLeaf = false;
                maxProfit = Math.Max(maxProfit, DFS(next, curr, graph, amount, bobTime, time + 1));
            }

            return income + (isLeaf ? 0 : maxProfit);
        }

        //fail
        //public int MostProfitablePath(int[][] edges, int bob, int[] amount)
        //{
        //    List<int>[] graph = new List<int>[amount.Length];

        //    //1. amount length
        //    //2. edges length
        //    //3. current route count of graph[i]
        //    int n = amount.Length;
        //    for (int i = 0; i < n; i++)
        //    {
        //        graph[i] = new List<int>();
        //    }
        //    n = edges.Length;
        //    for (int i = 0; i < n; i++)
        //    {
        //        graph[edges[i][0]].Add(edges[i][1]);
        //        graph[edges[i][1]].Add(edges[i][0]);
        //    }

        //    Stack<int> stack = new Stack<int>();
        //    HashSet<int> visited = new HashSet<int>();
        //    int[] startIndex = new int[amount.Length];
        //    stack.Push(bob);
        //    visited.Add(bob);
        //    int bobNode;
        //    while (stack.Peek() != 0)
        //    {
        //        bobNode = stack.Peek();
        //        for (int i = startIndex[bobNode]; i < graph[bobNode].Count;i++)
        //        {
        //            if (!visited.Contains(graph[bobNode][i]))
        //            {
        //                startIndex[bobNode] = i;
        //                visited.Add(graph[bobNode][i]);
        //                stack.Push(graph[bobNode][i]);
        //                break;
        //            }
        //        }

        //        if (bobNode == stack.Peek())
        //        {
        //            stack.Pop();
        //        }
        //    }
        //    PrintArray(startIndex);

        //    Queue<(int id, int income)> queue = new Queue<(int id, int income)>();//branch of alice node
        //    queue.Enqueue((0, amount[0]));
        //    int posibility = queue.Count;
        //    int maxIncome = int.MinValue;
        //    int route;
        //    bobNode = bob;
        //    visited = new HashSet<int>();
        //    while (posibility > 0)
        //    {
        //        for (int i = 0; i < posibility; i++)
        //        {
        //            int id = queue.Peek().id;
        //            int income = queue.Dequeue().income;

        //            if (id == bobNode)
        //            {
        //                income -= amount[id] / 2;
        //                visited.Add(id);
        //            }
        //            else if (!visited.Contains(bobNode))
        //            {
        //                amount[bobNode] = 0;
        //                bobNode = graph[bobNode][startIndex[bobNode]];
        //                visited.Add(id);
        //            }

        //            if (graph[id].Count == 0)
        //            {
        //                maxIncome = int.Max(maxIncome, income);
        //                continue;
        //            }

        //            n = graph[id].Count;
        //            for (int j = 0; j < n; j++)
        //            {
        //                route = graph[id][j];
        //                queue.Enqueue((route, income + amount[route]));
        //                graph[route].Remove(id);
        //            }
        //        }
        //        posibility = queue.Count;
        //    }

        //    return maxIncome;
        //}
    }
}