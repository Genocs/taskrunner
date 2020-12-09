using Genocs.TaskRunner.Service.ExternalServices;
using Genocs.TaskRunner.Service.RequestProcessing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace Genocs.TaskRunner.Service.Tests
{
    public class RequestProcessorTests
    {
        private readonly Mock<IMemberServiceCaller> _memberServiceCallerMock;
        private readonly Mock<IValidationServiceCaller> _validationServiceCallerMock;
        private readonly RequestProcessor _processor;

        public RequestProcessorTests()
        {
            var servicesBuilder = new ServiceCollection();
            servicesBuilder.AddLogging(logging => logging.AddDebug());
            var services = servicesBuilder.BuildServiceProvider();

            _memberServiceCallerMock = new Mock<IMemberServiceCaller>();
            _validationServiceCallerMock = new Mock<IValidationServiceCaller>();

            _processor =
                new RequestProcessor(
                    services.GetService<ILogger<RequestProcessor>>(),
                    _validationServiceCallerMock.Object);
        }

        //[Fact]
        //public async Task WhenInvokingPackageServiceThrows_ProcessingFails()
        //{
        //    _memberServiceCallerMock
        //        .Setup(c => c.UpsertPackageAsync(It.IsAny<PackageInfo>()))
        //        .ThrowsAsync(new Exception()).Verifiable();

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };
        //    var success = await _processor.ProcessChangeTransactionStatusRequestAsync(delivery, new Dictionary<string, object>());

        //    Assert.False(success);
        //    _memberServiceCallerMock.Verify();
        //    _validationServiceCallerMock.VerifyNoOtherCalls();
        //}

        //[Fact]
        //public async Task WhenInvokingPackageServiceFails_ProcessingFails()
        //{
        //    _memberServiceCallerMock
        //        .Setup(c => c.UpsertPackageAsync(It.IsAny<PackageInfo>()))
        //        .ReturnsAsync(default(PackageGen)).Verifiable();

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };
        //    var success = await _processor.ProcessChangeTransactionStatusRequestAsync(delivery, new Dictionary<string, object>());

        //    Assert.False(success);
        //    _memberServiceCallerMock.Verify();
        //    _validationServiceCallerMock.VerifyNoOtherCalls();
        //}

        //[Fact]
        //public async Task WhenInvokingDroneSchedulerThrows_ProcessingFails()
        //{
        //    _memberServiceCallerMock
        //        .Setup(c => c.UpsertPackageAsync(It.IsAny<PackageInfo>()))
        //        .ReturnsAsync(new PackageGen { Id = "someid" }).Verifiable();

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };
        //    var success = await _processor.ProcessChangeTransactionStatusRequestAsync(delivery, new Dictionary<string, object>());

        //    Assert.False(success);
        //    _memberServiceCallerMock.Verify();
        //    _validationServiceCallerMock.VerifyNoOtherCalls();
        //}

        //[Fact]
        //public async Task WhenInvokingDroneSchedulerFails_ProcessingFails()
        //{
        //    _memberServiceCallerMock
        //        .Setup(c => c.UpsertPackageAsync(It.IsAny<PackageInfo>()))
        //        .ReturnsAsync(new PackageGen { Id = "someid" }).Verifiable();

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };
        //    var success = await _processor.ProcessChangeTransactionStatusRequestAsync(delivery, new Dictionary<string, object>());

        //    Assert.False(success);
        //    _memberServiceCallerMock.Verify();
        //    _validationServiceCallerMock.VerifyNoOtherCalls();
        //}

        //[Fact]
        //public async Task WhenInvokingDeliverySchedulerThrows_ProcessingFails()
        //{
        //    _memberServiceCallerMock
        //        .Setup(c => c.UpsertPackageAsync(It.IsAny<PackageInfo>()))
        //        .ReturnsAsync(new PackageGen { Id = "someid" }).Verifiable();
        //    _validationServiceCallerMock
        //        .Setup(c => c.ChangeTransactionStatusAsync(It.IsAny<Delivery>(), "droneId"))
        //        .ThrowsAsync(new Exception()).Verifiable();

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };
        //    var success = await _processor.ProcessChangeTransactionStatusRequestAsync(delivery, new Dictionary<string, object>());

        //    Assert.False(success);
        //    _memberServiceCallerMock.Verify();
        //    _validationServiceCallerMock.Verify();
        //}

        //[Fact]
        //public async Task WhenInvokingDeliverySchedulerFails_ProcessingFails()
        //{
        //    _memberServiceCallerMock
        //        .Setup(c => c.UpsertPackageAsync(It.IsAny<PackageInfo>()))
        //        .ReturnsAsync(new PackageGen { Id = "someid" }).Verifiable();
        //    _validationServiceCallerMock
        //        .Setup(c => c.ChangeTransactionStatusAsync(It.IsAny<Delivery>(), "droneId"))
        //        .ReturnsAsync(default(DeliverySchedule)).Verifiable();

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };
        //    var success = await _processor.ProcessChangeTransactionStatusRequestAsync(delivery, new Dictionary<string, object>());

        //    Assert.False(success);
        //    _memberServiceCallerMock.Verify();
        //    _validationServiceCallerMock.Verify();
        //}

        //[Fact]
        //public async Task WhenProcessingAValidDelivery_ProcessingSucceeds()
        //{
        //    _memberServiceCallerMock
        //        .Setup(c => c.UpsertPackageAsync(It.IsAny<PackageInfo>()))
        //        .ReturnsAsync(new PackageGen { Id = "someid" }).Verifiable();
        //    _validationServiceCallerMock
        //        .Setup(c => c.ChangeTransactionStatusAsync(It.IsAny<Delivery>(), "droneId"))
        //        .ReturnsAsync(new DeliverySchedule { Id = "someDeliveryId" }).Verifiable();

        //    var delivery =
        //        new Delivery
        //        {
        //            DeliveryId = "someDeliveryId",
        //            PackageInfo = new PackageInfo { PackageId = "somePackageId", Size = ContainerSize.Medium, Tag = "sometag", Weight = 100d }
        //        };
        //    var success = await _processor.ProcessChangeTransactionStatusRequestAsync(delivery, new Dictionary<string, object>());

        //    Assert.True(success);
        //    _memberServiceCallerMock.Verify();
        //    _validationServiceCallerMock.Verify();
        //}
    }
}
