﻿using System;
using System.Linq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.FaultLogging.Repos;
using RoadMaintenance.FaultLogging.Repos.Interfaces;
using RoadMaintenance.FaultLogging.Services;
using RoadMaintenance.FaultLogging.Services.Interfaces;
using RoadMaintenance.FaultLogging.Specs.Helpers;
using RoadMaintenance.FaultLogging.Specs.Model;
using RoadMaintenance.SharedKernel.Core;
using RoadMaintenance.SharedKernel.Repos;
using RoadMaintenance.SharedKernel.Specs;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RoadMaintenance.FaultLogging.Specs
{
    [Binding]
    public class SharedSteps
    {
        [BeforeScenario]
        public void ScenarioSetUp()
        {
            var kernel = TestKernelBootstrapper.InitialiseKernel();
            var scenarioParams = new ScenarioParameters();
            var repo = new DummyFaultRepository();

            kernel.Bind<IFaultService>().To<FaultService>();
            kernel.Bind<IFaultRepository>().ToConstant(repo).InSingletonScope();
            kernel.Bind<DummyFaultRepository>().ToConstant(repo).InSingletonScope();

            SetUpMethodAccessRepo(kernel);

            scenarioParams.FaultService = kernel.Get<IFaultService>();

            ScenarioContext.Current.Add("Params", scenarioParams);
            ScenarioContext.Current.Add("kernel", kernel);
        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
            var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");

            kernel.Dispose();
        }

        private void SetUpMethodAccessRepo(StandardKernel kernel)
        {
            var methodAccessRepo = kernel.Get<IMethodAccessRepository>();

            methodAccessRepo.Save(new MethodAccess("FaultService.GetType", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.GetStatusDescription", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.Find", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.Search", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.CreateFault", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.UpdateGpsCoordinates", "Dispatcher", "CallCenterOperator"));
            methodAccessRepo.Save(new MethodAccess("FaultService.UpdateAddress", "Dispatcher", "CallCenterOperator"));
        }

        [Given(@"the fault I am editing has the Id '(.*)'")]
        public void GivenTheFaultIAmEditingHasTheId(string faultId)
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            param.GivenFaultId = faultId;
        }

        [When(@"I perform a find for this fault id")]
        public void WhenIPerformAFindForThisFaultId()
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");

            var faultId = new Guid(param.GivenFaultId);
            
            var fault = param.FaultService.Find(faultId);

            param.ResultsCollection = new[] { fault };
        }

        [Given(@"These faults exist")]
        public void GivenTheseFaultsExist(Table table)
        {
            var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");

            var data = table.CreateSet<FaultTest>().Select(test => test.ToDomainModel()).AsQueryable();

            kernel.Get<DummyFaultRepository>().SetData(data.ToList());
        }
        
        [Then(@"The results should be")]
        public void ThenTheResultsShouldBe(Table table)
        {
            var param = ScenarioContext.Current.Get<ScenarioParameters>("Params");
            
            var testSet = table.CreateSet<FaultTest>()
                                .Select(t => t.ToResponse());

            foreach (var expected in testSet)
            {
                var actual = param.ResultsCollection.SingleOrDefault(f => f.Id.Equals(expected.Id));

                Assert.IsNotNull(actual);
                Assert.AreEqual(expected.StreetName, actual.StreetName);
                Assert.AreEqual(expected.CrossStreet, actual.CrossStreet);
                Assert.AreEqual(expected.Suburb, actual.Suburb);
                Assert.AreEqual(expected.PostCode, actual.PostCode);
                Assert.AreEqual(expected.Latitude, actual.Latitude);
                Assert.AreEqual(expected.Longitude, actual.Longitude);
                Assert.AreEqual(expected.EstimatedCompletionDate, actual.EstimatedCompletionDate);
                Assert.AreEqual(expected.DateCompleted, actual.DateCompleted);
                Assert.AreEqual(expected.Description, actual.Description);
                Assert.AreEqual(expected.Priority, actual.Priority);
            }
        }

        [Given(@"I am a '(.*)' user role")]
        public void GivenIAmAUser(string userRole)
        {
            TestKernelBootstrapper.SetupUser(userRole);
        }

    }
}
