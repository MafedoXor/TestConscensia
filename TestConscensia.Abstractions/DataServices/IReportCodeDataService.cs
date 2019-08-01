using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TestConscensia.Models.Domain;

namespace TestConscensia.Abstractions.DataServices
{
    public interface IReportCodeDataService : IDataServiceBase<ReportCode>
    {
        Task<List<ReportCode>> GetByDateRange(DateTime? from, DateTime? to);

        Task<ReportCode> GetLatest();

        Task<List<ReportCode>> GetByLocation(string countryCode, int officeNumber);

        Task<long> GetCountByDateRange(DateTime? from, DateTime? to);
    }
}
