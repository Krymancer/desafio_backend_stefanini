using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Domain.PersonAggregate
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
        public Guid CityId { get; set; }
        virtual public CityAggregate.City City { get; set; }

    }
}
