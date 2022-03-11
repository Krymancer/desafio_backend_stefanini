using Crud.Application.CityService.Models.Dtos;
using Crud.Application.Common;

namespace Crud.Application.CityService.Models.Response

{
    public class GetAllCityResponse: BaseResponse
    {
        public ICollection<CityDto> Cities { get; set; }
    }
}
