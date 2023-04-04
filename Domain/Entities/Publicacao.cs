using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Publicacao : BaseEntity
    {
        public string Titulo { get; set; }
        public string Area { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public string DataPublicacao { get; set; }
    }
}
