using System.ComponentModel.DataAnnotations;

namespace PiRang_WPF.Model
{
    public class Barang
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NamaBarang { get; set; }
        [Required]
        public int JumlahBarang { get; set; }
    }
}