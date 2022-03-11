using Crud.Application.Common;

namespace Crud.Application.PersonService.Models.Response
{
    public class CreatePersonResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}
