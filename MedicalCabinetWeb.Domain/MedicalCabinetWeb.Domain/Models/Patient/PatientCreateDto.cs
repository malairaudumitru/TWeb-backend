using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCabinetWeb.Domain.Entities.User;

namespace MedicalCabinetWeb.Domain.Models.Patient
{
    public class PatientCreateDto
    {
       
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
