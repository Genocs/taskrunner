﻿using Genocs.TaskRunner.Service.ExternalServices;
using Genocs.TaskRunner.Service.Tests.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Genocs.TaskRunner.Service.Tests
{
    public class ValidationServiceCallerIntegrationTests : IDisposable, IClassFixture<ResiliencyEnvironmentVariablesFixture>
    {
        private const string DeliveryHost = "deliveryhost";
        private static readonly string DeliveryUri = $"http://{DeliveryHost}/api/Deliveries/";

        private readonly TestServer _testServer;
        private RequestDelegate _handleHttpRequest = ctx => Task.CompletedTask;

        private readonly ISimpleAuthServiceCaller _caller;

        public ValidationServiceCallerIntegrationTests()
        {
            var context = new HostBuilderContext(new Dictionary<object, object>());
            context.Configuration =
                new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string> { ["SERVICE_URI_DELIVERY"] = DeliveryUri })
                    .AddEnvironmentVariables()
                    .Build();
            context.HostingEnvironment =
                Mock.Of<Microsoft.Extensions.Hosting.IHostEnvironment>(e => e.EnvironmentName == "Test");

            var serviceCollection = new ServiceCollection();
            ServiceStartup.ConfigureServices(context, serviceCollection);
            serviceCollection.AddLogging(builder => builder.AddDebug());

            _testServer =
                new TestServer(
                     new WebHostBuilder()
                        .UseTestServer()
                        .Configure(builder =>
                        {
                            builder.Run(ctx => _handleHttpRequest(ctx));
                        })
                        .ConfigureServices(builder =>
                        {
                            builder.AddControllers();
                        }));
            _testServer.AllowSynchronousIO = true;

            serviceCollection.Replace(
                ServiceDescriptor.Transient<HttpMessageHandlerBuilder, TestServerMessageHandlerBuilder>(
                    sp => new TestServerMessageHandlerBuilder(_testServer)));
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _caller = serviceProvider.GetService<ISimpleAuthServiceCaller>();
        }

        public void Dispose()
        {
            _testServer.Dispose();
        }

        //[Fact]
        //public async Task WhenSchedulingDelivery_ThenInvokesDeliveryAPI()
        //{
        //    string actualDeliveryId = null;
        //    DeliverySchedule actualDeliverySchedule = null;
        //    _handleHttpRequest = ctx =>
        //    {
        //        if (ctx.Request.Host.Host == DeliveryHost)
        //        {
        //            actualDeliveryId = ctx.Request.Path;
        //            actualDeliverySchedule =
        //                new JsonSerializer().Deserialize<DeliverySchedule>(new JsonTextReader(new StreamReader(ctx.Request.Body, Encoding.UTF8)));
        //            ctx.Response.StatusCode = StatusCodes.Status201Created;
        //        }
        //        else
        //        {
        //            ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
        //        }

        //        return Task.CompletedTask;
        //    };

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };
        //    await _caller.ChangeTransactionStatusAsync(delivery, "someDroneId");

        //    Assert.NotNull(actualDeliveryId);
        //    Assert.Equal($"/api/Deliveries/{delivery.DeliveryId}", actualDeliveryId);

        //    Assert.NotNull(actualDeliverySchedule);
        //    Assert.Equal(delivery.DeliveryId, actualDeliverySchedule.Id);
        //    Assert.Equal((int)delivery.ConfirmationRequired, (int)actualDeliverySchedule.ConfirmationRequired);
        //    Assert.Equal(delivery.Expedited, actualDeliverySchedule.Expedited);
        //    Assert.Equal(delivery.OwnerId, actualDeliverySchedule.Owner.UserId);
        //    Assert.Equal("someDroneId", actualDeliverySchedule.DroneId);
        //}

        //[Fact]
        //public async Task WhenDeliveryAPIReturnsCreated_ThenReturnsGeneratedSchedule()
        //{
        //    _handleHttpRequest = async ctx =>
        //    {
        //        if (ctx.Request.Host.Host == DeliveryHost)
        //        {
        //            await ctx.WriteResultAsync(
        //                new ObjectResult(
        //                    new DeliverySchedule { Id = "someDeliveryId" })
        //                {
        //                    StatusCode = StatusCodes.Status201Created
        //                });
        //        }
        //        else
        //        {
        //            ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
        //        }
        //    };

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };
        //    var actualDeliverySchedule = await _caller.ChangeTransactionStatusAsync(delivery, "someDroneId");

        //    Assert.NotNull(actualDeliverySchedule);
        //    Assert.Equal("someDeliveryId", actualDeliverySchedule.Id);
        //}

        //[Fact]
        //public async Task WhenPackageAPIDoesNotReturnOK_ThenThrows()
        //{
        //    _handleHttpRequest = ctx =>
        //    {
        //        if (ctx.Request.Host.Host == DeliveryHost)
        //        {
        //            ctx.Response.StatusCode = StatusCodes.Status400BadRequest;
        //        }
        //        else
        //        {
        //            ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
        //        }

        //        return Task.CompletedTask;
        //    };

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };

        //    await Assert.ThrowsAsync<BackendServiceCallFailedException>(() => _caller.ChangeTransactionStatusAsync(delivery, "someDroneId"));
        //}
    }
}
