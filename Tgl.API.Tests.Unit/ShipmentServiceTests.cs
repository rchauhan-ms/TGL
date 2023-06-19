using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using Tgl.API.Services;
using Tgl.Data.Repositories;
using Tgl.Shared.Domain;
using Xunit;

namespace Tgl.API.Tests.Unit
{
    public class ShipmentServiceTests
    {
        private readonly ShipmentService _sut;
        private readonly IShipmentRepository _shipmentRepository = Substitute.For<IShipmentRepository>();
        private readonly ILogger<IUserFilterService> _logger = Substitute.For<ILogger<IUserFilterService>>();

        public ShipmentServiceTests()
        {
            _sut = new ShipmentService(_shipmentRepository, _logger);
        }

        [Fact]
        public async void GetAllAsync_ShouldReturnsEmptyShipmentSummaries_WhenNoShipmentExist()
        {
            //Arrange
            _shipmentRepository.GetAllAsync().Returns(Array.Empty<ShipmentSummary>());

            //Act
            var shipmentSummaries = await _sut.GetAllAsync();
            
            //Assert
            shipmentSummaries.Should().BeEquivalentTo(Array.Empty<ShipmentSummary>());
        }

        [Fact]
        public async void GetAllAsync_ShouldReturnsShipmentSummary_WhenShipmentSummaryExist()
        {
            //Arrange
            var expectedShipmentSummaries = new[]
            {
                new ShipmentSummary()
                    {
                        ShippingId = 2015149,
                        ActionMessage = "PENDING DELIVERY",
                        DeliveryStatuses = new Dictionary<string, DeliveryStatusEnum>()
                        {
                            { "REGISTERED", DeliveryStatusEnum.Completed },
                            { "AT ORIGIN", DeliveryStatusEnum.Completed },
                            { "IN TRANSIT", DeliveryStatusEnum.Completed },
                            { "ARRIVAL", DeliveryStatusEnum.Current },
                            { "DELIVERY", DeliveryStatusEnum.Pending }
                        },
                        ShippingCompany = "SATECHI CO LTD",
                        TrackingNumbers = new []{ "POAU000657" },
                        ShipmentFilter = new ShipmentFilter()
                        {
                             FromLocation = new City{ Id = 4, Name = "Sydney"},
                             ToLocation = new City{ Id = 3, Name = "Shanghai"},
                             FromDate = "31 Mar 2023",
                             ToDate = "14 May 2023"
                        },
                        ShippingCost = 2000.00
                    }
            };
            _shipmentRepository.GetAllAsync().Returns(expectedShipmentSummaries);

            //Act
            var shipmentSummaries = await _sut.GetAllAsync();

            //Assert
            shipmentSummaries.Should().ContainSingle(x => x.ShippingId == 2015149);
        }
    }
}
