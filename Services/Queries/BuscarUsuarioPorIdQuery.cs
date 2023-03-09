using CadastroUsuarios.Models;
using CadastroUsuarios.Repository.Interfaces;
using MediatR;

namespace CadastroUsuarios.Services.Queries
{
    public class BuscarUsuarioPorIdQuery : IRequest<Usuario>
    {
        public int Id { get; set; }
        public class BuscarUsuarioPorIdQueryHandler : IRequestHandler<BuscarUsuarioPorIdQuery, Usuario>
        {
            private readonly IUsuarioRepository _context;
            private readonly IMediator _mediator;

            public BuscarUsuarioPorIdQueryHandler(IUsuarioRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<Usuario> Handle(BuscarUsuarioPorIdQuery query, CancellationToken cancellationToken)
            {
                var usuario = await _context.BuscarUsuarioPorId(query.Id);

                if (usuario == null)
                {
                    return default;
                }
                return usuario;
            }
        }
    }
}
