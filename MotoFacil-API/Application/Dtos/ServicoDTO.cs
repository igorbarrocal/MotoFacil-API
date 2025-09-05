namespace MotoFacil_API.Application.Dtos
{
    /// <summary>
    /// DTO para Serviço (Swagger: exemplos e descrição)
    /// </summary>
    public class ServicoDto
    {
        /// <example>1</example>
        public int Id { get; set; }
        /// <example>Troca de óleo</example>
        public string Descricao { get; set; }
        /// <example>2025-09-05T10:30:00Z</example>
        public DateTime Data { get; set; }
        /// <example>3</example>
        public int UsuarioId { get; set; }
        /// <example>8</example>
        public int MotoId { get; set; }
    }
}