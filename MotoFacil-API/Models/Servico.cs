using MotoFacilAPI.Models;

namespace MotoFacilAPI.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public DateTime Data { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int MotoId { get; set; }
        public Moto? Moto { get; set; }
    }
}
