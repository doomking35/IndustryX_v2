using System.Data;
using System.Text.Json;
using IndustryX.LogisticsService.Core.DTOs;
using IndustryX.LogisticsService.Core.Entities;
using IndustryX.LogisticsService.Core.Entities.Records;

namespace IndustryX.LogisticsService.Services;

public class ShipmentService
{
    private readonly Shipment _shipment;
    private readonly ILogger<ShipmentService> _logger;
    private List<Shipment> ShipmentList = [];
    public ShipmentService(Shipment shipment, ILogger<ShipmentService> logger)
    {
        _shipment = shipment ?? throw new ArgumentNullException(nameof(shipment));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        ShipmentList.Add(shipment);
        _logger.LogInformation($"Shipment with id: {_shipment.ShipmentId} is initialized.");
    }
    public ShipmentService(ILogger<ShipmentService> logger) : this(
        new Shipment
        {
            CustomerInfo = new CustomerInfo(),
            ShipmentAddress = new ShipmentAddress(Int32.MaxValue),
            ShipmentDescription = "",
            ShipmentId = Int32.MaxValue
        },
        logger)
    {
        FillShipments();
    }
    public IEnumerable<ShipmentDto> GetAllShipments()
    {
        return ShipmentList.Select(x => new ShipmentDto()
        {
            ShipmentId = x.ShipmentId, ShipmentAddress = x.ShipmentAddress, ShipmentDescription = x.ShipmentDescription
        }).ToArray();
    }
    public async Task<ShipmentDto> GetShipmentWithCustomerInfo(CustomerInfo customerInfo)
    {
        var testShipment = ShipmentList.First();
        testShipment.CustomerInfo = customerInfo;
        
        return await Task.FromResult(new ShipmentDto()
        {
            ShipmentId = testShipment.ShipmentId,
            ShipmentAddress = testShipment.ShipmentAddress,
            ShipmentDescription = testShipment.ShipmentDescription
        });
    }

    public async Task<ShipmentDto?> GetShipmentWithShipmentId(int shipmentId)
    {
        var shipment = ShipmentList
            .FirstOrDefault(x => x.ShipmentId == shipmentId);

        if (shipment == null)
            return null;

        return await Task.FromResult(new ShipmentDto
        {
            ShipmentId = shipment.ShipmentId,
            ShipmentAddress = shipment.ShipmentAddress,
            ShipmentDescription = shipment.ShipmentDescription
        });
    }

    public async Task<List<ShipmentDto>> AddShipment(List<Shipment> shipments)
    {
        var lastShipmentId = ShipmentList.LastOrDefault()?.ShipmentId ?? 0;
        foreach (var shipment in shipments)
        {
            shipment.ShipmentId = ++lastShipmentId;
            ShipmentList.Add(shipment);
        }
        return await Task.FromResult(
            shipments.Select(x => new ShipmentDto()
            {
                ShipmentId = x.ShipmentId,
                ShipmentAddress = x.ShipmentAddress,
                ShipmentDescription = x.ShipmentDescription
            }).ToList());
    }

    #region Private Section
    private void FillShipments()
    {
        for (int i = 0; i < 100; i++)
        {

            var testShipment = new Shipment()
            {
                ShipmentId = i,
                ShipmentDescription = $"TEST{i}",
                ShipmentAddress = new ShipmentAddress(ShipmentId: i)
                {
                    ZipCode = 35610,
                    City = "Izmir",
                    CityId = 35,
                    Province = "Çiğli",
                    AdditionalAddress1 = "8925 sokak Evka-5"
                },
                CustomerInfo = new CustomerInfo()
            };
            ShipmentList.Add(testShipment);
        }
    }
    #endregion
}