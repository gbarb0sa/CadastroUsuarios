using MediatR;

namespace CadastroUsuarios.Services.Notifications
{
    public class UsuarioActionNotification : INotification
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public ActionNotification Action { get; set; }

    }
}
