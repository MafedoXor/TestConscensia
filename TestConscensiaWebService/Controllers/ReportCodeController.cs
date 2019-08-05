using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TestConscensia.Abstractions.Common;
using TestConscensia.Abstractions.DataServices;
using TestConscensia.Abstractions.Mapper;
using TestConscensia.Models.Domain;
using TestConscensia.Models.Dto;

namespace TestConscensiaWebService.Controllers
{
    public class ReportCodeController : ApiController
    {
        private readonly IAppMapper _appMapper;
        private readonly IReportCodeDataService _reportCodeDataService;
        private readonly IQualityReportManager _qualityReportManager;

        public ReportCodeController(IAppMapper appMapper, IReportCodeDataService reportCodeDataService, IQualityReportManager qualityReportManager)
        {
            _appMapper = appMapper;
            _reportCodeDataService = reportCodeDataService;
            _qualityReportManager = qualityReportManager;
        }

        [HttpPost]
        [Route("api/ReportCode/CreateNew")]
        public async Task<ReportCodeDto> CreateNew(OfficeLocationDto officeLocationDto)
        {
            var code = await _qualityReportManager.CreateNew(_appMapper.Map<OfficeLocation>(officeLocationDto));

            var mapped = _appMapper.Map<ReportCodeDto>(code);

            return mapped;
        }

        [HttpGet]
        [Route("api/ReportCode/GetAll")]
        public async Task<IEnumerable<ReportCodeDto>> GetAll()
        {
            var codes = await _reportCodeDataService.GetAll();

            var mapped = _appMapper.Map<IEnumerable<ReportCodeDto>>(codes);

            return mapped;
        }

        [HttpGet]
        [Route("api/ReportCode/GetByDateRange/{from}/{to}")]
        public async Task<IEnumerable<ReportCodeDto>> GetByDateRange([FromUri]DateTime? from, [FromUri]DateTime? to)
        {
            var codes = await _reportCodeDataService.GetByDateRange(from, to);

            var mapped = _appMapper.Map<IEnumerable<ReportCodeDto>>(codes);

            return mapped;
        }

        [HttpGet]
        [Route("api/ReportCode/GetLatest")]
        public async Task<ReportCodeDto> GetLatest()
        {
            var codes = await _reportCodeDataService.GetLatest();

            var mapped = _appMapper.Map<ReportCodeDto>(codes);

            return mapped;
        }

        [HttpGet]
        [Route("api/ReportCode/GetByLocation/{officeLocation}")]
        public async Task<IEnumerable<ReportCodeDto>> GetByLocation([FromUri]string officeLocation)
        {
            var codes = await _reportCodeDataService.GetByLocation(officeLocation);

            var mapped = _appMapper.Map<IEnumerable<ReportCodeDto>>(codes);

            return mapped;
        }

        [HttpGet]
        [Route("api/ReportCode/GetCountByDateRange/{from}/{to}")]
        public async Task<long> GetCountByDateRange([FromUri]DateTime? from, [FromUri]DateTime? to)
        {
            var codes = await _reportCodeDataService.GetCountByDateRange(from, to);

            return codes;
        }
    }
}