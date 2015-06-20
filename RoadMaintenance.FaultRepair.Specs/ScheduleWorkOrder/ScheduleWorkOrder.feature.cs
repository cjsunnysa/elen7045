﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18408
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RoadMaintenance.FaultRepair.Specs.ScheduleWorkOrder
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ScheduleWorkOrder")]
    public partial class ScheduleWorkOrderFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ScheduleWorkOrder.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ScheduleWorkOrder", "In order to schedule a work order\r\nAs a dispatcher\r\nI should be able to assign it" +
                    " a repair team by allocating it to a repair teams schedule and be able to resche" +
                    "dule and unschedule that work order", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Allocate a work order to a repair team with no other work orders scheduled")]
        public virtual void AllocateAWorkOrderToARepairTeamWithNoOtherWorkOrdersScheduled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Allocate a work order to a repair team with no other work orders scheduled", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Duration"});
            table1.AddRow(new string[] {
                        "0",
                        "24"});
#line 7
 testRunner.Given("I have a work order", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
#line 10
 testRunner.And("I have a repair team with id 1 and the following schedule", ((string)(null)), table2, "And ");
#line 12
 testRunner.When("I schedule the work order for \"2014-01-03 08:00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("the work order scheduling should be \"succesful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table3.AddRow(new string[] {
                        "0",
                        "\"2014-01-3 08:00\"",
                        "\"2014-01-5 16:00\""});
#line 14
 testRunner.And("the following resultant schedule for team with id 1", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Allocate a work order to a repair team with no conflicting work orders scheduled")]
        public virtual void AllocateAWorkOrderToARepairTeamWithNoConflictingWorkOrdersScheduled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Allocate a work order to a repair team with no conflicting work orders scheduled", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Duration"});
            table4.AddRow(new string[] {
                        "3",
                        "6"});
#line 19
 testRunner.Given("I have a work order", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table5.AddRow(new string[] {
                        "0",
                        "\"2014-01-06 08:00\"",
                        "\"2014-01-06 14:00\""});
            table5.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table5.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
#line 22
 testRunner.And("I have a repair team with id 1 and the following schedule", ((string)(null)), table5, "And ");
#line 27
 testRunner.When("I schedule the work order for \"2014-01-09 15:00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("the work order scheduling should be \"succesful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table6.AddRow(new string[] {
                        "0",
                        "\"2014-01-06 08:00\"",
                        "\"2014-01-06 14:00\""});
            table6.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table6.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
            table6.AddRow(new string[] {
                        "3",
                        "\"2014-01-9 15:00\"",
                        "\"2014-01-10 13:00\""});
#line 29
 testRunner.And("the following resultant schedule for team with id 1", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Allocate a work order to a repair team with conflicting work orders scheduled")]
        public virtual void AllocateAWorkOrderToARepairTeamWithConflictingWorkOrdersScheduled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Allocate a work order to a repair team with conflicting work orders scheduled", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Duration"});
            table7.AddRow(new string[] {
                        "3",
                        "6"});
#line 37
 testRunner.Given("I have a work order", ((string)(null)), table7, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table8.AddRow(new string[] {
                        "0",
                        "\"2014-01-06 08:00\"",
                        "\"2014-01-06 14:00\""});
            table8.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table8.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
#line 40
 testRunner.And("I have a repair team with id 1 and the following schedule", ((string)(null)), table8, "And ");
#line 45
 testRunner.When("I schedule the work order for \"2014-01-07 15:00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("the work order scheduling should be \"unsuccesful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table9.AddRow(new string[] {
                        "0",
                        "\"2014-01-06 08:00\"",
                        "\"2014-01-06 14:00\""});
            table9.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table9.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
#line 47
 testRunner.And("the following resultant schedule for team with id 1", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Reschedule a work order allocated to a repair team with no conflicting work order" +
            "s scheduled")]
        public virtual void RescheduleAWorkOrderAllocatedToARepairTeamWithNoConflictingWorkOrdersScheduled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reschedule a work order allocated to a repair team with no conflicting work order" +
                    "s scheduled", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Duration"});
            table10.AddRow(new string[] {
                        "0",
                        "6"});
