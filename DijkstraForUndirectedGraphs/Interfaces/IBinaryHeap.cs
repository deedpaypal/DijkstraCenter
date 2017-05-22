using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DijkstraForUndirectedGraphs.Utilities;

namespace DijkstraForUndirectedGraphs.Interfaces
{
    interface IBinaryHeap
    {
        void BuildHeap(Vertex[] minHeap, int size, int[] pos);
        Node AddEdge(Node next, int v, int w);
        void Heapify(Vertex[] minHeap, int size, int i, int[] pos);
        Vertex ExtractMin(Vertex[] minHeap, int size, int[] pos);
        void DecreaseKey(Vertex[] minHeap, Vertex newNode, int[] pos);
    }
}
