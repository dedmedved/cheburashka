﻿//------------------------------------------------------------------------------
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using QuickGraph;


namespace Cheburashka.Utility_Classes
{
    public static class GraphCode
    {

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
                            if (! thisVertexCurrentClosureToVertices.Contains(additionalVertex))
                            {
                                newEdges.Add(new Edge<string>(thisVertex, additionalVertex));
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
    }
}