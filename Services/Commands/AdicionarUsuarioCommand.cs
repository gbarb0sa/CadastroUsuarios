using CadastroUsuarios.Data.Enums;
using CadastroUsuarios.Models;
using CadastroUsuarios.Repository.Interfaces;
using CadastroUsuarios.Services.Notifications;
using MediatR;

namespace CadastroUsuarios.Services.Commands
{
    public class AdicionarUsuarioCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Genero Genero { get; set; }

        public class AdicionarUsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, int>
        {
            private readonly IUsuarioRepository _context;
            private readonly IMediator _mediator;

            public AdicionarUsuarioCommandHandler(IUsuarioRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<int> Handle(AdicionarUsuarioCommand command, CancellationToken cancellationToken)
            {
                var usuario = new Usuario();
                usuario.Nome = command.Nome;
                usuario.Email = command.Email;
                usuario.Genero = command.Genero;

                _context.Adicionar(usuario);

                await _mediator.Publish(new UsuarioActionNotification
                {
                    Nome = command.Nome,
                    Email = command.Email,
                    Action = ActionNotification.Cadastrado
                }, cancellationToken);

                return usuario.Id;
            }

        }
    }
}
