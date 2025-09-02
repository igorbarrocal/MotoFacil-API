namespace MotoFacilAPI.Domain.Entities
{
    public class Servico
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; } = string.Empty;
        public DateTime Data { get; private set; } = DateTime.UtcNow;
        public int UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public int MotoId { get; private set; }
        public Moto? Moto { get; private set; }

        private Servico() { }

        public Servico(string descricao, DateTime data, int usuarioId, int motoId)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição é obrigatória.", nameof(descricao));
            if (data == default) data = DateTime.UtcNow;

            Descricao = descricao.Trim();
            Data = data;
            UsuarioId = usuarioId;
            MotoId = motoId;
        }

        public void Reagendar(DateTime novaData)
        {
            if (novaData < DateTime.UtcNow.AddDays(-1))
                throw new ArgumentException("Não é permitido agendar no passado distante.");
            Data = novaData;
        }
    }
}