using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraForUndirectedGraphs.Utilities
{
    public class Node
    {
        public int Vertex { get; set; }
        public int Weight { get; set; }
        public int QueuePosition { get; set; }
        public Node NextNode { get; set; }

        public Node(int vertex, int weight, int queue, Node next)
        {
            Vertex = vertex;
            Weight = weight;
            QueuePosition = queue;
            NextNode = next;
        }

        public Node()
        {
            
        }
    }
}
