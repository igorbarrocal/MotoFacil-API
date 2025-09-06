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
        /// <example>MottuSport</example>
        public ModeloMoto Modelo { get; set; }
        /// <example>Honda</example>
        public string Marca { get; set; } = string.Empty;
        /// <example>42</example>
        public int UsuarioId { get; set; }

        // HATEOAS
        public List<LinkDto>? Links { get; set; }
    }
}