using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using NUnit.Framework;
using RoadMaintenance.SharedKernel.Specs;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RoadMaintenance.WorkOrderVerificationResolution.Specs.DownloadWorkOrders
{
    [Binding]
    public class DownloadWorkOrdersSteps
    {
        [BeforeScenario]
        public void SetUp()
        {
            var kernel = TestKernelBootstrapper.InitialiseKernel();

            var repo = new DummyWorkOrderRepository();
            var service = new WorkOrderService(repo);

            kernel.Bind<IWorkOrderRepository>().ToConstant(repo).InSingletonScope();
            kernel.Bind<IWorkOrderService>().ToConstant(service).InSingletonScope();
            
            ScenarioContext.Current.Add("kernel", kernel);
            ScenarioContext.Current.Add("repo", repo);
        }

        [Given(@"the following user data")]
        public void GivenTheFollowingUserData(Table table)
        {
            var userData = table.CreateSet<User>();
            
            ScenarioContext.Current.Add("userdata", userData);
        }
        
        [Given(@"the following work orders")]
        public void GivenTheFollowingWorkOrders(Table table)
        {
            var repo = ScenarioContext.Current.Get<DummyWorkOrderRepository>("repo");

            var workOrderData = table.CreateSet<WorkOrder>();

            repo.SetData(workOrderData.ToList());
        }
        
        [When(@"I successfully login as user '(.*)'")]
        public void WhenISuccessfullyLoginAsUser(string user)
        {
            TestKernelBootstrapper.SetupUser(user);
        }
        
        [When(@"get the top ten work orders")]
        public void WhenGetTheTopTenWorkOrders()
        {
            var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");

            var service = kernel.Get<IWorkOrderService>();

            var results = service.GetTopWorkOrders();

            ScenarioContext.Current.Add("serviceresults", results);
        }
        
        [Then(@"the result in ascending order is")]
        public void ThenTheResultInAscendingOrderIs(Table table)
        {
            var expectedData = table.CreateSet<WorkOrder>().ToArray();

            var actualData = ScenarioContext.Current.Get<IEnumerable<WorkOrder>>("serviceresults").ToArray();

            for(var index = 0; index <= expectedData.Count(); index++)
            {
                var expectedRec = expectedData[index];
                var actualRec = actualData[index];

                Assert.AreEqual(expectedRec.Id, actualRec.Id);
                Assert.AreEqual(expectedRec.Priority, actualRec.Priority);
            }
        }
    }

    public class WorkOrderService : IWorkOrderService
    {
        private readonly IWorkOrderRepository _repo;

        public WorkOrderService(IWorkOrderRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<WorkOrder> GetTopWorkOrders()
        {
            return (from d in _repo.Data
                    where
                        d.Status.Equals(Status.AwaitingVerification)
                    orderby d.Priority, d.Id
                    select d).Take(10);
        }
    }

    public interface IWorkOrderService
    {
        IEnumerable<WorkOrder> GetTopWorkOrders();
    }

    public interface IWorkOrderRepository
    {
        IQueryable<WorkOrder> Data { get; }
    }

    public class DummyWorkOrderRepository : IWorkOrderRepository
    {
        private List<WorkOrder> _data;
        
        IQueryable<WorkOrder> IWorkOrderRepository.Data
        {
            get { return _data.AsQueryable(); }
        }

        public DummyWorkOrderRepository()
        {
            _data = new List<WorkOrder>();
        }

        public void SetData(List<WorkOrder> data)
        {
            _data = data;
        }

    }

    public class WorkOrder
    {
        public string Id { get; set; }
        public Status Status { get; set; }
        public Guid FaultId { get; set; }
        public Priority Priority { get; set; }

        public WorkOrder()
        {
            
        }

        public WorkOrder(string id, Status status, Guid faultId, Priority priority)
        {
            Id = id;
            Status = status;
            FaultId = faultId;
            Priority = priority;
        }
    }

    public enum Priority
    {
        Low = 1,
        Normal = 2,
        High = 3,
    }

    public enum Status
    {
        Creating, 
        Created, 
        Issued, 
        Scheduled, 
        AwaitingVerification, 
        Verified, 
        Closed
    };

    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {
            
        }
        
        public User(int id, string role, string username, string password)
        {
            Id = id;
            Role = role;
            Username = username;
            Password = password;
        }
    }
}
