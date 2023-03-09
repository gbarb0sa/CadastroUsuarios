using System.ComponentModel;

namespace CadastroUsuarios.Services.Notifications
{
    public enum ActionNotification
    {
        [Description("Cadastrado")]
        Cadastrado = 1,
        [Description("Atualizado")]
        Atualizado = 2,
        [Description("Excluído")]
        Excluido = 3
    }
}
