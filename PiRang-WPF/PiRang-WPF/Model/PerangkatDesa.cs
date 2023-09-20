using System.ComponentModel.DataAnnotations;

namespace PiRang_WPF.Model
{
    public class PerangkatDesa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}