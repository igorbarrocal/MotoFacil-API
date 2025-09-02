using MotoFacilAPI.Domain.ValueObjects;

namespace MotoFacilAPI.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public Email Email { get; private set; }

        // Navegação
        public List<Moto> Motos { get; private set; } = new();

        private Usuario() { Nome = string.Empty; Email = new Email("noone@example.com"); }

        public Usuario(string nome, Email email)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.", nameof(nome));

            Nome = nome.Trim();
            Email = email;
        }

        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("Nome é obrigatório.", nameof(novoNome));
            Nome = novoNome.Trim();
        }

        public void AlterarEmail(Email novoEmail) => Email = novoEmail;

        public void AdicionarMoto(Moto moto)
        {
            if (moto is null) throw new ArgumentNullException(nameof(moto));
            if (moto.UsuarioId != Id) moto.DefinirDono(Id);
            Motos.Add(moto);
        }
    }
}