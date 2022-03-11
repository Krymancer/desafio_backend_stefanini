using Crud.Domain.CityAggregate;

namespace Crud.Application.CityService.Models.Dtos
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }

        public static explicit operator CityDto(City c)
        {
            return new CityDto()
            {
                Id = c.Id,
                Name = c.Name,
                UF = c.UF
            };
        }
    }
}
