using PointOfSale.Models;
using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;

public class ClientService : IClientService
{
    private readonly PointOfSaleContext _context;
    
    public ClientService(PointOfSaleContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Client> GetAllClients()
    {
        return _context.Clients.ToList();
    }
    
    public Client GetClientById(int id)
    {
        var client = _context.Clients.Find(id);
        if (client == null)
        {
            throw new Exception("Client not found");
        }
        return client;
    }
    
    public Client CreateClient(CreateClientRequest request)
    {
        var client = new Client
        {
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address,
            Document = request.Document,
        };
        _context.Clients.Add(client);
        _context.SaveChanges();
        return client;
    }
    
    public Client UpdateClient(int id, UpdateClientRequest request)
    {
        var client = _context.Clients.Find(id);
        if (client == null)
        {
            throw new Exception("Client not found");
        }
        client.Name = request.Name;
        client.Email = request.Email;
        client.Phone = request.Phone;
        client.Address = request.Address;
        client.Document = request.Document;
        _context.SaveChanges();
        return client;
    }
    
    public bool DeleteClient(int id)
    {
        var client = _context.Clients.Find(id);
        if (client == null)
        {
            return false;
        }
        _context.Clients.Remove(client);
        _context.SaveChanges();
        return true;
    }
    
}