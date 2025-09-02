using MotoFacilAPI.Domain.Enums;

namespace MotoFacilAPI.Domain.Entities
{
    public class Moto
    {
        public int Id { get; private set; }
        public ModeloMoto Modelo { get; private set; }
        public string Marca { get; private set; } = string.Empty;
        public int UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public List<Servico> Servicos { get; private set; } = new();

        private Moto() { }

        public Moto(ModeloMoto modelo, string marca, int usuarioId)
        {
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("Marca é obrigatória.", nameof(marca));

            Modelo = modelo;
            Marca = marca.Trim();
            UsuarioId = usuarioId;
        }

        public void AtualizarMarca(string novaMarca)
        {
            if (string.IsNullOrWhiteSpace(novaMarca))
                throw new ArgumentException("Marca é obrigatória.", nameof(novaMarca));
            Marca = novaMarca.Trim();
        }

        public void DefinirDono(int usuarioId) => UsuarioId = usuarioId;
    }
}