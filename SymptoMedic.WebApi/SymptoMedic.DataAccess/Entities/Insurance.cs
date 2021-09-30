using System;
using System.Collections.Generic;

#nullable disable

namespace SymptoMedic.DataAccess.Entities
{
    public partial class Insurance
    {
        public Insurance()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string ProviderId { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
