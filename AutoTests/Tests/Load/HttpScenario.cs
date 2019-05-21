using NBomber.Contracts;
using NBomber.CSharp;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToptalTestAutomation.Tests.Load
{
    public class HttpScenario
    {
        public static Scenario BuildScenario()
        {
            
            var step = Step.Create("GET html",ConnectionPool.None, async _ =>
            {
                await Task.Delay(TimeSpan.FromSeconds(0.1));
                return Response.Ok();
            });

            return ScenarioBuilder.CreateScenario("test_gitter", step);
        }
    }
}
