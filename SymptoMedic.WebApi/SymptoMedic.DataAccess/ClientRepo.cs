using Microsoft.EntityFrameworkCore;
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

        // Get Clients
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
                clients.Email
             )
        ).ToList());

        }

        //Add A Client
        public async Task<Domain.Client> AddAClient(Domain.Client client)
        {
            if (UniqueEmail(client.Email) is true)
            {
                throw new Exception($"Email {client.Email} has been already used");
            }

            var newEntity = new Entities.Client
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Password = client.Password,
                Gender = client.Gender,
                ContactMobile = client.ContactMobile,
                Address = client.Address,
                City = client.City,
                State = client.State,
                Country = client.Country,
                Zipcode = client.Zipcode,
                Birthdate = client.Birthdate,
            };
            await _context.Clients.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            client.Id = newEntity.Id;
            return client;
        }

        // Update A Client
        public async Task<Domain.Client> UpdateClient(int id, Domain.Client client)
        {
            Entities.Client foundClient = await _context.Clients.FindAsync(id);
            if (foundClient != null)
            {
                foundClient.Id = id;
                foundClient.FirstName = client.FirstName;
                foundClient.LastName = client.LastName;
                foundClient.Email = client.Email;
                foundClient.ContactMobile = client.ContactMobile;
                foundClient.Address = client.Address;
                foundClient.City = client.City;
                foundClient.State = client.State;
                foundClient.Country = client.Country;
                foundClient.Zipcode = client.Zipcode;

                _context.Clients.Update(foundClient);
                await _context.SaveChangesAsync();

                var updatedUser = await GetClientById(id);
                return updatedUser;
            }

            return new Domain.Client();
        }

        // Delete A Client
        public async Task<bool> DeleteClientById(int id)
        {
            Entities.Client clientToDelete = await _context.Clients
                .FirstOrDefaultAsync(client => client.Id == id);
            if (clientToDelete != null)
            {
                _context.Clients.Remove(clientToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        // Login As Client
        public async Task<Domain.Client> ClientLoginAsync(Domain.Client client)
        {
            Entities.Client foundClient = await _context.Clients.FirstOrDefaultAsync(c => c.Email == client.Email && c.Password == client.Password);

            if (foundClient != null)
            {
                Domain.Client loginClient = await GetClientById(foundClient.Id);
                return loginClient;
            }
            return null;
        }

        // Get Client By ID
        public async Task<Domain.Client> GetClientById(int id)
        {
            var returnedClients = await _context.Clients
                   .Include(i => i.Insurance)
                   .Include(a => a.Appointments)
                   .Select(c => new Domain.Client
                   {
                       Id = c.Id,
                       FirstName = c.FirstName,
                       LastName = c.LastName,
                       Gender = c.Gender,
                       ContactMobile = c.ContactMobile,
                       Address = c.Address,
                       City = c.City,
                       State = c.State,
                       Country = c.Country,
                       Zipcode = c.Zipcode,
                       Birthdate = c.Birthdate,
                       Email = c.Email,
                       InsuranceName = c.Insurance.ProviderName,
                       InsuranceId = c.Insurance.ProviderId,
                       Appointments = c.Appointments.Select(a => new Domain.Appointment(a.Id, a.DateCreated, a.ClientId, a.DoctorId, a.ClientFirstName, a.ClientLastName, a.ClientContact, a.PatientSymptoms, a.StartTime, a.EndTime)).ToList()
                   }
                ).ToListAsync();
            Domain.Client singleClient = returnedClients.FirstOrDefault(a => a.Id == id);



            return singleClient;
        }

        //Check If Email is Unique
        public bool UniqueEmail(string email)
        {
            if (_context.Clients.Any(client => client.Email == email))
            {
                return true;
            }
            return false;
        }

        // Add Insurance
        public async Task<Domain.Insurance> AddInsurance(Domain.Insurance insurance)
        {
            var newEntity = new Entities.Insurance
            {
                Id = insurance.Id,
                ProviderName = insurance.ProviderName,
                ProviderId = insurance.ProviderId
            };
            await _context.Insurances.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            insurance.Id = newEntity.Id;
            return insurance;
        }

        //Update Insurance
        public async Task<Domain.Insurance> UpdateInsurance(int id, Domain.Insurance insurance)
        {
            Entities.Insurance foundInsurance = await _context.Insurances.FindAsync(id);
            if (foundInsurance != null)
            {
                foundInsurance.Id = id;
                foundInsurance.ProviderName = insurance.ProviderName;
                foundInsurance.ProviderId = insurance.ProviderId;

                _context.Insurances.Update(foundInsurance);
                await _context.SaveChangesAsync();

                var updatedInsurance = await GetInsuranceById(id);
                return updatedInsurance;
            }

            return new Domain.Insurance();
        }
        public async Task<Domain.Insurance> GetInsuranceById(int id)
        {
            var returnedInsurance = await _context.Insurances
                   .Include(c => c.Clients)
                   .Select(i => new Domain.Insurance
                   {
                       Id = i.Id,
                       ProviderName = i.ProviderName,
                       ProviderId = i.ProviderId
        }
                ).ToListAsync();
            Domain.Insurance singleInsurance = returnedInsurance.FirstOrDefault(a => a.Id == id);



            return singleInsurance;
        }
    }
}
