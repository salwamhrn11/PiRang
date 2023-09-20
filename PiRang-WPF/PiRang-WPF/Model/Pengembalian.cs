using System.ComponentModel.DataAnnotations;

namespace PiRang_WPF.Model
{
    public class Pengembalian
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NamaBarang { get; set; }
        [Required]
        public int Jumlah { get; set; }
    }
}