﻿using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Controllers;
using TestWebApi.Models;

namespace NunitApiTest
{
    //public class DictionaryThroughputTests : PerformanceTestStuite<DictionaryThroughputTests>
    //{
    //    private readonly Dictionary<int, int> dictionary = new Dictionary<int, int>();

    //    private const string AddCounterName = "AddCounter";
    //    private Counter addCounter;
    //    private int key;

    //    private const int AcceptableMinAddThroughput = 1000;

    //    [PerfSetup]
    //    public void Setup(BenchmarkContext context)
    //    {
    //        addCounter = context.GetCounter(AddCounterName);
    //        key = 0;
    //    }

    //    [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
    //    [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
    //    public void AddThroughput_ThroughputMode(BenchmarkContext context)
    //    {
    //        dictionary.Add(key++, key);
    //        addCounter.Increment();
    //    }
    //    //[PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
    //    //[CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
    //    //public void GetProject_ThroughputMode(BenchmarkContext context)
    //    //{
    //    //    addCounter.Increment();
    //    //    var controller = new ProjectsController();
    //    //    List<ProjectViewModel> lstProject = new List<ProjectViewModel>();
    //    //    lstProject = controller.GetProjects().ToList();
    //    //}

    //    //[PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
    //    //[CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
    //    //public void AddThroughput_IterationsMode(BenchmarkContext context)
    //    //{
    //    //    for (var i = 0; i < AcceptableMinAddThroughput; i++)
    //    //    {
    //    //        dictionary.Add(i, i);
    //    //        addCounter.Increment();
    //    //    }
    //    //}

    //    [PerfCleanup]
    //    public void Cleanup(BenchmarkContext context)
    //    {
    //        dictionary.Clear();
    //    }
    //}
}
