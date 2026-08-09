using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Industry
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
        public virtual ICollection<Lead> Leads { get; set; } = [];
        public virtual ICollection<Company> Companies { get; set; } = [];




    }
}
