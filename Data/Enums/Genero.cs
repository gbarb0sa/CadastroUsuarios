using System.ComponentModel;

namespace CadastroUsuarios.Data.Enums
{
    public enum Genero
    {
        [Description("Masculino")]
        Masculino = 1,
        [Description("Feminino")]
        Feminino = 2,
        [Description("Não definido")]
        NãoDefinido = 3
    }
}
