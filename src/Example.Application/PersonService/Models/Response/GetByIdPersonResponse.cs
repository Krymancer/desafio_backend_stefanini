using Crud.Application.Common;
using Crud.Application.PersonService.Models.Dtos;

namespace Crud.Application.PersonService.Models.Response
{
    public class GetByIdPersonResponse : BaseResponse
    {
        public PersonDto Person { get; set; }
    }
}
