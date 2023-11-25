using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Services.DTOs;
using PointOfSale.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PointOfSale.Controllers;
using PointOfSale.Models;

[ApiController]
[Route("api/client")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;
    
    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    [HttpGet]
    [SwaggerOperation(Summary = "Get all clients")]
    [SwaggerResponse(200, "Clients found", typeof(IEnumerable<Client>))]
    public IActionResult GetAllClients()
    {
        var clients = _clientService.GetAllClients();
        return Ok(clients);
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a client by id")]
    [SwaggerResponse(200, "Client found", typeof(Client))]
    public IActionResult GetClientById(int id)
    {
        var client = _clientService.GetClientById(id);
        return Ok(client);
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Create a client")]
    [SwaggerResponse(200, "Client created", typeof(Client))]
    public IActionResult CreateClient(CreateClientRequest request)
    {
        var client = _clientService.CreateClient(request);
        return Ok(client);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update a client")]
    [SwaggerResponse(200, "Client updated", typeof(Client))]
    public IActionResult UpdateClient(int id, UpdateClientRequest request)
    {
        var client = _clientService.UpdateClient(id, request);
        return Ok(client);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a client")]
    [SwaggerResponse(200, "Client deleted", typeof(bool))]
    public bool DeleteClient(int id)
    {
        return _clientService.DeleteClient(id);
    }
    
}