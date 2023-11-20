using Microsoft.AspNetCore.Mvc;
using PointOfSale.Models;
using PointOfSale.Services;
using PointOfSale.Services.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace PointOfSale.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all products")]
    [SwaggerResponse(200, "Products found", typeof(IEnumerable<Product>))]
    public IActionResult Get()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a product by id")]
    [SwaggerResponse(200, "Product found", typeof(Product))]
    public IActionResult Get(int id)
    {
        var product = _productService.GetProductById(id);
        return Ok(product);
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Create a product")]
    [SwaggerResponse(200, "Product created", typeof(Product))]
    public IActionResult Post(CreateProductRequest request)
    {
        var product = _productService.CreateProduct(request);
        return Ok(product);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update a product")]
    [SwaggerResponse(200, "Product updated", typeof(Product))]
    public IActionResult Put(int id, UpdateProductRequest request)
    {
        var product = _productService.UpdateProduct(id, request);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a product")]
    [SwaggerResponse(200, "Product deleted", typeof(bool))]
    public bool Delete(int id)
    {
        var product = _productService.DeleteProduct(id);
        return product;
    }
}