using System.ComponentModel.DataAnnotations;

namespace MotoFacilAPI.Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public List<LinkDto> Links { get; set; } = new();
    }
}