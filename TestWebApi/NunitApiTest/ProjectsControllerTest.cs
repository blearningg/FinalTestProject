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
    public class ProjectsControllerTest
    {
        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("TestCounter")]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.Gen2)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [Test]
        public void GetProejcts_NunitTest()
        {
           var controller = new ProjectsController();
            List<ProjectViewModel> lstProject = new List<ProjectViewModel>();
            lstProject = controller.GetProjects().ToList();
            Assert.IsNotNull(lstProject);
            controller.Dispose();
        }


        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("TestCounter")]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.Gen2)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [Test]
        public void AddGetProject_NunitTest()
        {
            var controller = new ProjectsController();

            ProjectViewModel obj = new ProjectViewModel { ProjectName = "UniTestProject1", StartDate = DateTime.Now.ToString(), EndDate = DateTime.Now.AddMonths(1).ToString(), Priority = 1 , UserID= 1 };
            IHttpActionResult result = controller.PostProject(obj);
            var createResult = result as CreatedAtRouteNegotiatedContentResult<ProjectViewModel>;

            int id = Convert.ToInt32(createResult.RouteValues["id"]);
            var result2 = controller.GetProject(id) as OkNegotiatedContentResult<ProjectViewModel>;
            Assert.IsNotNull(result2);
            Assert.AreEqual(obj.ProjectName, result2.Content.ProjectName);
            controller.Dispose();
        }

        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1000, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("TestCounter")]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.Gen2)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [Test]
        public void UpdateProject_NunitTest()
        {
            var controller = new ProjectsController();

            var result = controller.GetProject(1) as OkNegotiatedContentResult<ProjectViewModel>;
            Assert.IsNotNull(result);

            result.Content.ProjectName = "UpdateUniteTest";
            result.Content.UserID = 1;
           var result2 = controller.PutProject(result.Content.ProjectID, result.Content);

            var result3 = controller.GetProject(1) as OkNegotiatedContentResult<ProjectViewModel>;
            Assert.IsNotNull(result3);

            Assert.AreEqual("UpdateUniteTest", result3.Content.ProjectName);
            controller.Dispose();
        }


    }
}
