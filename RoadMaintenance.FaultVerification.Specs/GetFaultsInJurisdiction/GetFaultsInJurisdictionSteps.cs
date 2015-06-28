using RoadMaintenance.SharedKernel.Specs;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using RoadMaintenance.FaultVerification.Specs.GetFaultsInJurisdiction;
using RoadMaintenance.FaultVerification.Services;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RoadMaintenance.FaultVerification.Services.Response;
using Ninject;
using RoadMaintenance.FaultVerification.Services.Interfaces;
using RoadMaintenance.FaultVerification.Repos;
using RoadMaintenance.FaultVerification.Core.Model;
using RoadMaintenance.FaultVerification.Specs.Model;
using RoadMaintenance.FaultVerification.Specs.Helpers;


namespace RoadMaintenance.FaultVerification.Specs
{
    [Binding]
    public class GetFaultsInJurisdictionSteps
    {

        [Given(@"I am a '(.*)' user role")]
        public void GivenIAmAUserRole(string userRole)
        {
            TestKernelBootstrapper.SetupUser(userRole);
        }
        
        [Given(@"The following faults exist")]
        public void GivenTheFollowingFaultsExist(Table table)
        {
            //var data = table.CreateSet<FaultTestData>();
            var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");

            var data = table.CreateSet<FaultTestData>().Select(test => test.ToDomainModel()).AsQueryable();

            //var qqqdata = table.CreateSet<FaultTest>().Select(test => test.ToDomainModel()).AsQueryable();


           kernel.Get<DummyFaultRepository>().SetData(data.ToList());

            ScenarioContext.Current.Add("data", data);
        }
        
        [Given(@"my Investigator jurisdiction centrepoint longitude is ""(.*)""")]
        public void GivenMyInvestigatorJurisdictionCentrepointLongitudeIs(string longitude)
        {
            ScenarioContext.Current.Add("longitude", longitude);
        }
        
        [Given(@"my Investigator jurisdiction centrepoint latitude is ""(.*)""")]
        public void GivenMyInvestigatorJurisdictionCentrepointLatitudeIs(string latitude)
        {
            ScenarioContext.Current.Add("latitude", latitude);
        }
        
        [Given(@"my Investigator jurisdiction radius is (.*) Km")]
        public void GivenMyInvestigatorJurisdictionRadiusIsKm(int radius)
        {
            ScenarioContext.Current.Add("radius", radius);
        }
        
        [When(@"I press the ""(.*)"" button")]
        public void WhenIPressTheButton(string p0)
        {
            var longitude = ScenarioContext.Current.Get<string>("longitude");
            var latitude = ScenarioContext.Current.Get<string>("latitude");
            var radius = ScenarioContext.Current.Get<int>("radius");
            
            var request = new GetJuristdictionFaultsRequest
            {
                Jurisdiction = new Jurisdiction(longitude,latitude,radius)
            };

            
            //var service = new FaultService();
            var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");
            var service = kernel.Get<IFaultService>();

            var results = service.GetJurisdictionFaults(request);

            ScenarioContext.Current.Add("results", results);
        }
        
        [Then(@"the following items should be retuned")]
        public void ThenTheFollowingItemsShouldBeRetuned(Table table)
        {
            var expectedResults = table.CreateSet<FaultTestData>();
            var results = ScenarioContext.Current.Get<IEnumerable<FaultView>>("results");

            var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");



            //var expected = table.CreateSet<FaultTestData>().Select(test => test.ToView());
            
           
            //var expected = table.CreateSet<FaultTestData>().Select(test => test.ToDomainModel()).AsQueryable();

            CollectionAssert.AreEqual(expectedResults, results);
        }
    }
}