#line 54
 testRunner.Given("I have a work order", ((string)(null)), table10, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table11.AddRow(new string[] {
                        "0",
                        "\"2014-01-06 08:00\"",
                        "\"2014-01-06 14:00\""});
            table11.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table11.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
#line 57
 testRunner.And("I have a repair team with id 1 and the following schedule", ((string)(null)), table11, "And ");
#line 62
 testRunner.When("I schedule the work order for \"2014-01-09 15:00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.Then("the work order scheduling should be \"succesful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table12.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table12.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
            table12.AddRow(new string[] {
                        "0",
                        "\"2014-01-09 15:00\"",
                        "\"2014-01-10 13:00\""});
#line 64
 testRunner.And("the following resultant schedule for team with id 1", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Reschedule a work order allocated to a repair team with conflicting work orders s" +
            "cheduled")]
        public virtual void RescheduleAWorkOrderAllocatedToARepairTeamWithConflictingWorkOrdersScheduled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reschedule a work order allocated to a repair team with conflicting work orders s" +
                    "cheduled", ((string[])(null)));
#line 70
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Duration"});
            table13.AddRow(new string[] {
                        "0",
                        "6"});
#line 71
 testRunner.Given("I have a work order", ((string)(null)), table13, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table14.AddRow(new string[] {
                        "0",
                        "\"2014-01-06 08:00\"",
                        "\"2014-01-06 14:00\""});
            table14.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table14.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
#line 74
 testRunner.And("I have a repair team with id 1 and the following schedule", ((string)(null)), table14, "And ");
#line 79
 testRunner.When("I schedule the work order for \"2014-01-07 15:00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.Then("the work order scheduling should be \"unsuccesful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table15.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table15.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
            table15.AddRow(new string[] {
                        "0",
                        "\"2014-01-09 15:00\"",
                        "\"2014-01-10 13:00\""});
#line 81
 testRunner.And("the following resultant schedule for team with id 1", ((string)(null)), table15, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unschedule a work order allocated to a repair team")]
        public virtual void UnscheduleAWorkOrderAllocatedToARepairTeam()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unschedule a work order allocated to a repair team", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Duration"});
            table16.AddRow(new string[] {
                        "0",
                        "6"});
#line 88
 testRunner.Given("I have a work order", ((string)(null)), table16, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table17.AddRow(new string[] {
                        "0",
                        "\"2014-01-06 08:00\"",
                        "\"2014-01-06 14:00\""});
            table17.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table17.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
#line 91
 testRunner.And("I have a repair team with id 1 and the following schedule", ((string)(null)), table17, "And ");
#line 96
 testRunner.When("I unschedule the work order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
 testRunner.Then("the work order unscheduling should be \"succesful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table18.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table18.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
#line 98
 testRunner.And("the following resultant schedule for team with id 1", ((string)(null)), table18, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unschedule a work order not allocated to a repair team")]
        public virtual void UnscheduleAWorkOrderNotAllocatedToARepairTeam()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unschedule a work order not allocated to a repair team", ((string[])(null)));
#line 103
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Duration"});
            table19.AddRow(new string[] {
                        "3",
                        "6"});
#line 104
 testRunner.Given("I have a work order", ((string)(null)), table19, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table20.AddRow(new string[] {
                        "0",
                        "\"2014-01-06 08:00\"",
                        "\"2014-01-06 14:00\""});
            table20.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table20.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
#line 107
 testRunner.And("I have a repair team with id 1 and the following schedule", ((string)(null)), table20, "And ");
#line 112
 testRunner.When("I unschedule the work order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
 testRunner.Then("the work order unscheduling should be \"unsuccesful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "WorkOrderID",
                        "StartTime",
                        "EndTime"});
            table21.AddRow(new string[] {
                        "1",
                        "\"2014-01-07 08:00\"",
                        "\"2014-01-08 12:00\""});
            table21.AddRow(new string[] {
                        "2",
                        "\"2014-01-08 14:00\"",
                        "\"2014-01-09 13:00\""});
            table21.AddRow(new string[] {
                        "0",
                        "\"2014-01-09 15:00\"",
                        "\"2014-01-10 13:00\""});
#line 114
 testRunner.And("the following resultant schedule for team with id 1", ((string)(null)), table21, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
