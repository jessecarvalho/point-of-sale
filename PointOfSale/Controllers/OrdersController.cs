using Microsoft.AspNetCore.Mvc;
using PointOfSale.Models;
using PointOfSale.Services;
using PointOfSale.Services.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace PointOfSale.Controllers;

[ApiController]
[Route("/api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderServices _orderServices;

    public OrdersController(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }
    
    [HttpGet]
    [SwaggerOperation(Summary = "Get all orders")]
    [SwaggerResponse(200, "Orders found", typeof(IEnumerable<Order>))]
    public IActionResult Get()
    {
        var orders = _orderServices.GetAllOrders();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get an order by id")]
    [SwaggerResponse(200, "Order found", typeof(Order))]
    public IActionResult Get(int id)
    {
        var order = _orderServices.GetOrderById(id);
        return Ok(order);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create an order")]
    [SwaggerResponse(200, "Order created", typeof(Order))]
    public IActionResult Post(CreateOrderRequest request)
    {
        var order = _orderServices.CreateOrder(request);
        return Ok(order);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update an order")]
    [SwaggerResponse(200, "Order updated", typeof(Order))]
    public IActionResult Put(int id, UpdateOrderRequest request)
    {
        var order = _orderServices.UpdateOrder(id, request);
        return Ok(order);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete an order")]
    [SwaggerResponse(200, "Order deleted", typeof(bool))]
    public bool Delete(int id)
    {
        return _orderServices.DeleteOrder(id);
    }
    
    

}