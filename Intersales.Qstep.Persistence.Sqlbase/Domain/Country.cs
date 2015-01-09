using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersales.Qstep.Persistence.Sqlbase.Domain
{
    public class Country
    {
        public virtual int? Id { get; set; }
        public virtual String Name { get; set; }
        public virtual String BankAbbreviation { get; set; }
    }
}
