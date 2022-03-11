using Crud.Application.PersonService.Models.Request;
using Crud.Application.PersonService.Models.Response;

namespace Crud.Application.PersonService.Service
{
    public interface IPersonService
    {
        Task<GetAllPersonResponse> GetAllAsync();
        Task<GetByIdPersonResponse> GetByIdAsync(Guid id);
        Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request);
        Task<UpdatePersonResponse> UpdateAsync(Guid id, UpdatePersonRequest request);
        Task<DeletePersonResponse> DeleteAsync(Guid id);
    }
}
