﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

//------------------------------------------------------------------------------
// <copyright company="Microsoft">
//   Copyright 2013 Microsoft
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
using System.IO;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cheburashka.Tests
{
    /// <summary>
    /// Basic test cases to validate the rule samples.
    /// Many test cases have be extended to use baselines as this can make validation easier - baselined rule tests
    /// support converting a set of input TSQL scripts into a model, running analysis against this and then comparing the
    /// results to an expected baseline. The first time you add a test and run analysis you would verify the output created
    /// looks correct, and if this is true you would update your baseline file to match this.
    /// </summary>
    [TestClass]
    public class RuleTestCases
    {
        /// <summary>
        /// TestContext for a test is automatically inserted by the unit test framework
        /// </summary>
        public TestContext TestContext
        {
            get;
            set;
        }


        /// <summary>
        /// This test exists to 'warm-up' the system and to prevent any one real set of tests from appearing to run slowly.
        /// This test uses input scripts saved in the "TestScripts\_startup" folder and compares the
        /// results to the "_startup-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void _startup()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidBareReturnRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidBareReturnRule.RuleId);
            }
        }


        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidBareReturnRule" folder and compares the
        /// results to the "AvoidBareReturnRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void TestAvoidBareReturn_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidBareReturnRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidBareReturnRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidBareReturnRule" folder and compares the
        /// results to the "AvoidBareReturnRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void TestAvoidBareReturn_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidBareReturnRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidBareReturnRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidGotoRule" folder and compares the
        /// results to the "AvoidGotoRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidGoto_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidGotoRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidGotoRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidGotoRule" folder and compares the
        /// results to the "AvoidGotoRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidGoto_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidGotoRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidGotoRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidDirectUseOfRowcountRule" folder and compares the
        /// results to the "AvoidDirectUseOfRowcountRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidDirectUseOfRowcount_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidDirectUseOfRowcountRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidDirectUseOfRowcountRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidDirectUseOfRowcountRule" folder and compares the
        /// results to the "AvoidDirectUseOfRowcountRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidDirectUseOfRowcount_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidDirectUseOfRowcountRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidDirectUseOfRowcountRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceCaptureSPReturnStatusRule" folder and compares the
        /// results to the "EnforceCaptureSPReturnStatusRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceCaptureSPReturnStatus_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceCaptureSPReturnStatusRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceCaptureSPReturnStatusRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceCaptureSPReturnStatusRule" folder and compares the
        /// results to the "EnforceCaptureSPReturnStatusRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceCaptureSPReturnStatus_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceCaptureSPReturnStatusRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceCaptureSPReturnStatusRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceTryCatchRule" folder and compares the
        /// results to the "EnforceTryCatchRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceUseTRY_CATCH_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceTryCatchRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceTryCatchRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceTryCatchRule" folder and compares the
        /// results to the "EnforceTryCatchRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceUseTRY_CATCH_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceTryCatchRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceTryCatchRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceReturnRule" folder and compares the
        /// results to the "EnforceReturnRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceReturn_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceReturnRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceReturnRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceReturnRule" folder and compares the
        /// results to the "EnforceReturnRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceReturn_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceReturnRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceReturnRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUnusedVariables" folder and compares the
        /// results to the "AvoidUnusedVariables-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnusedVariables_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidUnusedVariablesRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUnusedVariablesRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUnusedVariables" folder and compares the
        /// results to the "AvoidUnusedVariables-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnusedVariables_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidUnusedVariablesRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUnusedVariablesRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUnusedTableVariableRule" folder and compares the
        /// results to the "AvoidUnusedTableVariableRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnusedTableVariable_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidUnusedTableVariableRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUnusedTableVariableRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUnusedTableVariableRule" folder and compares the
        /// results to the "AvoidUnusedTableVariableRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnusedTableVariable_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidUnusedTableVariableRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUnusedTableVariableRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUnusedTableVariable_MixedCaseVariableNamesRule" folder and compares the
        /// results to the "AvoidUnusedTableVariable_MixedCaseVariableNamesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnusedTableVariable_MixedCaseVariableNames_CI_AI()     // As this is unused variables a mixed case scenario make little sense anyway
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                //                nameof(AvoidUnusedTableVariableRule),
                "AvoidUnusedTableVariable_MixedCaseVariableNamesRule",
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" }, // no BIN case for obvious reasons
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUnusedTableVariableRule.RuleId);
            }
        }


        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUnusedParameterRule" folder and compares the
        /// results to the "AvoidUnusedParameterRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnusedParameter_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidUnusedParameterRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUnusedParameterRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUnusedParameterRule" folder and compares the
        /// results to the "AvoidUnusedParameterRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnusedParameter_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidUnusedParameterRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUnusedParameterRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUnusedParameter_MixedCaseVariableNamesRule" folder and compares the
        /// results to the "AvoidUnusedParameter_MixedCaseVariableNamesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnusedParameter_MixedCaseVariableNames_CI_AI()     // As this is unused variables a mixed case scenario make little sense anyway
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                //                nameof(AvoidUnusedParameterRule),
                "AvoidUnusedParameter_MixedCaseVariableNamesRule",
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },  // no BIN test cases for obvious reasons
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUnusedParameterRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidWriteOnlyVariablesRule" folder and compares the
        /// results to the "AvoidWriteOnlyVariablesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidWriteOnlyVariables_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidWriteOnlyVariablesRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidWriteOnlyVariablesRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidWriteOnlyVariablesRule" folder and compares the
        /// results to the "AvoidWriteOnlyVariablesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidWriteOnlyVariables_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidWriteOnlyVariablesRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidWriteOnlyVariablesRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidWriteOnlyVariables_MixedCaseVariableNamesRule" folder and compares the
        /// results to the "AvoidWriteOnlyVariables_MixedCaseVariableNamesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidWriteOnlyVariables_MixedCaseVariableNames_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                //nameof(AvoidWriteOnlyVariablesRule),
                "AvoidWriteOnlyVariables_MixedCaseVariableNamesRule",
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },  // obviously can't test the BIN case
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidWriteOnlyVariablesRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUninitialisedVariablesRule" folder and compares the
        /// results to the "AvoidUninitialisedVariablesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnitialisedVariables_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidUninitialisedVariablesRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUninitialisedVariablesRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUninitialisedVariablesRule" folder and compares the
        /// results to the "AvoidUninitialisedVariablesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnitialisedVariables_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidUninitialisedVariablesRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUninitialisedVariablesRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidUninitialisedVariables_MixedCaseVariableNamesRule" folder and compares the
        /// results to the "AvoidUninitialisedVariables_MixedCaseVariableNamesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidUnitialisedVariables_MixedCaseVariableNames_CI_AI()        // NO _BIN test cases for obvious reasons
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                //nameof(AvoidUninitialisedVariablesRule),
                "AvoidUninitialisedVariables_MixedCaseVariableNamesRule",
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100
            ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidUninitialisedVariablesRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidOnePartNamesRule" folder and compares the
        /// results to the "AvoidOnePartNamesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidOnePartNames_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidOnePartNamesRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidOnePartNamesRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidOnePartNamesRule" folder and compares the
        /// results to the "AvoidOnePartNamesRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidOnePartNames_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidOnePartNamesRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidOnePartNamesRule.RuleId);
            }
        }


        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforcePrimaryKeyRule" folder and compares the
        /// results to the "EnforcePrimaryKeyRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforcePrimaryKey_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforcePrimaryKeyRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforcePrimaryKeyRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforcePrimaryKeyRule" folder and compares the
        /// results to the "EnforcePrimaryKeyRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforcePrimaryKey_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforcePrimaryKeyRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforcePrimaryKeyRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceNamedConstraintRule" folder and compares the
        /// results to the "EnforceNamedConstraintRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceNamedConstraint_BIN() {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceNamedConstraintRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql110
                )) {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceNamedConstraintRule.RuleId);
            }
        }

            /// <summary>
            /// This test uses input scripts saved in the "TestScripts\EnforceNamedConstraintRule" folder and compares the
            /// results to the "EnforceNamedConstraintRule-Baseline.txt file in that directory. If you wanted to add extra test cases
            /// just add in new sql files and run the test. The failure message will include links to the output file - if all
            /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
            /// 
            /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
            /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
            /// </summary>
            [TestMethod]
            public void EnforceNamedConstraint_CI_AI() {
                using (BaselinedRuleTest test = new BaselinedRuleTest(
                    TestContext,
                    nameof(EnforceNamedConstraintRule),
                    new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                    SqlServerVersion.Sql110
                    )) {
                    // Since this test verifies results against a baseline file, we don't need to do any extra verification
                    test.RunTest(EnforceNamedConstraintRule.RuleId);
                }
            }
        

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceClusteredIndexRule" folder and compares the
        /// results to the "EnforceClusteredIndexRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceClusteredIndex_BIN() {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceClusteredIndexRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql110
                )) {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceClusteredIndexRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceClusteredIndexRule" folder and compares the
        /// results to the "EnforceClusteredIndexRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceClusteredIndex_CI_AI() {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceClusteredIndexRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                )) {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceClusteredIndexRule.RuleId);
            }
        }


        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueConstraintHasNoNullColumnsRule" folder and compares the
        /// results to the "CheckUniqueConstraintHasNoNullColumnsRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckUniqueConstraintHasNoNullColumns_BIN() {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(CheckUniqueConstraintHasNoNullColumnsRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql110
                )) {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckUniqueConstraintHasNoNullColumnsRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueIndexHasNoNullColumnsRule" folder and compares the
        /// results to the "CheckUniqueIndexHasNoNullColumnsRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckUniqueConstraintHasNoNullColumns_CI_AI() {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(CheckUniqueConstraintHasNoNullColumnsRule),
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                )) {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckUniqueConstraintHasNoNullColumnsRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueIndexHasNoNullColumns_MixedCaseRule" folder and compares the
        /// results to the "CheckUniqueIndexHasNoNullColumnsRule_MixedCase-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckUniqueConstraintHasNoNullColumns_MixedCase_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                "CheckUniqueConstraintHasNoNullColumns_MixedCaseRule",
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckUniqueConstraintHasNoNullColumnsRule.RuleId);
            }
        }


        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueIndexHasNoNullColumnsRule" folder and compares the
        /// results to the "CheckUniqueIndexHasNoNullColumnsRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckUniqueIndexHasNoNullColumns_BIN() {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(CheckUniqueIndexHasNoNullColumnsRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql110
                )) {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckUniqueIndexHasNoNullColumnsRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueIndexHasNoNullColumnsRule" folder and compares the
        /// results to the "CheckUniqueIndexHasNoNullColumnsRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckUniqueIndexHasNoNullColumns_CI_AI() {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(CheckUniqueIndexHasNoNullColumnsRule),
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                )) {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckUniqueIndexHasNoNullColumnsRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueIndexHasNoNullColumns_MixedCaseRule" folder and compares the
        /// results to the "CheckUniqueIndexHasNoNullColumns_MixedCaseRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckUniqueIndexHasNoNullColumns_MixedCase_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                "CheckUniqueIndexHasNoNullColumns_MixedCaseRule",
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckUniqueIndexHasNoNullColumnsRule.RuleId);
            }
        }


        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckClusteredKeyColumnsNotIncludedInIndexRule" folder and compares the
        /// results to the "CheckClusteredKeyColumnsNotIncludedInIndexRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckClusteredKeyColumnsNotIncludedInIndex_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(CheckClusteredKeyColumnsNotIncludedInIndexRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckClusteredKeyColumnsNotIncludedInIndexRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckClusteredKeyColumnsNotIncludedInIndexRule" folder and compares the
        /// results to the "CheckClusteredKeyColumnsNotIncludedInIndexRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckClusteredKeyColumnsNotIncludedInIndex_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(CheckClusteredKeyColumnsNotIncludedInIndexRule),
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckClusteredKeyColumnsNotIncludedInIndexRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueKeysAreNotDuplicatedRule" folder and compares the
        /// results to the "CheckUniqueKeysAreNotDuplicatedRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckUniqueKeysAreNotDuplicatedRule_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(CheckUniqueKeysAreNotDuplicatedRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckUniqueKeysAreNotDuplicatedRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueKeysAreNotDuplicatedRule" folder and compares the
        /// results to the "CheckUniqueKeysAreNotDuplicatedRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckUniqueKeysAreNotDuplicatedRule_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(CheckUniqueKeysAreNotDuplicatedRule),
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckUniqueKeysAreNotDuplicatedRule.RuleId);
            }
        }


        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueKeysAreNotDuplicatedRule_MixedCase" folder and compares the
        /// results to the "CheckUniqueKeysAreNotDuplicatedRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckUniqueKeysAreNotDuplicatedRule_MixedCase_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                "CheckUniqueKeysAreNotDuplicated_MixedCaseRule",
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckUniqueKeysAreNotDuplicatedRule.RuleId);
            }
        }



        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckUniqueKeysAreNotDuplicatedRule" folder and compares the
        /// results to the "CheckUniqueKeysAreNotDuplicatedRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceIndexKeyColumnSeparationRule_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceIndexKeyColumnSeparationRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceIndexKeyColumnSeparationRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceIndexKeyColumnSeparationRule" folder and compares the
        /// results to the "EnforceIndexKeyColumnSeparationRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceIndexKeyColumnSeparationRule_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(EnforceIndexKeyColumnSeparationRule),
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceIndexKeyColumnSeparationRule.RuleId);
            }
        }


        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\EnforceIndexKeyColumnSeparationRule_MixedCase" folder and compares the
        /// results to the "EnforceIndexKeyColumnSeparationRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void EnforceIndexKeyColumnSeparationRule_MixedCase_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                "EnforceIndexKeyColumnSeparation_MixedCaseRule",
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(EnforceIndexKeyColumnSeparationRule.RuleId);
            }
        }



        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\CheckClusteredKeyColumnsNotIncludedInIndex_MixedCaseRule" folder and compares the
        /// results to the "CheckClusteredKeyColumnsNotIncludedInIndex_MixedCaseRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void CheckClusteredKeyColumnsNotIncludedInIndex_MixedCase_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                //nameof(CheckClusteredKeyColumnsNotIncludedInIndexRule),
                "CheckClusteredKeyColumnsNotIncludedInIndex_MixedCaseRule",
                new TSqlModelOptions() { Collation = @"Latin1_General_CI_AI" },
                SqlServerVersion.Sql110
                ))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(CheckClusteredKeyColumnsNotIncludedInIndexRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidNullLiteralRule" folder and compares the
        /// results to the "AvoidNullLiteralRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidNullLiteral_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidNullLiteralRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidNullLiteralRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\AvoidNullLiteralRule" folder and compares the
        /// results to the "AvoidNullLiteralRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void AvoidNullLiteral_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(AvoidNullLiteralRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(AvoidNullLiteralRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\DisallowAllCodeManipulationOfProjectDefinedObjectsRule" folder and compares the
        /// results to the "DisallowAllCodeManipulationOfProjectDefinedObjectsRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void DisallowAllCodeManipulationOfProjectDefinedObjects_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(DisallowAllCodeManipulationOfProjectDefinedObjectsRule),
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(DisallowAllCodeManipulationOfProjectDefinedObjectsRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\DisallowAllCodeManipulationOfProjectDefinedObjectsRule" folder and compares the
        /// results to the "DisallowAllCodeManipulationOfProjectDefinedObjectsRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void DisallowAllCodeManipulationOfProjectDefinedObjects_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                nameof(DisallowAllCodeManipulationOfProjectDefinedObjectsRule),
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(DisallowAllCodeManipulationOfProjectDefinedObjectsRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\DisallowAllCodeManipulationOfProjectDefinedObjects_MixedCaseRule" folder and compares the
        /// results to the "DisallowAllCodeManipulationOfProjectDefinedObjects_MixedCaseRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void DisallowAllCodeManipulationOfProjectDefinedObjects_MixedCase_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                "DisallowAllCodeManipulationOfProjectDefinedObjects_MixedCaseRule",
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(DisallowAllCodeManipulationOfProjectDefinedObjectsRule.RuleId);
            }
        }
        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\BigTestDb" folder and compares the
        /// results to the "BigTestDb-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        //[TestMethod]
        //public void BigTestDb_CI_AI()
        //{
        //    using (BaselinedRuleTest test = new BaselinedRuleTest(
        //        TestContext,
        //        "BigTestDb",
        //        new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
        //        SqlServerVersion.Sql150))
        //    {
        //        // Since this test verifies results against a baseline file, we don't need to do any extra verification
        //        // This test is for local use only - not to run on the test server if it fails it#s ok
        //        // There will better implementations of this workaround
        //        try
        //        {
        //            test.RunTest(DisallowAllCodeManipulationOfProjectDefinedObjectsRule.RuleId);
        //        }
        //        finally { }

        //    }
        //}


        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\DisallowUseOfSp_ReNameRule" folder and compares the
        /// results to the "DisallowUseOfSp_ReNameRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void DisallowUseOfSp_ReNameRule_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                "DisallowUseOfSp_ReNameRule",
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(DisallowUseOfSp_ReNameRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\DisallowUseOfSp_ReNameRule" folder and compares the
        /// results to the "DisallowUseOfSp_ReNameRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void DisallowUseOfSp_ReNameRule_BIN()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                "DisallowUseOfSp_ReNameRule",
                new TSqlModelOptions() { Collation = "Latin1_General_BIN" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(DisallowUseOfSp_ReNameRule.RuleId);
            }
        }

        /// <summary>
        /// This test uses input scripts saved in the "TestScripts\DisallowUseOfSp_ReNameRule_MixedCaseRule" folder and compares the
        /// results to the "DisallowUseOfSp_ReNameRule-Baseline.txt file in that directory. If you wanted to add extra test cases
        /// just add in new sql files and run the test. The failure message will include links to the output file - if all
        /// the problems look correct there, then you can simply copy its contents into the baseline file and rerun the test.
        /// 
        /// This is a standard approach used inside the team and is very useful for testing rules since all you need is a tiny
        /// amount of test code and some good examples that show where your rule should/should not highlight a problem.
        /// </summary>
        [TestMethod]
        public void DisallowUseOfSp_ReNameRule_MixedCaseRule_CI_AI()
        {
            using (BaselinedRuleTest test = new BaselinedRuleTest(
                TestContext,
                "DisallowUseOfSp_ReName_MixedCaseRule",
                new TSqlModelOptions() { Collation = "Latin1_General_CI_AI" },
                SqlServerVersion.Sql100))
            {
                // Since this test verifies results against a baseline file, we don't need to do any extra verification
                test.RunTest(DisallowUseOfSp_ReNameRule.RuleId);
            }
        }


    }
}




