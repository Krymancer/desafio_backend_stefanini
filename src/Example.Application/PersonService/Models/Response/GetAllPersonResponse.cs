using Crud.Application.Common;
using Crud.Application.PersonService.Models.Dtos;

namespace Crud.Application.PersonService.Models.Response
{
    public class GetAllPersonResponse: BaseResponse
    {
        public ICollection<PersonDto> Persons { get; set; }
    }
}
