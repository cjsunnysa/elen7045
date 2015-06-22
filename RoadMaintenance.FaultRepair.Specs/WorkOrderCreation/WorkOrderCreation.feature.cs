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
namespace RoadMaintenance.FaultRepair.Specs.WorkOrderCreation
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("WorkOrderCreation")]
    public partial class WorkOrderCreationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WorkOrderCreation.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WorkOrderCreation", "As an authorised staff member of the transport department\nI want to capture a wor" +
                    "k order for a logged fault", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Create a basic work order")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void CreateABasicWorkOrder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a basic work order", new string[] {
                        "mytag"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Description"});
            table1.AddRow(new string[] {
                        "Work Order 1"});
#line 7
 testRunner.Given("I have the following work orders in the system", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Description"});
            table2.AddRow(new string[] {
                        "Work Order 2"});
#line 10
 testRunner.When("I create and add a work order", ((string)(null)), table2, "When ");
#line 13
 testRunner.Then("the result should be a new work order number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Description"});
            table3.AddRow(new string[] {
                        "Work Order 1"});
            table3.AddRow(new string[] {
                        "Work Order 2"});
#line 14
 testRunner.And("the work orders in the system should be", ((string)(null)), table3, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a complex work order with tasks, equipment and materials")]
        public virtual void CreateAComplexWorkOrderWithTasksEquipmentAndMaterials()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a complex work order with tasks, equipment and materials", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
    testRunner.Given("I have no work orders in the system", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Description"});
            table4.AddRow(new string[] {
                        "Work Order 2"});
#line 21
 testRunner.When("I created a work order as follows", ((string)(null)), table4, "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Description"});
            table5.AddRow(new string[] {
                        "Task 1"});
            table5.AddRow(new string[] {
                        "Task 2"});
            table5.AddRow(new string[] {
                        "Task 3"});
#line 24
 testRunner.And("I add the following tasks", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Description",
                        "Number"});
            table6.AddRow(new string[] {
                        "Tool 1",
                        "5"});
#line 29
 testRunner.And("I add the following equipment", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Description",
                        "Amount",
                        "Measurement"});
            table7.AddRow(new string[] {
                        "Material 1",
                        "5",
                        "Kg"});
            table7.AddRow(new string[] {
                        "Material 2",
                        "100",
                        "Liter"});
#line 32
 testRunner.And("I add the following material", ((string)(null)), table7, "And ");
#line 36
 testRunner.Then("the result should be a new work order number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
 testRunner.And("there should be 1 work order in the system", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
