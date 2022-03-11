namespace Crud.Application.PersonService.Models.Request
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public int Age { get; set; }
        public Guid CityId { get; set; }
    }
}
