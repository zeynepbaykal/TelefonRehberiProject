using System.ComponentModel.DataAnnotations;

namespace TelefonRehberiWeb.Models
{
    public class Rehber
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string? Adress { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
    }
}
