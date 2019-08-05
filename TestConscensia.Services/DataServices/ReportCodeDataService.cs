using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestConscensia.Abstractions.DataServices;
using TestConscensia.Abstractions.Mapper;
using TestConscensia.Data;
using TestConscensia.Data.Base;
using TestConscensia.Data.Entities;
using TestConscensia.Models.Domain;

namespace TestConscensia.Services.DataServices
{
    public class ReportCodeDataService : DataServiceBase<ReportCode, ReportCodeEntity>, IReportCodeDataService
    {
        public ReportCodeDataService(IAppMapper appMapper) : base (appMapper)
        {

        }

        public async Task<List<ReportCode>> GetByDateRange(DateTime? from, DateTime? to)
        {
            using (var unit = new UnitOfWork())
            {
                return (await unit.ReportCodeRepository.GetByDateRange(from, to)).Select(MapToDomainModel).ToList();
            }
        }

        public async Task<List<ReportCode>> GetByLocation(string officeLocation)
        {
            using (var unit = new UnitOfWork())
            {
                return (await unit.ReportCodeRepository.GetByLocation(officeLocation)).Select(MapToDomainModel).ToList();
            }
        }

        public Task<long> GetCountByDateRange(DateTime? from, DateTime? to)
        {
            using (var unit = new UnitOfWork())
            {
                return unit.ReportCodeRepository.GetCountByDateRange(from, to);
            }
        }

        public async Task<ReportCode> GetLatest()
        {
            using (var unit = new UnitOfWork())
            {
                return MapToDomainModel(await unit.ReportCodeRepository.GetLatest());
            }
        }

        protected override IRepository<ReportCodeEntity> GetRepository(UnitOfWork unit)
        {
            return unit.ReportCodeRepository;
        }
    }
}