// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

//------------------------------------------------------------------------------
// <copyright company="DMV">
//   Copyright 2015 Ded Medved
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using QuickGraph;


namespace Cheburashka.Utility_Classes
{
    public static class GraphCode
    {



        // bastardised sort-of Floyd-Warshal algorithm
        public static BidirectionalGraph<string, Edge<string>> ComputeTransitiveClosure(this BidirectionalGraph<string, Edge<string>> inputGraph, IEqualityComparer<string> comparer)
        {

            //This has been a bitch to do......................

            var transitiveClosure = inputGraph.Clone();

            var vertices = inputGraph.Vertices;
            var vertexStillChanging = vertices.ToDictionary((n => n), (n => true), comparer);        // create a dictionary of work-still-to-do by vertex

            var e = inputGraph.Edges;

            bool graphStillChanging = true;
            while (graphStillChanging)
            {
                foreach (var v in transitiveClosure.Vertices)
                {

                    // get vertices currently calculated to be reachable from v
                    // and get their successors.
                    // if this adds anything to the reachable set for this vertex
                    // mark it as still changing and update transitiveClosure with the new reachable set for this vertex.
                    // otherwise mark it as finished

                    var thisVertex = v;
                    if (vertexStillChanging[thisVertex])
                    {
                        var thisVertexCurrentClosureToVertices =
                            transitiveClosure.Edges.Where(n => comparer.Equals(n.Source,thisVertex)).Select(n => n.Target).ToArray();
                        var newEdges = new List<Edge<string>>();
                        foreach (
                            var additionalVertex in
                                inputGraph.Edges.Where(n => thisVertexCurrentClosureToVertices.Contains(n.Source,comparer))
                                    .Select(n => n.Target))
                        {
                            if (! thisVertexCurrentClosureToVertices.Contains(additionalVertex,comparer))
                            {
                                // We need to lookup the canonical vertex name from vertices, and use that in the inserted edge, as using the differently-cased version in the
                                // edges definition causes the edge insertion to fail (even though it shouldn't)
                                // consider it a bug in the Graph library.
                                var lookedUpAdditionalVertex = vertices.Where(n => comparer.Equals(n, additionalVertex)).Select(n => n).First();
                                newEdges.Add(new Edge<string>(thisVertex, lookedUpAdditionalVertex));
                            }
                        }
                        if ( newEdges.Count > 0 )
                        {
                            transitiveClosure.AddEdgeRange(newEdges);
                        }
                        else
                        {
                            vertexStillChanging[thisVertex] = false;
                        }

                    }
                }
                graphStillChanging = vertexStillChanging.Aggregate(false, (sum, n) => (sum == true || (n.Value)));
            }
            return transitiveClosure;
        }

        // bastardised sort-of Floyd-Warshal algorithm
        public static BidirectionalGraph<string, Edge<string>> ComputeTransitiveClosure(this BidirectionalGraph<string, Edge<string>> inputGraph)
        {
            var transitiveClosure = inputGraph.Clone();

            var vertices = inputGraph.Vertices;
            var vertexStillChanging = vertices.ToDictionary((n => n), (n => true));        // create a dictionary of work-still-to-do by vertex

            var e = inputGraph.Edges;

            bool graphStillChanging = true;
            while (graphStillChanging)
            {
                foreach (var v in transitiveClosure.Vertices)
                {

                    // get vertices currently calculated to be reachable from v
                    // and get their successors.
                    // if this adds anything to the reachable set for this vertex
                    // mark it as still changing and update transitiveClosure with the new reachable set for this vertex.
                    // otherwise mark it as finished

                    var thisVertex = v;
                    if (vertexStillChanging[thisVertex])
                    {
                        var thisVertexCurrentClosureToVertices =
                            transitiveClosure.Edges.Where(n => n.Source == thisVertex).Select(n => n.Target).ToArray();
                        var newEdges = new List<Edge<string>>();
                        foreach (
                            var additionalVertex in
                                inputGraph.Edges.Where(n => thisVertexCurrentClosureToVertices.Contains(n.Source))
                                    .Select(n => n.Target))
                        {
                            if (!thisVertexCurrentClosureToVertices.Contains(additionalVertex))
                            {
                                newEdges.Add(new Edge<string>(thisVertex, additionalVertex));
                            }
                        }
                        if (newEdges.Count > 0)
                        {
                            transitiveClosure.AddEdgeRange(newEdges);
                        }
                        else
                        {
                            vertexStillChanging[thisVertex] = false;
                        }

                    }
                }
                graphStillChanging = vertexStillChanging.Aggregate(false, (sum, n) => (sum == true || (n.Value)));
            }

            return transitiveClosure;

        }
    }
}
