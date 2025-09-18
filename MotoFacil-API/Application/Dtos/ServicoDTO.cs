using System.ComponentModel.DataAnnotations;

namespace MotoFacilAPI.Application.Dtos
{
    public class ServicoDto
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int MotoId { get; set; }

        public List<LinkDto> Links { get; set; } = new();
    }
}