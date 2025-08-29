using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoFacilAPI.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // garante auto-incremento
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
