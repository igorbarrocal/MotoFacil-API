namespace MotoFacilAPI.Dtos
{
    public class ServicoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public int MotoId { get; set; }
    }
}
