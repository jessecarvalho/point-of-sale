using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Services;
using PointOfSale.Services.DTOs;

namespace PointOfSale.UnitTests;

[TestClass]
public class OrderTests
{

    public class PointOfSaleContextInitializer
    {
        public static void Initialize(PointOfSaleContext context)
        {
            context.Clients.Add(new Client
            {
                Id = 1, Name = "Client 1", Email = "coolclient@cool.com", Phone = "123456789", Address = "Rua 1",
                Document = "123456789"
            });
            context.Clients.Add(new Client
            {
                Id = 2, Name = "Client 1", Email = "alotmorecoolclient@cool.com", Phone = "987654321",
                Address = "Rua 1", Document = "987654321"
            });
            context.Products.Add(new Product
            {
                Id = 1, Name = "Product 1", ShortDescription = "Short description 1", Description = "Description 1",
                Price = 1, PromotionalPrice = 1, CategoryId = 1, Brand = "Brand 1", Stock = 1, BarCode = "BarCode 1"
            });
            context.Products.Add(new Product
            {
                Id = 2, Name = "Product 2", ShortDescription = "Short description 2", Description = "Description 2",
                Price = 2, PromotionalPrice = 2, CategoryId = 2, Brand = "Brand 2", Stock = 2, BarCode = "BarCode 2"
            });
            context.Orders.Add(new Order
            {
                Id = 1, ClientId = 1, Bill = 1, Paid = true, Date = DateTime.Now
            });
            context.Orders.Add(new Order
            {
                Id = 2, ClientId = 2, Bill = 2, Paid = false, Date = DateTime.Now
            });
            context.OrderProducts.Add(new OrderProduct
            {
                Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, Price = 1
            });
            context.OrderProducts.Add(new OrderProduct
            {
                Id = 2, OrderId = 2, ProductId = 2, Quantity = 2, Price = 2
            });
        }

    }
    
    [TestMethod]
    public void GetAllOrders_Returns_ListOfOrders()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "GetAllOrders_Returns_ListOfOrders")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var orderService = new OrderServices(context);
        
        //act
        var result = orderService.GetAllOrders();
        
        //assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(IEnumerable<Order>));
    }
    
    [TestMethod]
    public void GetOrderById_Returns_Order()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "GetOrderById_Returns_Order")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var orderService = new OrderServices(context);
        
        //act
        var result = orderService.GetOrderById(1);
        
        //assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Order));
    }
    
    [TestMethod]
    public void GetOrderById_Returns_Null()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "GetOrderById_Returns_Null")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var orderService = new OrderServices(context);
        
        //act
        var result = orderService.GetOrderById(3);
        
        //assert
        Assert.IsNull(result);
    }
    
    [TestMethod]
    public void CreateOrder_Returns_Order()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "CreateOrder_Returns_Order")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var orderService = new OrderServices(context);
        var request = new CreateOrderRequest
        {
            ClientId = 1, Bill = 1, Paid = true, Date = DateTime.Now
        };
        
        //act
        var result = orderService.CreateOrder(request);
        
        //assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Order));
    }
    
    [TestMethod]
    public void UpdateOrder_Returns_Order()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "UpdateOrder_Returns_Order")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var orderService = new OrderServices(context);
        var request = new UpdateOrderRequest
        {
            Bill = 1, Paid = true, Date = DateTime.Now
        };
        
        //act
        var result = orderService.UpdateOrder(1, request);
        
        //assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Order));
    }
    
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void UpdateOrder_Throws_Exception_When_OrderNotFound()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "UpdateOrder_Throws_Exception_When_OrderNotFound")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var orderService = new OrderServices(context);
        var request = new UpdateOrderRequest
        {
            Bill = 1, Paid = true, Date = DateTime.Now
        };
        
        //act
        var result = orderService.UpdateOrder(3, request);
        
        //assert
        Assert.IsNull(result);
    }
    
    [TestMethod]
    public void DeleteOrder_Returns_True()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "DeleteOrder_Returns_True")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var orderService = new OrderServices(context);
        
        //act
        var result = orderService.DeleteOrder(1);
        
        //assert
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void DeleteOrder_Throws_Exception_When_OrderNotFound()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "DeleteOrder_Throws_Exception_When_OrderNotFound")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var orderService = new OrderServices(context);
        
        //act
        var result = orderService.DeleteOrder(3);
        
        //assert
        Assert.IsFalse(result);
    }

}