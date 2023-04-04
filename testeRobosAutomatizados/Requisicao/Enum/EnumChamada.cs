using System.ComponentModel;

namespace FuncoesComuns.Requisicao.Enum
{
    public enum EnumChamada
    {
        [Description("https://localhost:7271/api/")]
        Url,
        [Description("publicacao")]
        Publicacao
    }
}
