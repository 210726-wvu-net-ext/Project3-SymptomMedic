using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public interface IClientRepo
    {
        Task<List<Client>> GetClients();
        Task<Client> UpdateClient(int id, Client client);

        Task<Client> AddAClient(Client client);

        Task<Client> ClientLoginAsync(Client user);

        Task<Client> GetClientById(int id);

        bool UniqueEmail(string email);

    }
}
