using MotoFacilAPI.Domain.Enums;

namespace MotoFacilAPI.Application.Dtos
{
    /// <summary>
    /// DTO para Moto (Swagger: exemplos e descrição)
    /// </summary>
    public class MotoDto
    {
        /// <example>1</example>
        public int Id { get; set; }
        /// <example>ABC1D23</example>
        public string Placa { get; set; } = string.Empty;
        /// <example>MottuSport</example>
        public ModeloMoto Modelo { get; set; }
        /// <example>42</example>
        public int UsuarioId { get; set; }
    }
}