using Crud.Domain.CityAggregate;
using Crud.Domain.PersonAggregate;

namespace Crud.Application.PersonService.Models.Dtos
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }

        public static explicit operator PersonDto(Person c)
        {
            return new PersonDto()
            {
                Id = c.Id,
                Name = c.Name,
                CPF = c.CPF,
                Age = c.Age,
                CityId = c.CityId,
                City = c.City,
            };
        }
    }
}
