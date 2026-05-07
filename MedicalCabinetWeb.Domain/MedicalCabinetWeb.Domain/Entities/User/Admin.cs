
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalCabinetWeb.Domain.Entities.User
{
    public class Admin
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        
        [Required]
        public int UserAccountId { get; set; }

        [ForeignKey(nameof(UserAccountId))]
        public UserAccount UserAccount { get; set; } = null!;
    }
}
