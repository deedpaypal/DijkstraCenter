using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraForUndirectedGraphs.Utilities
{
    public class Vertex
    {
        public int Vert { get; set; }
        public int Dist { get; set; }

        public Vertex(int vertex, int dist)
        {
            Vert = vertex;
            Dist = dist;
        }

        public Vertex()
        {
            
        }
    }
}
