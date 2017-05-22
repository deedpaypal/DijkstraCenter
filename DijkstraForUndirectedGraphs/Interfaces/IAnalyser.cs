using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DijkstraForUndirectedGraphs.Utilities;

namespace DijkstraForUndirectedGraphs.Interfaces
{
    interface IAnalyser
    {
        void Dijkstra(Node[] adjacencyList, int vertices, int start, int[] distances, int[] parent, int[][] dijkstraGraph);
        int[] Excentricity(int[][] shortestPath);
        IList<int> Centers(int[] excentricities);
    }
}
