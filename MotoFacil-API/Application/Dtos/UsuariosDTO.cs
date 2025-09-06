namespace MotoFacilAPI.Application.Dtos
{
    /// <summary>
    /// DTO para Usuário (Swagger: exemplos e descrição)
    /// </summary>
    public class UsuarioDto
    {
        /// <example>1</example>
        public int Id { get; set; }
        /// <example>Igor Barrocal</example>
        public string Nome { get; set; } = string.Empty;
        /// <example>igor@email.com</example>
        public string Email { get; set; } = string.Empty;

        // HATEOAS
        public List<LinkDto>? Links { get; set; }
    }

    public class LinkDto
    {
        public string Href { get; set; } = string.Empty;
        public string Rel { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public LinkDto(string href, string rel, string method) { Href = href; Rel = rel; Method = method; }
        public LinkDto() { }
    }
}