using MotoFacilAPI.Models;

namespace MotoFacilAPI.Dtos
{
    public class MotoDto
    {
        public int Id { get; set; }
        public ModeloMoto Modelo { get; set; }  // enum
        public string Marca { get; set; } = null!;
        public int UsuarioId { get; set; }
    }
}
