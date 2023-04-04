using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace testeRobosAutomatizados.Requisicao.Models
{
    public class Publicacao
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Area { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public string DataPublicacao { get; set; }


    }
}