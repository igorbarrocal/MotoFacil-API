using MotoFacilAPI.Models;
using System.Collections.Generic;

namespace MotoFacilAPI.Models
{
    public class Moto
    {
        public int Id { get; set; }
        public ModeloMoto Modelo { get; set; }  // agora só aceita valores do enum
        public string Marca { get; set; } = null!;
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public ICollection<Servico>? Servicos { get; set; }
    }
}
