using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tgl.API.Services;
using Tgl.Data.Repositories;
using Xunit;

namespace Tgl.API.Tests.Unit
{
    public class ShipmentControllerTests
    {
        private readonly ShipmentService _sut;
        private readonly IShipmentRepository _shipmentRepository = Substitute.For<ShipmentRepository>();
        private readonly ILogger<IUserFilterService> _logger = Substitute.For<ILogger<IUserFilterService>>();

        public ShipmentControllerTests()
        {
            _sut = new ShipmentService(_shipmentRepository, _logger);
        }

        [Fact]
        public void GetAllAsync_ShouldReturnsEmptyShipmentSummaries_WhenNoShipmentExist()
        {
            //arrange

            //act

            //assert
        }

        [Fact]
        public void GetAllAsync_ShouldReturnsShipmentSummaries_WhenShipmentSummaryExist()
        {
        }

        [Fact]
        public void GetFilteredShipmentsAsync_ShouldReturnsFilteredShipmentSummaries_WhenUserFilterPassedIn()
        {
        }
    }
}
