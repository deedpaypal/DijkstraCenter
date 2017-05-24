using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DijkstraForUndirectedGraphs.Analysis;
using DijkstraForUndirectedGraphs.Utilities;
using DijkstraForUndirectedGraphs.Utilities.Matrix;
using DijkstraForUndirectedGraphs.Utilities.MatrixPrinter;

namespace DijkstraForUndirectedGraphs
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Input amount of vertexes");
            int sizeOfGraph = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input amount of graphs");
            int amountOfGraphs = Convert.ToInt32(Console.ReadLine());

            //среднее количество секунд на один граф
            double sWatch = 0.0;

            //проход по всем рандомным графам, количество которых amountOfGraphs
            for (int z = 0; z < amountOfGraphs; z++)
            {
                MatrixGenerator m = new MatrixGenerator(sizeOfGraph);
                int[][] graph = m.GetLowRarefactionMatrix();
                //MatrixPrinter.Print(graph);

                int vertices = graph.GetLength(0);

                Node[] adjacencyList = new Node[vertices + 1];
                int[] distances = new int[vertices + 1];
                int[] parent = new int[vertices + 1];
                BinaryHeap b = new BinaryHeap();
                Analyser a = new Analyser();
                int[][] shortestPath = new int[vertices][];
                for (int i = 0; i < graph.Length; i++)
                {
                    shortestPath[i] = new int[graph.Length];
                }

                List<int> vertexes = new List<int>();
                for (int i = 0; i < vertices; i++)
                {
                    for (int j = 0; j < vertices; j++)
                    {
                        if (!vertexes.Contains(i + 1))
                        {
                            vertexes.Add(i + 1);
                            vertexes.Sort();
                        }
                        if (graph[i][j] != 0)
                        {
                            adjacencyList[i + 1] = b.AddEdge(adjacencyList[i + 1], j + 1, graph[i][j]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }


                Stopwatch sw = new Stopwatch();

                //включаем счетчик
                sw.Start();
                foreach (var vertex in vertexes)
                {
                    int startVertex = vertex;

                    a.Dijkstra(adjacencyList, vertices, startVertex, distances, parent, shortestPath);

                }

                Console.WriteLine("-----SHORTEST PATH----");

                //MatrixPrinter.Print(shortestPath);
                int[] exc = a.Excentricity(shortestPath);
                IList<int> centers = a.Centers(exc);
                sw.Stop();
                //прибвляем к общему времени время, затраченное на текущий граф
                sWatch = sWatch + sw.Elapsed.TotalSeconds;

                //время затраченное на текущий граф
                Console.WriteLine();

                foreach (var center in centers)
                {
                    Console.Write(center + " ");
                }
                Console.WriteLine("Time for a single graph {0}", sw.Elapsed.TotalSeconds);

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //среднее время
            Console.WriteLine("Average time for graph, which has a {0} vertexes: {1}", amountOfGraphs, sWatch / amountOfGraphs);
            Console.ReadLine();
        }
    }
}