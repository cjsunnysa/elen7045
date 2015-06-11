using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Dependencies;
using DeleporterCore.Client;
using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RoadMaintenance.DataService.Datastore;
using RoadMaintenance.DataService.DTO;
using RoadMaintenance.DataService.Interfaces;
using RoadMaintenance.MVC.App_Start;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RoadMaintenance.Specs
{
    [Binding]
    public class SearchFaultsSteps
    {
        private IWebDriver _driver;
        
        [BeforeScenario]
        public void SearchFaultsStepsSetUp()
        {
            _driver = new ChromeDriver();
        }

        [Given(@"I am on the Fault Search page")]
        public void GivenIAmOnTheFaultSearchPage()
        {
            _driver.Navigate().GoToUrl(@"http://localhost/RoadMaintenance/Search");
        }

        [Given(@"I enter '(.*)' as the street name")]
        public void GivenIEnterAsTheStreetName(string streetName)
        {
            var streetNameTextBox = _driver.FindElement(By.Id("txtStreet"));
            streetNameTextBox.SendKeys(streetName);
        }

        [Given(@"These faults exist")]
        public void GivenTheseFaultsExist(Table table)
        {
            var data = table.CreateSet<FaultDTO>().ToArray();
            var moqDataSource = new Mock<IRoadMaintenanceDatasource>();
            moqDataSource.Setup(instance => instance.GetFaults()).Returns(new FaultDTO[] { });
        }

        [When(@"I press the Search button")]
        public void WhenIPressTheSearchButton()
        {
            var searchButton = _driver.FindElement(By.Id("btnSearch"));

            searchButton.Click();
        }

        [Then(@"The results should be")]
        public void ThenTheResultsShouldBe(Table table)
        {
        }

        [AfterScenario]
        public void SearchFaultStepsTearDown()
        {
            _driver.Quit();
        }
    }
}
