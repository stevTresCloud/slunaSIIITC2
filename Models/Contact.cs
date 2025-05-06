using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slunaSIIITC2.Models
{
    public class Contact
    {
        public string IdentificationType { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public double IESSContribution => Math.Round(Salary * 0.0945, 2);
    }
}
