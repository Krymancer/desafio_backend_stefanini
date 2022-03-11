using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.CityAggregate
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }

        public virtual ICollection<PersonAggregate.Person> Persons { get; set; }

    }
}
