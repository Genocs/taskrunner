using System;

namespace Genocs.TaskRunner.Service.Tests
{
    public class ResiliencyEnvironmentVariablesFixture
    {
        public ResiliencyEnvironmentVariablesFixture()
        {
            Environment.SetEnvironmentVariable("SERVICEREQUEST__MAXRETRIES", "3");
            Environment.SetEnvironmentVariable("SERVICEREQUEST__CIRCUITBREAKERTHRESHOLD", "0.75");
            Environment.SetEnvironmentVariable("SERVICEREQUEST__CIRCUITBREAKERSAMPLINGPERIODSECONDS", "5");
            Environment.SetEnvironmentVariable("SERVICEREQUEST__CIRCUITBREAKERMINIMUMTHROUGHPUT", "2");
            Environment.SetEnvironmentVariable("SERVICEREQUEST__CIRCUITBREAKERBREAKDURATIONSECONDS", "5");
            Environment.SetEnvironmentVariable("SERVICEREQUEST__MAXBULKHEADSIZE", "5");
            Environment.SetEnvironmentVariable("SERVICEREQUEST__MAXBULKHEADQUEUESIZE", "3");
        }
    }
}
