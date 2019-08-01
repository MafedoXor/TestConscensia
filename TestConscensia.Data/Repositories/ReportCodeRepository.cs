using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestConscensia.Data.Base;
using TestConscensia.Data.Entities;

namespace TestConscensia.Data.Repositories
{
    public class ReportCodeRepository : GenericRepository<ReportCodeEntity>
    {
        public ReportCodeRepository(IDbContext context) : base(context)
        {

        }

        public Task<List<ReportCodeEntity>> GetByDateRange(DateTime? from, DateTime? to)
        {
            if (from == null && to == null)
                return GetAll();

            var tcs = new TaskCompletionSource<List<ReportCodeEntity>>();

            if (from == null)
            {
                tcs.SetResult(DBSet.Where(x => x.CreationDate < to).ToList());
            }
            else if (to == null)
            {
                tcs.SetResult(DBSet.Where(x => x.CreationDate > from).ToList());
            }
            else tcs.SetResult(DBSet.Where(x => x.CreationDate > from && x.CreationDate < to).ToList());

            return tcs.Task;
        }

        public async Task<ReportCodeEntity> GetLatest()
        {
            return (await GetAll()).LastOrDefault();
        }

        public Task<List<ReportCodeEntity>> GetByLocation(string countryCode, int? officeNumber)
        {
            if (string.IsNullOrWhiteSpace(countryCode) && officeNumber < 0)
                return GetAll();

            var tcs = new TaskCompletionSource<List<ReportCodeEntity>>();

            if (officeNumber >= 0)
            {
                tcs.SetResult(DBSet.Where(x => x.Location.OfficeNumber == officeNumber).ToList());
            }
            else if (!string.IsNullOrWhiteSpace(countryCode))
            {
                tcs.SetResult(DBSet.Where(x => x.Location.CountryCode == countryCode).ToList());
            }
            else tcs.SetResult(DBSet.Where(x => x.Location.OfficeNumber == officeNumber && x.Location.CountryCode == countryCode).ToList());

            return tcs.Task;
        }

        public async Task<long> GetCountByDateRange(DateTime? from, DateTime? to)
        {
            return (await GetByDateRange(from, to)).Count;
        }
    }
}