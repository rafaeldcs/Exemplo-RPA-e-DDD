using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
    }
}
