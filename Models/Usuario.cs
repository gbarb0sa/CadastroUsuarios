using CadastroUsuarios.Data.Enums;

namespace CadastroUsuarios.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get;  set; }
        public Genero? Genero { get; set; }
    }
}
