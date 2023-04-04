using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace ApiControle.Model
{
    public class CreatePublicacao
    {
        public string Titulo { get; set; }
        public string Area { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public string DataPublicacao { get; set; }

    }
}