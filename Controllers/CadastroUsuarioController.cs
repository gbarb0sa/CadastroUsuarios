using CadastroUsuarios.Services.Commands;
using CadastroUsuarios.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroUsuarioController : ControllerBase
    {
        private IMediator _mediator;
        public CadastroUsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Add(AdicionarUsuarioCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new BuscarTodosUsuariosQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new BuscarUsuarioPorIdQuery { Id = id });

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await _mediator.Send(new DeletarUsuarioCommand { Id = id });

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateById(AtualizarUsuarioCommand command, int id)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
