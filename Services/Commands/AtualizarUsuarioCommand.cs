using CadastroUsuarios.Data.Enums;
using CadastroUsuarios.Repository.Interfaces;
using CadastroUsuarios.Services.Notifications;
using MediatR;

namespace CadastroUsuarios.Services.Commands
{
    public class AtualizarUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Genero Genero { get; set; }
    }

    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _context;
        private readonly IMediator _mediator;

        public AtualizarUsuarioCommandHandler(IUsuarioRepository context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> Handle(AtualizarUsuarioCommand command, CancellationToken cancellationToken)
        {
            var usuario = await _context.BuscarUsuarioPorId(command.Id);

            if (usuario == null)
            {
                return default;
            }
            usuario.Nome = command.Nome;
            usuario.Email = command.Email;
            usuario.Genero = command.Genero;

            await _context.Atualizar(usuario, usuario.Id);

            await _mediator.Publish(new UsuarioActionNotification
            {
                Nome = command.Nome,
                Email = command.Email,
                Action = ActionNotification.Atualizado
            }, cancellationToken);

            return usuario.Id;
        }

    }
}

