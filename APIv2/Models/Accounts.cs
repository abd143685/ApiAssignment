using System.ComponentModel.DataAnnotations;

namespace APIv2.Models
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage="Too Long")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be 11 digits.")]
        public string Phone { get; set; }
    }
}
