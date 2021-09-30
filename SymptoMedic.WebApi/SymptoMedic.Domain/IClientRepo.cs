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
        Task<Client> AddAClient(Client client);
        Task<Client> UpdateClient(int id, Client client);
        Task<bool> DeleteClientById(int id);
        Task<Client> ClientLoginAsync(Client user);
        bool UniqueEmail(string email);
    }
}
