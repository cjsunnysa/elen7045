﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RoadMaintenance.FaultVerification.Specs.GetFaultsInJurisdiction
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GetFaultsInJurisdiction")]
    public partial class GetFaultsInJurisdictionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetFaultsInJurisdiction.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetFaultsInJurisdiction", "In order to investigate and verify faults\r\nAs a fault investigator\r\nI want to get" +
                    " a list of faults in my jurisdiction ordered by priority in descending order", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Get faults for fault investigator")]
        public virtual void GetFaultsForFaultInvestigator()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get faults for fault investigator", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I am a \'FaultInvestigator\' user role", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "Longitude",
                        "Latitude",
                        "StatusId",
                        "TypeId"});
            table1.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "Sandton Dr",
                        "Grayston Dr",
                        "Sandton",
                        "2196",
                        "33/34/35/W",
                        "33/34/35/N",
                        "1",
                        "1"});
            table1.AddRow(new string[] {
                        "46BF992F-B00C-4D76-BDD0-CCB6B993E8EF",
                        "10th St",
                        "",
                        "Sandton",
                        "2196",
                        "33/34/35/W",
                        "33/34/35/N",
                        "4",
                        "2"});
            table1.AddRow(new string[] {
                        "282A10B0-103E-40F9-8D01-320D002EFF9F",
                        "8th Street",
                        "",
                        "Randburg",
                        "2195",
                        "33/34/35/W",
                        "33/34/35/N",
                        "1",
                        "1"});
            table1.AddRow(new string[] {
                        "E5354BB8-A1BB-49AF-81C1-19BF5FEC4D12",
                        "Hill Street",
                        "Malibongwe",
                        "Randburg",
                        "2195",
                        "33/34/35/W",
                        "33/34/35/N",
                        "3",
                        "3"});
#line 9
 testRunner.And("The following faults exist", ((string)(null)), table1, "And ");
#line 15
 testRunner.And("my Investigator jurisdiction centrepoint longitude is \"54 89 12 N\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("my Investigator jurisdiction centrepoint latitude is \"54 89 12 E\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("my Investigator jurisdiction radius is 10 Km", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("I press the \"Get faults\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "Longitude",
                        "Latitude",
                        "StatusId",
                        "TypeId",
                        "Priority",
                        "Distance"});
            table2.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "Sandton Dr",
                        "Grayston Dr",
                        "Sandton",
                        "2196",
                        "33/34/35/W",
                        "33/34/35/N",
                        "1",
                        "1",
                        "1",
                        "2"});
            table2.AddRow(new string[] {
                        "282A10B0-103E-40F9-8D01-320D002EFF9F",
                        "8th Street",
                        "Germiston",
                        "Randburg",
                        "2195",
                        "33/34/35/W",
                        "33/34/35/N",
                        "1",
                        "3",
                        "1",
                        "2"});
#line 19
 testRunner.Then("the following items should be retuned", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion