using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestConscensia.Models.Domain;

namespace TestConscensia.Abstractions.Common
{
    public interface IQualityReportManager
    {
        Task<ReportCode> CreateNew(OfficeLocation officeLocation);

        Task<ReportCode> GetLatest();

        Task<IEnumerable<ReportCode>> GetByOfficeLocations(string officeLocation);

        Task<IEnumerable<ReportCode>> GetByDateRange(DateTime? from, DateTime? to);

        Task<long> GetCountByDateRange(DateTime? from, DateTime? to);
    }
}