using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DijkstraForUndirectedGraphs.Interfaces;
using DijkstraForUndirectedGraphs.Utilities;

namespace DijkstraForUndirectedGraphs.Analysis
{
    class Analyser : IAnalyser
    {
        public void Dijkstra(Node[] adjacencyList, int vertices, int start, int[] distances, int[] parent, int[][] dijkstraGraph)
        {
            BinaryHeap b = new BinaryHeap();
            Vertex minVertex;
            Vertex[] priorityQueue = new Vertex[vertices + 1];
            int[] pos = new int[vertices + 1];

            for (int j = 0; j <= vertices; ++j)
            {
                distances[j] = 2000000;
                parent[j] = 0;
                priorityQueue[j] = new Vertex(j, 2000000);
                pos[j] = priorityQueue[j].Vert;
            }
            distances[start] = 0;
            priorityQueue[start].Dist = 0;
            b.BuildHeap(priorityQueue, vertices, pos);
            for (int i = 1; i <= vertices; ++i)
            {
                minVertex = b.ExtractMin(priorityQueue, vertices, pos);

                Node trav = adjacencyList[minVertex.Vert];
                while (trav != null)
                {
                    int u = minVertex.Vert;
                    int v = trav.Vertex;
                    int w = trav.Weight;

                    if (distances[u] != 2000000 && distances[v] > distances[u] + w)
                    {
                        distances[v] = distances[u] + w;

                        parent[v] = u;
                        Vertex changedVertex = new Vertex();
                        changedVertex.Vert = v;
                        changedVertex.Dist = distances[v];
                        b.DecreaseKey(priorityQueue, changedVertex, pos);
                    }
                    trav = trav.NextNode;

                    if ((start - 1) != v - 1)
                    {
                        dijkstraGraph[start - 1][ v - 1] = distances[v];
                    }
                    else
                    {
                        dijkstraGraph[start - 1][ v - 1] = 0;
                    }
                }
            }
        }

        public int[] Excentricity(int[][] shortestPath)
        {
            int[] e = new int[shortestPath.Length];

            for (int i = 0; i < shortestPath.Length; i++)
            {
                for (int j = 0; j < shortestPath.Length; j++)
                {
                    e[i] = Math.Max(e[i], shortestPath[i][ j]);
                }
            }
            return e;
        }

        public IList<int> Centers(int[] excentricities)
        {
            excentricities = excentricities.Where(x => x != 0).ToArray();
            IList<int> centerList = new List<int>();
            for (int i = 0; i < excentricities.Length; ++i)
            {
                if (excentricities[i] == excentricities.Min())
                {
                    centerList.Add(i + 1);
                }
            }
            return centerList;
        }
    }
}
