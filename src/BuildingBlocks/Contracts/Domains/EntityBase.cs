using Contracts.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domains
{
    public class EntityBase<IKey> : IEntityBase<IKey>
    {
        public IKey Id { set; get; }
    }
}
