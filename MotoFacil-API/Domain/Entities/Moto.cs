using MotoFacilAPI.Domain.Enums;

namespace MotoFacilAPI.Domain.Entities
{
    /// <summary>
    /// Entidade Moto (Agregado Raiz)
    /// </summary>
    public class Moto
    {
        public int Id { get; private set; }
        public ModeloMoto Modelo { get; private set; }
        public string Marca { get; private set; }
        public int UsuarioId { get; private set; } // FK para dono da moto

        // Navegação (opcional)
        public List<Servico> Servicos { get; private set; } = new();

        private Moto() { } // EF

        public Moto(ModeloMoto modelo, string marca, int usuarioId)
        {
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("Marca é obrigatória.", nameof(marca));

            Modelo = modelo;
            Marca = marca.Trim();
            UsuarioId = usuarioId;
        }

        /// <summary>
        /// Atualiza a marca da moto
        /// </summary>
        public void AtualizarMarca(string novaMarca)
        {
            if (string.IsNullOrWhiteSpace(novaMarca))
                throw new ArgumentException("Marca é obrigatória.", nameof(novaMarca));
            Marca = novaMarca.Trim();
        }

        /// <summary>
        /// Atualiza o modelo da moto
        /// </summary>
        public void AtualizarModelo(ModeloMoto novoModelo)
        {
            Modelo = novoModelo;
        }
    }
}