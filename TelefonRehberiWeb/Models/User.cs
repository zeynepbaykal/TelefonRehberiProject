using System.ComponentModel.DataAnnotations;

namespace TelefonRehberiWeb.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }
        public string? Password { get; set; }
        public List<Rehber> RehberId { get; set; }
    }
}
