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
namespace RoadMaintenance.FaultLogging.Specs.UpdateAddress
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Update the Address of a fault")]
    public partial class UpdateTheAddressOfAFaultFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UpdateAddressOfAFault.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Update the Address of a fault", "In order for a technician to more easily locate a fault\'s location\r\nAs a call-cen" +
                    "ter operator\r\nI want to be able to update the Address of a fault", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Update a fault address change street name")]
        [NUnit.Framework.CategoryAttribute("greenPath")]
        public virtual void UpdateAFaultAddressChangeStreetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update a fault address change street name", new string[] {
                        "greenPath"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I am on the Update Address page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("the fault I am editing has the Id \'202947AF-130F-4494-8C50-DB84A93648E1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I enter \'Fern Street\' as the street name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table1.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Randburg",
                        "2194",
                        "1",
                        "2",
                        ""});
            table1.AddRow(new string[] {
                        "46BF992F-B00C-4D76-BDD0-CCB6B993E8EF",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Randburg",
                        "2194",
                        "4",
                        "2",
                        "2015-03-01"});
#line 11
 testRunner.And("These faults exist", ((string)(null)), table1, "And ");
#line 15
 testRunner.When("I press the Update Address button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.And("I perform a find for this fault id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table2.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Fern Street",
                        "",
                        "Randburg",
                        "2194",
                        "1",
                        "2",
                        ""});
#line 17
 testRunner.Then("The results should be", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update a fault address change cross street name")]
        public virtual void UpdateAFaultAddressChangeCrossStreetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update a fault address change cross street name", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I am on the Update Address page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.And("the fault I am editing has the Id \'202947AF-130F-4494-8C50-DB84A93648E1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I enter \'Fern Street\' as the cross street name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table3.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Randburg",
                        "2194",
                        "1",
                        "2",
                        ""});
            table3.AddRow(new string[] {
                        "46BF992F-B00C-4D76-BDD0-CCB6B993E8EF",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Randburg",
                        "2194",
                        "4",
                        "2",
                        "2015-03-01"});
#line 25
 testRunner.And("These faults exist", ((string)(null)), table3, "And ");
#line 29
 testRunner.When("I press the Update Address button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.And("I perform a find for this fault id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table4.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Hill Street",
                        "Fern Street",
                        "Randburg",
                        "2194",
                        "1",
                        "2",
                        ""});
#line 31
 testRunner.Then("The results should be", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update a fault address change suburb name")]
        public virtual void UpdateAFaultAddressChangeSuburbName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update a fault address change suburb name", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given("I am on the Update Address page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And("the fault I am editing has the Id \'202947AF-130F-4494-8C50-DB84A93648E1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I enter \'Sandton\' as the suburb name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table5.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Randburg",
                        "2194",
                        "1",
                        "2",
                        ""});
            table5.AddRow(new string[] {
                        "46BF992F-B00C-4D76-BDD0-CCB6B993E8EF",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Randburg",
                        "2194",
                        "4",
                        "2",
                        "2015-03-01"});
#line 39
 testRunner.And("These faults exist", ((string)(null)), table5, "And ");
#line 43
 testRunner.When("I press the Update Address button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.And("I perform a find for this fault id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table6.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Sandton",
                        "2194",
                        "1",
                        "2",
                        ""});
#line 45
 testRunner.Then("The results should be", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update a fault address change post code")]
        public virtual void UpdateAFaultAddressChangePostCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update a fault address change post code", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("I am on the Update Address page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.And("the fault I am editing has the Id \'202947AF-130F-4494-8C50-DB84A93648E1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I enter \'2196\' as the post code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table7.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Sandton",
                        "2194",
                        "1",
                        "2",
                        ""});
            table7.AddRow(new string[] {
                        "46BF992F-B00C-4D76-BDD0-CCB6B993E8EF",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Randburg",
                        "2194",
                        "4",
                        "2",
                        "2015-03-01"});
#line 53
 testRunner.And("These faults exist", ((string)(null)), table7, "And ");
#line 57
 testRunner.When("I press the Update Address button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.And("I perform a find for this fault id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table8.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Sandton",
                        "2196",
                        "1",
                        "2",
                        ""});
#line 59
 testRunner.Then("The results should be", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update a fault address change all details")]
        public virtual void UpdateAFaultAddressChangeAllDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update a fault address change all details", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("I am on the Update Address page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.And("the fault I am editing has the Id \'202947AF-130F-4494-8C50-DB84A93648E1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("I enter \'Rivonia Rd\' as the street name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("I enter \'Fern Ave\' as the cross street name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("I enter \'Midrand\' as the suburb name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("I enter \'2127\' as the post code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table9.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Sandton",
                        "2194",
                        "1",
                        "2",
                        ""});
            table9.AddRow(new string[] {
                        "46BF992F-B00C-4D76-BDD0-CCB6B993E8EF",
                        "",
                        "",
                        "Hill Street",
                        "",
                        "Randburg",
                        "2194",
                        "4",
                        "2",
                        "2015-03-01"});
#line 70
 testRunner.And("These faults exist", ((string)(null)), table9, "And ");
#line 74
 testRunner.When("I press the Update Address button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
 testRunner.And("I perform a find for this fault id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Latitude",
                        "Longitude",
                        "Street",
                        "CrossStreet",
                        "Suburb",
                        "PostCode",
                        "StatusId",
                        "TypeId",
                        "DateCompleted"});
            table10.AddRow(new string[] {
                        "202947AF-130F-4494-8C50-DB84A93648E1",
                        "",
                        "",
                        "Rivonia Rd",
                        "Fern Ave",
                        "Midrand",
                        "2127",
                        "1",
                        "2",
                        ""});
#line 76
 testRunner.Then("The results should be", ((string)(null)), table10, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion