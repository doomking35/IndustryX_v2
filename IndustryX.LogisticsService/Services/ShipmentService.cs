using System.Data;
using System.Text.Json;
using IndustryX.LogisticsService.Core.DTOs;
using IndustryX.LogisticsService.Core.Entities;
using IndustryX.LogisticsService.Core.Entities.Records;

namespace IndustryX.LogisticsService.Services;

public class ShipmentService(Shipment shipment, ILogger<ShipmentService> logger)
{
    public ShipmentService(ILogger<ShipmentService> logger) : this(new Shipment()
    {
        CustomerInfo = new CustomerInfo(),
        ShipmentAddress = new ShipmentAddress(Int32.MaxValue),
        ShipmentDescription = "", ShipmentId = Int32.MaxValue
    }, logger)
    {
        FillShipments();
    }
    
    public readonly List<Shipment> ShipmentList = [];

    public IEnumerable<ShipmentDto> GetAllShipments()
    {
        return ShipmentList.Select(x => new ShipmentDto()
        {
            ShipmentId = x.ShipmentId, ShipmentAddress = x.ShipmentAddress, ShipmentDescription = x.ShipmentDescription
        }).ToArray();
    }
    public async Task<ShipmentDto> GetShipmentWithCustomerInfo(CustomerInfo customerInfo)
    {
        logger.LogInformation("GetShipmentWithCustomerInfo method called");
        var testShipment = ShipmentList.FirstOrDefault();
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