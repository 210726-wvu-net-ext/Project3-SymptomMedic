using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public class Insurance
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public int ProviderId { get; set; }

        public List<Client> Clients { get; set; }
    }
}
