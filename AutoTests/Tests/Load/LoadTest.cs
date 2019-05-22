using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NBomber.Contracts;
using NBomber.CSharp;
using System.Net.Http;

namespace ToptalTestAutomation.Tests.Load
{
    [TestFixture]
    public class LoadTest
    {

        [SetUp]
        public void Setup()
        {
        }

        Scenario BuildScenario()
        {
            var httpClient = new HttpClient();
            var step = Step.Create("simple step",ConnectionPool.None, async context =>
            {
                var response = await httpClient.GetAsync(
                    "https://nbomber.com",
                    context.CancellationToken);

                return response.IsSuccessStatusCode
                    ? Response.Ok(sizeBytes: (int)response.Content.Headers.ContentLength.Value)
                    : Response.Fail();                
            });

            return ScenarioBuilder.CreateScenario("Basic load test", step);
        }

        [Test]
        [Category("Load")]
        public void Test()
        {
            var assertions = new[] {
               Assertion.ForStep("simple step", stats => stats.OkCount > 2000, "OkCount > 2000"),
               Assertion.ForStep("simple step", stats => stats.RPS > 100, "RPS > 100"),
               Assertion.ForStep("simple step", stats => stats.Mean < 5000, "Max request time < 4000"),                              
            };

            var scenario = BuildScenario()
                .WithConcurrentCopies(1000)
                .WithWarmUpDuration(TimeSpan.FromSeconds(0))
                .WithDuration(TimeSpan.FromSeconds(15))
                .WithAssertions(assertions);

            NBomberRunner.RegisterScenarios(scenario)
                         .RunTest();
        }

        [TearDown]
        public void End()
        { }
    }
}
