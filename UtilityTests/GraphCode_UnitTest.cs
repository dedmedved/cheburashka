// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cheburashka.Utility_Classes;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;



namespace UtilityTests
{
    [TestClass]
    public class GraphCode_UnitTest
    {
        public sealed class FileDotEngine : IDotEngine
        {
            public string Run(GraphvizImageType imageType, string dot, string outputFileName)
            {
                string output = outputFileName;
                File.WriteAllText(output, dot);

                // assumes dot.exe is on the path:
                var args = string.Format(@"{0} -Tjpg -O", output);
                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe", args);
                return output;
            }
        }

        [TestMethod]
        public void ComputeTransitiveClosure_EmptyGraph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>();
            var g2 = GraphCode.ComputeTransitiveClosure(g1);
            Assert.AreEqual(g1.VertexCount, 0);
            Assert.AreEqual(g2.VertexCount, 0);
            Assert.AreEqual(g1.EdgeCount, 0);
            Assert.AreEqual(g2.EdgeCount, 0);
        }
        [TestMethod]
        public void ComputeTransitiveClosure_OneNodeGraph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>();
            g1.AddVertex("A");
            var g2 = GraphCode.ComputeTransitiveClosure(g1);
            Assert.AreEqual(g1.VertexCount, 1);
            Assert.AreEqual(g2.VertexCount, 1);
            Assert.AreEqual(g1.EdgeCount, 0);
            Assert.AreEqual(g2.EdgeCount, 0);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g1;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb1");

        }
        [TestMethod]
        public void ComputeTransitiveClosure_OneNode_SelfEdge_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>();
            g1.AddVertex("A");
            g1.AddEdge(new Edge<string>("A", "A"));
            var g2 = GraphCode.ComputeTransitiveClosure(g1);
            Assert.AreEqual(g1.VertexCount, 1);
            Assert.AreEqual(g2.VertexCount, 1);
            Assert.AreEqual(g1.EdgeCount, 1);
            Assert.AreEqual(g2.EdgeCount, 1);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g1;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb1_1");

        }
        [TestMethod]
        public void ComputeTransitiveClosure_TwoNodeGraph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>();
            g1.AddVertex("A");
            g1.AddVertex("B");
            var g2 = GraphCode.ComputeTransitiveClosure(g1);
            Assert.AreEqual(g1.VertexCount, 2);
            Assert.AreEqual(g2.VertexCount, 2);
            Assert.AreEqual(g1.EdgeCount, 0);
            Assert.AreEqual(g2.EdgeCount, 0);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g1;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb2");

        }
        [TestMethod]
        public void ComputeTransitiveClosure_TwoNode_One_Edge_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>();
            g1.AddVertex("A");
            g1.AddVertex("B");
            g1.AddEdge(new Edge<string>("A", "B"));
            var g2 = GraphCode.ComputeTransitiveClosure(g1);
            Assert.AreEqual(g1.VertexCount, 2);
            Assert.AreEqual(g2.VertexCount, 2);
            Assert.AreEqual(g1.EdgeCount, 1);
            Assert.AreEqual(g2.EdgeCount, 1);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g1;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb2_2");

        }
        [TestMethod]
        public void ComputeTransitiveClosure_TwoNode_Two_Edge_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>();
            g1.AddVertex("A");
            g1.AddVertex("B");
            g1.AddEdge(new Edge<string>("A", "B"));
            g1.AddEdge(new Edge<string>("B", "A"));
            var g2 = GraphCode.ComputeTransitiveClosure(g1);
            Assert.AreEqual(g1.VertexCount, 2);
            Assert.AreEqual(g2.VertexCount, 2);
            Assert.AreEqual(g1.EdgeCount, 2);
            Assert.AreEqual(g2.EdgeCount, 4);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g2;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb2_4");

        }
        [TestMethod]
        public void ComputeTransitiveClosure_ThreeNode_Two_Edge_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>();
            g1.AddVertex("A");
            g1.AddVertex("B");
            g1.AddVertex("C");
            g1.AddEdge(new Edge<string>("A", "B"));
            g1.AddEdge(new Edge<string>("B", "C"));
            var g2 = GraphCode.ComputeTransitiveClosure(g1);
            Assert.AreEqual(g1.VertexCount, 3);
            Assert.AreEqual(g2.VertexCount, 3);
            Assert.AreEqual(g1.EdgeCount, 2);
            Assert.AreEqual(g2.EdgeCount, 3);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g2;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb3_0");

        }
        [TestMethod]
        public void ComputeTransitiveClosure_ThreeNode_Three_Edge_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>();
            g1.AddVertex("A");
            g1.AddVertex("B");
            g1.AddVertex("C");
            g1.AddEdge(new Edge<string>("A", "B"));
            g1.AddEdge(new Edge<string>("B", "C"));
            g1.AddEdge(new Edge<string>("C", "A"));
            var g2 = GraphCode.ComputeTransitiveClosure(g1);
            Assert.AreEqual(g1.VertexCount, 3);
            Assert.AreEqual(g2.VertexCount, 3);
            Assert.AreEqual(g1.EdgeCount, 3);
            Assert.AreEqual(g2.EdgeCount, 9);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g2;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb3_9");

        }
        [TestMethod]
        public void ComputeTransitiveClosure_ThreeNode_No_Edge_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>(false, -1, -1, StringComparer.InvariantCulture);
            g1.AddVertex("A");
            g1.AddVertex("B");
            g1.AddVertex("C");
            var g2 = GraphCode.ComputeTransitiveClosure(g1, StringComparer.InvariantCulture);
            Assert.AreEqual(g1.VertexCount, 3);
            Assert.AreEqual(g2.VertexCount, 3);
            Assert.AreEqual(g1.EdgeCount, 0);
            Assert.AreEqual(g2.EdgeCount, 0);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g2;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb3_0");

        }
        [TestMethod]
        public void ComputeTransitiveClosure_ThreeNode_Three_Edge_MixedCase_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>(false, -1, -1, StringComparer.InvariantCultureIgnoreCase);
            g1.AddVertex("A");
            g1.AddVertex("B");
            g1.AddVertex("C");
            g1.AddEdge(new Edge<string>("a", "B"));
            g1.AddEdge(new Edge<string>("B", "C"));
            g1.AddEdge(new Edge<string>("C", "a"));
            var g2 = GraphCode.ComputeTransitiveClosure(g1, StringComparer.InvariantCultureIgnoreCase);
            Assert.AreEqual(g1.VertexCount, 3);
            Assert.AreEqual(g2.VertexCount, 3);
            Assert.AreEqual(g1.EdgeCount, 3);
            Assert.AreEqual(g2.EdgeCount, 9);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g2;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb3_9");


        }

        [TestMethod]
        public void ComputeTransitiveClosure_ThreeNode_Three_Edge_MixedCase_2_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>(false, -1, -1, StringComparer.InvariantCultureIgnoreCase);
            g1.AddVertex("A");
            g1.AddVertex("B");
            g1.AddVertex("C");
            g1.AddEdge(new Edge<string>("a", "b"));
            g1.AddEdge(new Edge<string>("b", "c"));
            g1.AddEdge(new Edge<string>("c", "a"));
            var g2 = GraphCode.ComputeTransitiveClosure(g1, StringComparer.InvariantCultureIgnoreCase);
            Assert.AreEqual(g1.VertexCount, 3);
            Assert.AreEqual(g2.VertexCount, 3);
            Assert.AreEqual(g1.EdgeCount, 3);
            Assert.AreEqual(g2.EdgeCount, 9);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g2;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb3_9");


        }

        [TestMethod]
        public void ComputeTransitiveClosure_ThreeNode_Three_Edge_MixedCase_3_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>(false, -1, -1, StringComparer.InvariantCultureIgnoreCase);
            g1.AddVertex("A");
            g1.AddVertex("b");
            g1.AddVertex("C");
            g1.AddEdge(new Edge<string>("A", "b"));
            g1.AddEdge(new Edge<string>("B", "C"));
            g1.AddEdge(new Edge<string>("c", "a"));
            var g2 = GraphCode.ComputeTransitiveClosure(g1, StringComparer.InvariantCultureIgnoreCase);
            Assert.AreEqual(g1.VertexCount, 3);
            Assert.AreEqual(g2.VertexCount, 3);
            Assert.AreEqual(g1.EdgeCount, 3);
            Assert.AreEqual(g2.EdgeCount, 9);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g2;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb3_9");


        }

        [TestMethod]
        public void ComputeTransitiveClosure_ThreeNode_Three_Edge_MixedCase_4_Graph()
        {
            var g1 = new BidirectionalGraph<String, Edge<String>>(false, -1, -1, StringComparer.InvariantCultureIgnoreCase);
            g1.AddVertex("A one");
            g1.AddVertex("b TWO");
            g1.AddVertex("C three");
            g1.AddEdge(new Edge<string>("A ONE", "b two"));
            g1.AddEdge(new Edge<string>("B two", "c THREE"));
            g1.AddEdge(new Edge<string>("c three", "a ONE"));
            var g2 = GraphCode.ComputeTransitiveClosure(g1, StringComparer.InvariantCultureIgnoreCase);
            Assert.AreEqual(g1.VertexCount, 3);
            Assert.AreEqual(g2.VertexCount, 3);
            Assert.AreEqual(g1.EdgeCount, 3);
            Assert.AreEqual(g2.EdgeCount, 9);

            //IVertexAndEdgeListGraph<string, Edge<string>> g = g2;
            //var gviz = new GraphvizAlgorithm<string, Edge<string>>(g);
            //string s = gviz.Generate(new FileDotEngine(), @"C:\temp\mb3_9");


        }

    }
}
