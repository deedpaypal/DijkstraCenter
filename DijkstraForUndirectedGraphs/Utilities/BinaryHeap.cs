using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DijkstraForUndirectedGraphs.Interfaces;

namespace DijkstraForUndirectedGraphs.Utilities
{

    public class BinaryHeap : IBinaryHeap
    {
        public void BuildHeap(Vertex[] minHeap, int size, int[] pos)
        {
            for (int i = size / 2; i >= 1; --i)
            {
                Heapify(minHeap, size, i, pos);
            }
        }

        public Node AddEdge(Node next, int v, int w)
        {
            Node nextNode = new Node();
            nextNode.NextNode = next;
            nextNode.Vertex = v;
            nextNode.Weight = w;
            return nextNode;
        }

        public void Heapify(Vertex[] minHeap, int size, int i, int[] pos)
        {
            Vertex temp;
            while ((2 * i) <= size)
            {
                if ((2 * i) + 1 > size)
                {
                    if (minHeap[i].Dist > minHeap[2 * i].Dist)
                    {
                        pos[minHeap[i].Vert] = 2 * i;
                        pos[minHeap[2 * i].Vert] = i;

                        temp = minHeap[i];
                        minHeap[i] = minHeap[2 * i];
                        minHeap[2 * i] = temp;
                    }
                    break;
                }
                if (minHeap[i].Dist > minHeap[2 * i].Dist || minHeap[i].Dist > minHeap[2 * i + 1].Dist)
                {
                    if (minHeap[2 * i].Dist <= minHeap[(2 * i) + 1].Dist)
                    {
                        pos[minHeap[i].Vert] = 2 * i;
                        pos[minHeap[2 * i].Vert] = i;

                        temp = minHeap[2 * i];
                        minHeap[2 * i] = minHeap[i];
                        minHeap[i] = temp;

                        i = 2 * i;
                    }
                    else if (minHeap[2 * i].Dist > minHeap[(2 * i) + 1].Dist)
                    {
                        pos[minHeap[i].Vert] = 2 * i + 1;
                        pos[minHeap[2 * i + 1].Vert] = i;

                        temp = minHeap[(2 * i) + 1];
                        minHeap[(2 * i) + 1] = minHeap[i];
                        minHeap[i] = temp;

                        i = (2 * i) + 1;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public Vertex ExtractMin(Vertex[] minHeap, int size, int[] pos)
        {
            pos[minHeap[1].Vert] = size;
            pos[minHeap[size].Vert] = 1;
            Vertex min = minHeap[1];
            minHeap[1] = minHeap[size];
            --size;
            Heapify(minHeap, size, 1, pos);
            return min;
        }

        public void DecreaseKey(Vertex[] minHeap, Vertex newNode, int[] pos)
        {
            minHeap[pos[newNode.Vert]].Dist = newNode.Dist;

            int i = pos[newNode.Vert];

            Vertex temp;

            while (i > 1)
            {
                if (minHeap[i / 2].Dist > minHeap[i].Dist)
                {
                    pos[minHeap[i].Vert] = i / 2;
                    pos[minHeap[i / 2].Vert] = i;

                    temp = minHeap[i / 2];
                    minHeap[i / 2] = minHeap[i];
                    minHeap[i] = temp;

                    i = i / 2;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
