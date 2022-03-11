using Crud.Application.Common;
using Crud.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Crud.Application.PersonService.Models.Dtos;
using Crud.Application.PersonService.Models.Response;
using Crud.Application.PersonService.Models.Request;

namespace Crud.Application.PersonService.Service
{
    public class PersonService : BaseService<PersonService>, IPersonService
    {
        private readonly DatabaseContext _db;

        public PersonService(ILogger<PersonService> logger, Infra.Data.DatabaseContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllPersonResponse> GetAllAsync()
        {
            var entity = await _db.Person.ToListAsync();
            return new GetAllPersonResponse()
            {
                Persons = entity != null ? entity.Select(a => (PersonDto)a).ToList() : new List<PersonDto>()
            };
        }

        public async Task<GetByIdPersonResponse> GetByIdAsync(Guid id)
        {

            var response = new GetByIdPersonResponse();

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Person = (PersonDto)entity;

            return response;
        }

        public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newPerson = new Domain.PersonAggregate.Person
            {
                Name = request.Name,
                Age = request.Age,
                CPF = request.CPF,
                CityId = request.CityId,
            };

            _db.Person.Add(newPerson);

            await _db.SaveChangesAsync();

            return new CreatePersonResponse() { Id = newPerson.Id };
        }

        public async Task<UpdatePersonResponse> UpdateAsync(Guid id, UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Age = request.Age;
                entity.CPF = request.CPF;
                entity.CityId = request.CityId;
                await _db.SaveChangesAsync();
            }

            return new UpdatePersonResponse();
        }

        public async Task<DeletePersonResponse> DeleteAsync(Guid id)
        {

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePersonResponse();
        }
    }
}
