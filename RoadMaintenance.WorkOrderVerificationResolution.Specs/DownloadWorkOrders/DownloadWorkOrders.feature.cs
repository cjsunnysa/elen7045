﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RoadMaintenance.WorkOrderVerificationResolution.Specs.DownloadWorkOrders
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Download Work Orders")]
    public partial class DownloadWorkOrdersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DownloadWorkOrders.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Download Work Orders", "In order to inspect faults\r\nAs an inspector\r\nI want to get scheduled inspections " +
                    "when I login", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Scheduled Inspections Received on Successfull Login")]
        [NUnit.Framework.CategoryAttribute("GreenPath")]
        public virtual void ScheduledInspectionsReceivedOnSuccessfullLogin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Scheduled Inspections Received on Successfull Login", new string[] {
                        "GreenPath"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Role",
                        "Username",
                        "Password"});
            table1.AddRow(new string[] {
                        "1",
                        "Inspector",
                        "LuisD",
                        "myPass"});
            table1.AddRow(new string[] {
                        "2",
                        "CallCenterOperator",
                        "ChrisJ",
                        "chrisPass"});
#line 8
testRunner.Given("the following user data", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Status",
                        "FaultId",
                        "Priority"});
            table2.AddRow(new string[] {
                        "1",
                        "AwaitingVerification",
                        "10",
                        "Low"});
            table2.AddRow(new string[] {
                        "2",
                        "AwaitingVerification",
                        "11",
                        "High"});
            table2.AddRow(new string[] {
                        "3",
                        "AwaitingVerification",
                        "12",
                        "Normal"});
            table2.AddRow(new string[] {
                        "4",
                        "Scheduled",
                        "13",
                        "Normal"});
            table2.AddRow(new string[] {
                        "5",
                        "AwaitingVerification",
                        "14",
                        "Normal"});
            table2.AddRow(new string[] {
                        "6",
                        "AwaitingVerification",
                        "15",
                        "High"});
            table2.AddRow(new string[] {
                        "7",
                        "AwaitingVerification",
                        "16",
                        "High"});
            table2.AddRow(new string[] {
                        "8",
                        "AwaitingVerification",
                        "17",
                        "Normal"});
            table2.AddRow(new string[] {
                        "9",
                        "Created",
                        "18",
                        "High"});
            table2.AddRow(new string[] {
                        "10",
                        "AwaitingVerification",
                        "19",
                        "Normal"});
            table2.AddRow(new string[] {
                        "11",
                        "AwaitingVerification",
                        "20",
                        "Normal"});
            table2.AddRow(new string[] {
                        "12",
                        "AwaitingVerification",
                        "21",
                        "Normal"});
#line 12
testRunner.And("the following work orders", ((string)(null)), table2, "And ");
#line 26
testRunner.When("I successfully login as user \'Username\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.And("get the top ten work orders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Status",
                        "FaultId",
                        "Priority"});
            table3.AddRow(new string[] {
                        "2",
                        "AwaitingVerification",
                        "11",
                        "High"});
            table3.AddRow(new string[] {
                        "6",
                        "AwaitingVerification",
                        "15",
                        "High"});
            table3.AddRow(new string[] {
                        "7",
                        "AwaitingVerification",
                        "16",
                        "High"});
            table3.AddRow(new string[] {
                        "1",
                        "AwaitingVerification",
                        "10",
                        "Low"});
            table3.AddRow(new string[] {
                        "3",
                        "AwaitingVerification",
                        "12",
                        "Normal"});
            table3.AddRow(new string[] {
                        "5",
                        "AwaitingVerification",
                        "14",
                        "Normal"});
            table3.AddRow(new string[] {
                        "8",
                        "AwaitingVerification",
                        "17",
                        "Normal"});
            table3.AddRow(new string[] {
                        "10",
                        "AwaitingVerification",
                        "19",
                        "Normal"});
            table3.AddRow(new string[] {
                        "11",
                        "AwaitingVerification",
                        "20",
                        "Normal"});
            table3.AddRow(new string[] {
                        "12",
                        "AwaitingVerification",
                        "21",
                        "Normal"});
#line 28
testRunner.Then("the result in ascending order is", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion