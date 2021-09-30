using SymptoMedic.DataAccess.Entities;
using SymptoMedic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.DataAccess
{
    public class ClientRepo : IClientRepo
    {
        private readonly Entities.symptomedicContext _context;
        public ClientRepo(symptomedicContext context)
        {
            _context = context;
        }
        public Task<List<Domain.Client>> GetClients()
        {

            return Task.FromResult(_context.Clients.Select(
            clients => new Domain.Client
            (
                clients.Id,
                clients.FirstName,
                clients.LastName,
                clients.Password,
                clients.Gender,
                clients.ContactMobile,
                clients.Address,
                clients.City,
                clients.State,
                clients.Country,
                clients.Zipcode,
                clients.Birthdate,
                clients.Email,
                clients.InsuranceId
             )
        ).ToList());

        }
    }
}
