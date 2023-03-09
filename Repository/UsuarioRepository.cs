using CadastroUsuarios.Data;
using CadastroUsuarios.Models;
using CadastroUsuarios.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarios.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CadastroUsuarioDbContext _context;
        public UsuarioRepository(CadastroUsuarioDbContext cadastroUsuariosDbContext)
        {
            _context = cadastroUsuariosDbContext;
        }

        public async Task<IEnumerable<Usuario>> BuscarTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> BuscarUsuarioPorId(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarUsuarioPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o código de identificação:{id} não encontrado na base de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Genero = usuario.Genero;

            _context.Usuarios.Update(usuarioPorId);
            await _context.SaveChangesAsync();

            return usuarioPorId;
        }
        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
        public async Task<bool> Deletar(int id)
        {
            Usuario usuarioPorId = await BuscarUsuarioPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o código de identificação:{id} não encontrado na base de dados.");
            }
            _context.Usuarios.Remove(usuarioPorId);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}



