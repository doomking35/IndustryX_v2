using IndustryX.LogisticsService.Core.Entities.Records;
using IndustryX.LogisticsService.Core.DTOs;
using IndustryX.LogisticsService.Core.Entities;
using IndustryX.LogisticsService.Services;
using Microsoft.AspNetCore.Mvc;

namespace IndustryX.LogisticsService.Controllers;
[ApiController]
[Route("[controller]")]
public class ShipmentController(ILogger<ShipmentController> logger, ShipmentService shipmentService) : ControllerBase
{
    // private readonly ILogger<ShipmentController> _logger = logger;
    // private readonly ShipmentService _shipmentService = shipmentService;

    [HttpGet("GetAllShipments")]
    public IEnumerable<ShipmentDto> GetAllShipments()
    {
        logger.LogInformation("GetAllShipmentsRequested");
       return shipmentService.GetAllShipments();
    }

    [HttpGet("GetShipmentWithCustomerInfo")]
    public async Task<ShipmentDto> GetShipmentWithCustomerInfo([FromBody] CustomerInfo customerInfo)
    {
        return await shipmentService.GetShipmentWithCustomerInfo(customerInfo);
    }

    [HttpGet("GetShipmentWithShipmentId/{shipmentId}")]
    public async Task<IActionResult> GetShipmentWithShipmentId([FromRoute] int shipmentId)
    {
        logger.LogInformation($"GetShipmentWithShipmentId method called with {shipmentId}");

            var shipmentDto = await shipmentService.GetShipmentWithShipmentId(shipmentId);
            if (shipmentDto is null) throw new Exception($"GetShipmentWithShipmentID method failed for {shipmentId}");
            return Ok(shipmentDto);
    }
}