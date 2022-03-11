using Crud.Application.Common;
using Crud.Application.CityService.Models.Dtos;
using Crud.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Crud.Application.CityService.Models.Response;
using Crud.Application.CityService.Models.Request;
using Crud.Application.CityService.Service;

namespace Crud.Application.CityService.Service
{
    public class CityService : BaseService<CityService>, ICityService
    {
        private readonly DatabaseContext _db;

        public CityService(ILogger<CityService> logger, Infra.Data.DatabaseContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllCityResponse> GetAllAsync()
        {
            var entity = await _db.City.ToListAsync();
            return new GetAllCityResponse()
            {
                Cities = entity != null ? entity.Select(a => (CityDto)a).ToList() : new List<CityDto>()
            };
        }

        public async Task<GetByIdCityResponse> GetByIdAsync(Guid id)
        {

            var response = new GetByIdCityResponse();

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.City = (CityDto)entity;

            return response;
        }

        public async Task<CreateCityResponse> CreateAsync(CreateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newCity = new Domain.CityAggregate.City
            {
                Name = request.Name,
                UF = request.UF,
            };

            _db.City.Add(newCity);

            await _db.SaveChangesAsync();

            return new CreateCityResponse() { Id = newCity.Id };
        }

        public async Task<UpdateCityResponse> UpdateAsync(Guid id, UpdateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.UF = request.UF;
                await _db.SaveChangesAsync();
            }

            return new UpdateCityResponse();
        }

        public async Task<DeleteCityResponse> DeleteAsync(Guid id)
        {

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteCityResponse();
        }
    }
}
