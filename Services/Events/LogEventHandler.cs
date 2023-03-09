using CadastroUsuarios.Services.Notifications;
using MediatR;

namespace CadastroUsuarios.Services.Events
{
    public class LogEventHandler : INotificationHandler<UsuarioActionNotification>, INotificationHandler<ErrorNotification>
    {
        public Task Handle(UsuarioActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Usuário {notification.Nome} - {notification.Email} foi {notification.Action.ToString().ToLower()} com sucesso!");
            });
        }
        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERROR : '{notification.Error} \n {notification.Stack}'");
            });
        }


    }
}
