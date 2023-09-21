using System.ComponentModel.DataAnnotations;

namespace PiRang_WPF.Model
{
    public class WargaDesa
    {
        [Key] 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}