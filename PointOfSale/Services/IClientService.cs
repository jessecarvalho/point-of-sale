using PointOfSale.Models;
using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;

public interface IClientService
{
    IEnumerable<Client> GetAllClients();
    Client GetClientById(int id);
    Client CreateClient(CreateClientRequest request);
    Client UpdateClient(int id, UpdateClientRequest request);
    bool DeleteClient(int id);
}