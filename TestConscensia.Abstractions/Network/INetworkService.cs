using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestConscensia.Models.Domain;

namespace TestConscensia.Abstractions.Network
{
    public interface INetworkService
    {
        Task<IEnumerable<ReportCode>> GetAllReportCodes(CancellationToken token);

        Task<IEnumerable<OfficeLocation>> GetAllOfficeLocations(CancellationToken token);

        Task<ReportCode> CreateNewReportCode(OfficeLocation officeLocation, CancellationToken token);

        Task<IEnumerable<ReportCode>> GetReportCodesByLocation(string officeLocation, CancellationToken token);
    }
}