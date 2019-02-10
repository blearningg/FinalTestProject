using NBench;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using TestWebApi;
using TestWebApi.Controllers;
using TestWebApi.Models;

namespace NunitApiTest
{
    [TestFixture]
    public class ParentParentTasksControllerTest
    {
        private Counter _testCounter;
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _testCounter = context.GetCounter("ParentTestCounter");

        }
        //Add and get test
        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1200, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("ParentTestCounter")]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [Test]
        public void AddParentTask_NunitTest()
        {
            var controller = new ParentTasksController();

            ParentTask obj = new ParentTask { TaskDesc = "UniteTestTaskDesc1" };
            IHttpActionResult result = controller.PostParentTask(obj);

            var createResult = result as CreatedAtRouteNegotiatedContentResult<ParentTask>;

            int id = Convert.ToInt32(createResult.RouteValues["id"]);

            var result2 = controller.GetParentTask(id) as OkNegotiatedContentResult<ParentTask>;

            Assert.IsNotNull(result2);
            Assert.AreEqual(obj.TaskDesc, result2.Content.TaskDesc);

            controller.Dispose();

            _testCounter.Increment();
        }

        // get test
        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1200, TestMode = TestMode.Test, SkipWarmups = true)]
        [CounterMeasurement("ParentTestCounter")]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        [Test]
        public void GetParentTasks_NunitTest()
        {
            var controller = new ParentTasksController();
            var result = controller.GetParentTasks();
            Assert.IsNotNull(result);
            controller.Dispose();
            _testCounter.Increment();
        }

    }
}
