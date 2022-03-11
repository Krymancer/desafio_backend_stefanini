using Crud.Application.CityService.Models.Request;
using Crud.Application.CityService.Models.Response;

namespace Crud.Application.CityService.Service
{
    public interface ICityService
    {
        Task<GetAllCityResponse> GetAllAsync();
        Task<GetByIdCityResponse> GetByIdAsync(Guid id);
        Task<CreateCityResponse> CreateAsync(CreateCityRequest request);
        Task<UpdateCityResponse> UpdateAsync(Guid id, UpdateCityRequest request);
        Task<DeleteCityResponse> DeleteAsync(Guid id);
    }
}
