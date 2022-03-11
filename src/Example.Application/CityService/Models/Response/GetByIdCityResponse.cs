using Crud.Application.Common;
using Crud.Application.CityService.Models.Dtos;

namespace Crud.Application.CityService.Models.Response
{
    public class GetByIdCityResponse : BaseResponse
    {
        public CityDto City { get; set; }
    }
}
