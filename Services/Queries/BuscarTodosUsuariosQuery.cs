using CadastroUsuarios.Models;
using CadastroUsuarios.Repository.Interfaces;
using MediatR;

namespace CadastroUsuarios.Services.Queries
{
    public class BuscarTodosUsuariosQuery : IRequest<IEnumerable<Usuario>>
    {
        public class BuscarTodosUsuariosQueryHandler : IRequestHandler<BuscarTodosUsuariosQuery, IEnumerable<Usuario>>
        {
            private readonly IUsuarioRepository _context;
            private readonly IMediator _mediator;

            public BuscarTodosUsuariosQueryHandler(IUsuarioRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<IEnumerable<Usuario>> Handle(BuscarTodosUsuariosQuery query, CancellationToken cancellationToken)
            {
                var usuarioList = await _context.BuscarTodosUsuarios();

                if (usuarioList == null)
                {
                    return default;
                }
                return usuarioList;
            }
        }
    }
}
