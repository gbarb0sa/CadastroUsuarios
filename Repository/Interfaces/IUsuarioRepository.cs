using CadastroUsuarios.Models;

namespace CadastroUsuarios.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarUsuarioPorId(int id);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario, int id);
        Task<bool> Deletar(int id);

    }
}
