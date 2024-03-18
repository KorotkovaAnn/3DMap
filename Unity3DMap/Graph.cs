using System;
namespace Unity3DMap
{
    public class Graph
    {
        public List<Point> points = new List<Point>();
        public List<Edge> edges = new List<Edge>();

        public double[,] Matrix;

        public Graph(List<Point> points, List<Edge> edges)
        {
            this.points = points;
            this.edges = edges;
            Matrix = new double[points.Count, points.Count];
        }

        public void CreateGraph()
        {
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    var edge = edges.FirstOrDefault(e =>
                    {
                        return e.First == points[i] && e.Second == points[j] || e.Second == points[i] && e.First == points[j];
                    });
                    if (edge != null)
                    {
                        Matrix[i, j] = edge.Length;
                    }
                    else
                    {
                        Matrix[i, j] = 0;
                    }

                }
            }
        }

        public void PrintGraph()
        {
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    Console.Write(string.Format("{0:f1}", Matrix[i, j] + "\t"));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}

