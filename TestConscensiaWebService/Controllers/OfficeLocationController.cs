using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TestConscensia.Abstractions.DataServices;
using TestConscensia.Abstractions.Mapper;
using TestConscensia.Models.Dto;
using TestConscensiaWebService.Utilities;

namespace TestConscensiaWebService.Controllers
{
    public class OfficeLocationController : ApiController
    {
        private readonly IAppMapper _appMapper;
        private readonly IOfficeLocationDataService _officeLocationDataService;

        public OfficeLocationController(IAppMapper appMapper, IOfficeLocationDataService officeLocationDataService)
        {
            _appMapper = appMapper;
            _officeLocationDataService = officeLocationDataService;
        }

        [Route("api/OfficeLocation/GetAll")]
        public async Task<IEnumerable<OfficeLocationDto>> GetAll()
        {
            var locations = await _officeLocationDataService.GetAll();
            if (locations.Count() == 0)
            {
                locations = LocationFakeGeneration.GenerateFakeList();

                await _officeLocationDataService.AddRange(locations);
            }

            var mapped = _appMapper.Map<IEnumerable<OfficeLocationDto>>(locations);

            return mapped;
        }
    }
}