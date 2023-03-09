using CadastroUsuarios.Repository.Interfaces;
using CadastroUsuarios.Services.Notifications;
using MediatR;

namespace CadastroUsuarios.Services.Commands
{
    public class DeletarUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeletarUsuarioCommandHandler : IRequestHandler<DeletarUsuarioCommand, int>
        {
            private readonly IUsuarioRepository _context;
            private readonly IMediator _mediator;

            public DeletarUsuarioCommandHandler(IUsuarioRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<int> Handle(DeletarUsuarioCommand command, CancellationToken cancellationToken)
            {
                var usuario = await _context.BuscarUsuarioPorId(command.Id);

                if (usuario == null)
                {
                    return default;
                }

                await _context.Deletar(usuario.Id);

                return usuario.Id;
            }
        }
    }
}
