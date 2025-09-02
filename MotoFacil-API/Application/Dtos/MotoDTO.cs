using MotoFacilAPI.Domain.Enums;

namespace MotoFacilAPI.Application.Dtos
{
    public class MotoDto
    {
        public int Id { get; set; }
        public ModeloMoto Modelo { get; set; }
        public string Marca { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
    }
}