using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCabinetWeb.Domain.Entities.User
{
    public class Patient
    {
        public int Id { get; set; }

         
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Sex { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
       public PatientStatus Status { get; set; }

    }
}
