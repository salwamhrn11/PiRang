using System.ComponentModel.DataAnnotations;

namespace PiRang_WPF.Model
{
    public class PerangkatDesa
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}