using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using PointOfSale.Services;
using PointOfSale.Services.DTOs;

namespace PointOfSale.UnitTests;

[TestClass]
public class ClientTests
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
        }
    }
    
    [TestMethod]
    public void GetAllClients_Returns_ListOfClients()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "GetAllClients_Returns_ListOfClients")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var clientService = new ClientService(context);
        
        //act
        var result = clientService.GetAllClients();
        
        //assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(IEnumerable<Client>));
    }
    
    [TestMethod]
    public void GetClientById_Returns_Client()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "GetClientById_Returns_Client")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var clientService = new ClientService(context);
        
        //act
        var result = clientService.GetClientById(1);
        
        //assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Client));
    }
    
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void GetClientById_Throws_Exception_When_ClientNotFound()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "GetClientById_Throws_Exception_When_ClientNotFound")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var clientService = new ClientService(context);
        
        //act
        var result = clientService.GetClientById(3);
        
        //assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void CreateClient_Returns_Client()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "CreateClient_Returns_Client")
            .Options;
        var context = new PointOfSaleContext(options);
        var clientService = new ClientService(context);
        var request = new CreateClientRequest
        {
            Name = "Client 1",
            Email = "cliente@teste.com",
            Phone = "123456789",
            Address = "Rua 1",
            Document = "123456789",
        };

        //act
        var result = clientService.CreateClient(request);

        //assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(Client));
    }

    [TestMethod]
    public void UpdateClient_Returns_Client()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "UpdateClient_Returns_Client")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var clientService = new ClientService(context);
        var request = new UpdateClientRequest
        {
            Name = "Client 1",
            Email = "cliente@teste.com",
            Phone = "123456789",
            Address = "Rua 1",
            Document = "123456789",
        };
    }
    
    [TestMethod]
    public void DeleteClient_Returns_True()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "DeleteClient_Returns_True")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var clientService = new ClientService(context);
        
        //act
        var result = clientService.DeleteClient(1);
        
        //assert
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void DeleteClient_Returns_False()
    {
        //arrange
        var options = new DbContextOptionsBuilder<PointOfSaleContext>()
            .UseInMemoryDatabase(databaseName: "DeleteClient_Returns_False")
            .Options;
        var context = new PointOfSaleContext(options);
        PointOfSaleContextInitializer.Initialize(context);
        var clientService = new ClientService(context);
        
        //act
        var result = clientService.DeleteClient(3);
        
        //assert
        Assert.IsFalse(result);
    }
}