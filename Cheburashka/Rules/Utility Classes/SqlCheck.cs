// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

//------------------------------------------------------------------------------
// <copyright company="DMV">
//   Copyright 2014 Ded Medved
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
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Cheburashka
{
    public static class SqlCheck
    {

        public static bool HasNoFromClause(MergeSpecification node)
        {
            //silence compiler warnings 
            if (node.FirstTokenIndex == 0) { }
            //return (node.TableSource is not null);
            return false;
        }
        public static bool HasNoFromClause(DeleteSpecification node)
        {
            return ((node.FromClause == null)
                    ||
                    ((node.FromClause is not null) &&
                      (node.FromClause.TableReferences.Count == 0)
                    )
                  );
        }
        public static bool HasNoFromClause(UpdateSpecification node)
        {
            return ((node.FromClause == null)
                    ||
                    ((node.FromClause is not null) &&
                      (node.FromClause.TableReferences.Count == 0)
                    )
                  );
        }
        public static bool HasNoFromClause(QuerySpecification node)
        {
            return ((node.FromClause == null)
                    ||
                    ((node.FromClause is not null) &&
                      (node.FromClause.TableReferences.Count == 0)
                    )
                  );
        }

        public static bool HasFromClause(MergeSpecification node)
        {
            return (!HasNoFromClause(node));
        }
        public static bool HasFromClause(DeleteSpecification node)
        {
            return (!HasNoFromClause(node));
        }
        public static bool HasFromClause(UpdateSpecification node)
        {
            return (!HasNoFromClause(node));
        }
        public static bool HasFromClause(QuerySpecification node)
        {
            return (!HasNoFromClause(node));
        }


        //public static bool HasOneFromClauseSource(MergeStatement node)
        //{
        //    //return (node.TableSource is not null);
        //    return true;
        //}
        //// tricky if there is no from clause there is still exactly one table involved
        //public static bool HasOneFromClauseSource(DeleteStatement node)
        //{
        //    return( ( node.FromClauses is not null ) && 
        //            ( node.FromClauses.Count == 1 )
        //          );
        //}
        //// tricky if there is no from clause there is still exactly one table involved
        //public static bool HasOneFromClauseSource(UpdateStatement node)
        //{
        //    return( ( node.FromClauses is not null ) && 
        //            ( node.FromClauses.Count == 1 )
        //          );
        //}
        //public static bool HasOneFromClauseSource(QuerySpecification node)
        //{
        //    return( ( node.FromClauses is not null ) && 
        //            ( node.FromClauses.Count == 1 )
        //          );
        //}

        public static bool HasExactlyOneFromClauseTableSource(MergeSpecification node)
        {
            //silence compiler warnings 
            if (node.FirstTokenIndex == 0) { }
            return false;
            //            return ((node.TableSource is not null) &&
            //                    (node.TableSource is Microsoft.Data.Schema.ScriptDom.Sql.TableSourceWithAlias)
            //                  );
        }
        // tricky if there is no from clause there is still exactly one table involved
        // in the context in which it is used - it literally means just the 1
        public static bool HasExactlyOneFromClauseTableSource(DeleteSpecification node)
        {
            return (((node.FromClause is not null) &&
                            (node.FromClause.TableReferences.Count == 1) &&
                            (node.FromClause.TableReferences[0] is TableReferenceWithAlias)
                        )
                  );
        }
        //// tricky if there is no from clause there is still exactly one table involved
        //// not used in any  context - eliminate for now
        //public static bool HasExactlyOneFromClauseTableSource(UpdateStatement node)
        //{
        //    return (((node.FromClauses is not null) &&
        //                    (node.FromClauses.Count == 1) &&
        //                    (node.FromClauses[0] is Microsoft.Data.Schema.ScriptDom.Sql.TableSourceWithAlias)
        //                )
        //          );
        //}
        public static bool HasExactlyOneFromClauseTableSource(QuerySpecification node)
        {
            return ((node.FromClause is not null) &&
                    (node.FromClause.TableReferences.Count == 1) &&
                    (node.FromClause.TableReferences[0] is TableReferenceWithAlias)
                  );
        }


        // For this helper method - at most means any table source at all
        // Semantics are shite aren't they
        public static bool HasAtMostOneTableSource(MergeSpecification node)
        {
            //silence compiler warnings 
            if (node.FirstTokenIndex == 0) { }
            //return (node.TableSource is not null);
            return false;
        }

        // tricky if there is no from clause there is still exactly one table involved
        public static bool HasAtMostOneTableSource(DeleteSpecification node)
        {
            return ((node.FromClause == null)
                     ||
                        ((node.FromClause is not null) &&
                           (node.FromClause.TableReferences.Count == 0)
                        )
                     ||
                        ((node.FromClause.TableReferences.Count == 1) &&
                           (node.FromClause.TableReferences[0] is TableReferenceWithAlias)
                        )
                  );
        }
        // tricky if there is no from clause there is still exactly one table involved
        public static bool HasAtMostOneTableSource(UpdateSpecification node)
        {
            return ((node.FromClause == null)
                     ||
                        ((node.FromClause is not null) &&
                           (node.FromClause.TableReferences.Count == 0)
                        )
                     ||
                        ((node.FromClause.TableReferences.Count == 1) &&
                           (node.FromClause.TableReferences[0] is TableReferenceWithAlias)
                        )
                  );
        }
        public static bool HasAtMostOneTableSource(QuerySpecification node)
        {
            return ((node.FromClause == null)
                     ||
                        ((node.FromClause is not null) &&
                           (node.FromClause.TableReferences.Count == 0)
                        )
                     ||
                        ((node.FromClause.TableReferences.Count == 1) &&
                           (node.FromClause.TableReferences[0] is TableReferenceWithAlias)
                        )
                  );
        }

        ////////////////////////////

        // For this helper method - at most means any table source at all
        // Semantics are shite aren't they
        public static bool HasAtLeastOneTableSource(MergeSpecification node)
        {
            //silence compiler warnings 
            if (node.FirstTokenIndex == 0) { }
            //return (node.TableSource is not null);
            return true;
        }

        // tricky if there is no from clause there is still exactly one table involved
        public static bool HasAtLeastOneTableSource(DeleteSpecification node)
        {
            //silence compiler warnings 
            if (node.FirstTokenIndex == 0) { }
            return true;
        }
        // tricky if there is no from clause there is still exactly one table involved
        public static bool HasAtLeastOneTableSource(UpdateSpecification node)
        {
            //silence compiler warnings 
            if (node.FirstTokenIndex == 0) { }
            return true;
        }
        public static bool HasAtLeastOneTableSource(QuerySpecification node)
        {
            return (((node.FromClause is not null) &&
                           (node.FromClause.TableReferences.Count > 0)
                        )
                  );
        }

        ////////////////////////////



        // leave unimplemented for now until we see how these changes pan out

        //public static bool HasNoIntoClause(QuerySpecification node)
        //{
        //    return ((node.Into == null)
        //            ||
        //              (
        //                (node.Into is not null) &&
        //                //                        (node.Into.BaseIdentifier.Value == "")
        //                (String.IsNullOrEmpty(node.Into.BaseIdentifier.Value))
        //              )
        //          );
        //}

        //public static bool HasIntoClause(QuerySpecification node)
        //{
        //    return !HasNoIntoClause(node);
        //}
    }
}