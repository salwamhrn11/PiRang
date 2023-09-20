using System.ComponentModel.DataAnnotations;

namespace PiRang_WPF.Model
{
    public class WargaDesa
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}