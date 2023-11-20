using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PointOfSale.Models;
using PointOfSale.Services;
using PointOfSale.Services.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace PointOfSale.Controllers;

public class OrderProductsController : ControllerBase
{
    private readonly IOrderProductServices _orderProductServices;
    
    public OrderProductsController(IOrderProductServices orderProductServices)
    {
        _orderProductServices = orderProductServices;
    }
    
    [HttpGet]
    [SwaggerOperation(Summary = "Get all order products")]
    [SwaggerResponse(200, "Order products found", typeof(IEnumerable<OrderProduct>))]
    public IActionResult Get()
    {
        var orderProducts = _orderProductServices.GetAllOrderProducts();
        return Ok(orderProducts);
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get an order product by id")]
    [SwaggerResponse(200, "Order product found", typeof(OrderProduct))]
    public IActionResult Get(int id)
    {
        var orderProduct = _orderProductServices.GetOrderProductById(id);
        return Ok(orderProduct);
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Create an order product")]
    [SwaggerResponse(200, "Order product created", typeof(OrderProduct))]
    public IActionResult Post(CreateOrderProductRequest request)
    {
        var orderProduct = _orderProductServices.CreateOrderProduct(request);
        return Ok(orderProduct);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update an order product")]
    [SwaggerResponse(200, "Order product updated", typeof(OrderProduct))]
    public IActionResult Put(int id, UpdateOrderProductRequest request)
    {
        var orderProduct = _orderProductServices.UpdateOrderProduct(id, request);
        return Ok(orderProduct);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete an order product")]
    [SwaggerResponse(200, "Order product deleted", typeof(bool))]
    public bool Delete(int id)
    {
        return _orderProductServices.DeleteOrderProduct(id);
    }
    
}