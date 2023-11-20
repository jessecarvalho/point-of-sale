using Microsoft.AspNetCore.Mvc;
using PointOfSale.Models;
using PointOfSale.Services;
using PointOfSale.Services.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace PointOfSale.Controllers;

[ApiController]
[Route("/api/product-categories")]
public class ProductCategoriesController : ControllerBase
{
    private readonly IProductCategoryService _productCategoryService;
    
    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    
    [HttpGet]
    [SwaggerOperation(Summary = "Get all product categories")]
    [SwaggerResponse(200, "Product categories found", typeof(IEnumerable<ProductCategory>))]
    public IActionResult Get()
    {
        var productCategories = _productCategoryService.GetAllProductCategories();
        return Ok(productCategories);
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a product category by id")]
    [SwaggerResponse(200, "Product category found", typeof(ProductCategory))]
    public IActionResult Get(int id)
    {
        var productCategory = _productCategoryService.GetProductCategoryById(id);
        return Ok(productCategory);
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Create a product category")]
    [SwaggerResponse(200, "Product category created", typeof(ProductCategory))]
    public IActionResult Post(CreateProductCategoryRequest request)
    {
        var productCategory = _productCategoryService.CreateProductCategory(request);
        return Ok(productCategory);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update a product category")]
    [SwaggerResponse(200, "Product category updated", typeof(ProductCategory))]
    public IActionResult Put(int id, UpdateProductCategoryRequest request)
    {
        var productCategory = _productCategoryService.UpdateProductCategory(id, request);
        return Ok(productCategory);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a product category")]
    [SwaggerResponse(200, "Product category deleted", typeof(bool))]
    public bool Delete(int id)
    {
        return _productCategoryService.DeleteProductCategory(id);
    }
    
}