using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public class Insurance
    {
        public Insurance() { }
        public Insurance(int id, string providername, int providerid)
        {
            this.Id = id;
            this.ProviderName = providername;
            this.ProviderId = providerid;
        }
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public int ProviderId { get; set; }

        public List<Client> Clients { get; set; }
    }
}
