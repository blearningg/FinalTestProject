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
    public class TasksControllerTest
    {
        //private Counter _testCounter;
        //[PerfSetup]
        //public void Setup(BenchmarkContext context)
        //{
        //    _testCounter = context.GetCounter("TaskTestCounter");

        //}
        //[PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1200, TestMode = TestMode.Test, SkipWarmups = true)]
        //[CounterMeasurement("TaskTestCounter")]
        //[GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //[MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        //[Test]
        //public void GetTasks_NunitTest()
        //{
        //    var controller = new TasksController();
        //    List<TaskViewModel> lstTasks = new List<TaskViewModel>();
        //    lstTasks = controller.GetTasks(1).ToList();
        //    Assert.IsNotNull(lstTasks);
        //    controller.Dispose();

        //    _testCounter.Increment();
        //}



        //[PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1200, TestMode = TestMode.Test, SkipWarmups = true)]
        //[CounterMeasurement("TaskTestCounter")]
        //[GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //[MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        //[Test]
        //public void AddTask_NunitTest()
        //{
        //    var controller = new TasksController();

        //    TaskViewModel obj = new TaskViewModel { TaskDesc = "TestTask1", ParentID = null, ProjectID = 1, StartDate = DateTime.Now.ToString(), EndDate = DateTime.Now.AddMonths(1).ToString(), Priority = 1, Status = "Pending", UserID = 1 };
        //    IHttpActionResult result = controller.PostTask(obj);

        //    var createResult = result as CreatedAtRouteNegotiatedContentResult<TaskViewModel>;

        //    int id = Convert.ToInt32(createResult.RouteValues["id"]);


        //    var result2 = controller.GetTask(id) as OkNegotiatedContentResult<TaskViewModel>;


        //    Assert.IsNotNull(result2);
        //    Assert.AreEqual(obj.TaskDesc, result2.Content.TaskDesc);
        //    controller.Dispose();
        //    _testCounter.Increment();
        //}

        //[PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1200, TestMode = TestMode.Test, SkipWarmups = true)]
        //[CounterMeasurement("TaskTestCounter")]
        //[GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //[MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        //[Test]
        //public void UpdateTask_NunitTest()
        //{
        //    var controller = new TasksController();

        //    var result = controller.GetTask(1) as OkNegotiatedContentResult<TaskViewModel>;
        //    Assert.IsNotNull(result);

        //    result.Content.TaskDesc = "UpdatedTaskDesc";
        //    result.Content.UserID = 1;

        //    var result2 = controller.PutTask(result.Content.TaskID, result.Content);

        //    var result3 = controller.GetTask(1) as OkNegotiatedContentResult<TaskViewModel>;
        //    Assert.IsNotNull(result3);

        //    Assert.AreEqual("UpdatedTaskDesc", result3.Content.TaskDesc);
        //    controller.Dispose();
        //    _testCounter.Increment();

        //}

        //[PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 1200, TestMode = TestMode.Test, SkipWarmups = true)]
        //[CounterMeasurement("TaskTestCounter")]
        //[GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        //[MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        //[Test]
        //public void EndTask_NunitTest()
        //{
        //    var controller = new TasksController();

        //    var result2 = controller.EndTask(1);

        //    var result3 = controller.GetTask(1) as OkNegotiatedContentResult<TaskViewModel>;
        //    Assert.IsNotNull(result3);

        //    Assert.AreEqual("Completed", result3.Content.Status);
        //    controller.Dispose();
        //    _testCounter.Increment();

        //}
    }
}
