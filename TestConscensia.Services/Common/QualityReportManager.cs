using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestConscensia.Abstractions.Common;
using TestConscensia.Abstractions.DataServices;
using TestConscensia.Models.Domain;

namespace TestConscensia.Services.Common
{
    public class QualityReportManager : IQualityReportManager
    {
        protected const string AppId = "M";

        private readonly IReportCodeDataService _reportCodeDataService;

        public QualityReportManager(IReportCodeDataService reportCodeDataService)
        {
            _reportCodeDataService = reportCodeDataService;
        }

        public async Task<ReportCode> CreateNew(OfficeLocation officeLocation)
        {
            try
            {
                var currentDate = DateTime.Now;
                var date = new DateTime(currentDate.Year, 1, 1, 0, 0, 0, 0);
                var count = await _reportCodeDataService.GetCountByDateRange(date, null);
                var reportCode = new ReportCode
                {
                    Location = officeLocation,
                    Code = $"{AppId}{officeLocation}{currentDate.Year.ToString().Substring(2, 2)}{(count + 1).ToString().PadLeft(4, '0')}",
                    CreationDate = currentDate
                };

                await _reportCodeDataService.Add(reportCode);

                return reportCode;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<IEnumerable<ReportCode>> GetByDateRange(DateTime? from, DateTime? to)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReportCode>> GetByOfficeLocations(string officeLocation)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetCountByDateRange(DateTime? from, DateTime? to)
        {
            return _reportCodeDataService.GetCountByDateRange(from, to);
        }

        public Task<ReportCode> GetLatest()
        {
            throw new NotImplementedException();
        }
    }
}