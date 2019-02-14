using NBench;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TestWebApi;
using TestWebApi.Controllers;
using TestWebApi.Models;

namespace NunitApiTest
{
    [TestFixture]
    public class UsersControllerTest 
    {
        private Counter _testCounter;
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _testCounter = context.GetCounter("UserTestCounter");

        }
        //ADD ang GET User test
        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 6000, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("UserTestCounter")]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.Gen2)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [Test]
        public void AddGetProject_NunitTest()
        {
            var controller = new UsersController();

            User obj = new User { FirstName = "UniTestFname1", LastName = "UniTestLname1", EmployeeID = "UEmp1" };
            IHttpActionResult result = controller.PostUser(obj);
            var createResult = result as CreatedAtRouteNegotiatedContentResult<User>;

            int id = Convert.ToInt32(createResult.RouteValues["id"]);
            var result2 = controller.GetUser(id) as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(result2);
            Assert.AreEqual(obj.FirstName, result2.Content.FirstName);
            controller.Dispose();
           // _testCounter.Increment();
        }

        //update user /put test

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 6000, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("UserTestCounter")]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.Gen2)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [Test]
        public void UpdateUser_NunitTest()
        {
            var controller = new UsersController();

            var result = controller.GetUser(1) as OkNegotiatedContentResult<User>;

            result.Content.FirstName = "UnitTestFirstNameUpdated";

            var result2 = controller.PutUser(result.Content.UserID, result.Content);

            var result3 = controller.GetUser(1) as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(result3);
            Assert.AreEqual("UnitTestFirstNameUpdated", result3.Content.FirstName);
            controller.Dispose();
          //  _testCounter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 6000, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("UserTestCounter")]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.Gen2)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [Test]
        public void GetUsers_NunitTest()
        {
            var controller = new UsersController();
            List<User> lstUser = new List<User>();
            lstUser = controller.GetUsers().ToList();
            Assert.IsNotNull(lstUser);
            Assert.IsTrue(lstUser.Count > 0);
            controller.Dispose();
          //  _testCounter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 6000, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("UserTestCounter")]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.Gen2)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [Test]
        public void DeleteUser_NunitTest()
        {
            var controller = new UsersController();

            User obj = new User { FirstName = "DeleteUniTest", LastName = "UniTestLname1", EmployeeID = "UEmpD1" };
            IHttpActionResult result = controller.PostUser(obj);
            var createResult = result as CreatedAtRouteNegotiatedContentResult<User>;

            int id = Convert.ToInt32(createResult.RouteValues["id"]);

            IHttpActionResult result3 = controller.DeleteUser(id);

            masterEntities db = new masterEntities();
            int maxid = db.Users.Max(x => x.UserID);
            Assert.AreNotEqual(id, maxid);
            controller.Dispose();
          //  _testCounter.Increment();
        }
    }
}
