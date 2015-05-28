using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spitfire.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public virtual Country Country { get; set; }

        public virtual City City { get; set; }
    }
}
