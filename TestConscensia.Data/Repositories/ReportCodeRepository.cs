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

            if (from == null)
                return Task.Run(() => DBSet.Where(x => x.CreationDate < to).ToList());

            if (to == null)
                return Task.Run(() => DBSet.Where(x => x.CreationDate > from).ToList());

            return Task.Run(() => DBSet.Where(x => x.CreationDate > from && x.CreationDate < to).ToList());
        }

        public async Task<ReportCodeEntity> GetLatest()
        {
            return (await GetAll()).LastOrDefault();
        }

        public Task<List<ReportCodeEntity>> GetByLocation(string countryCode, int? officeNumber)
        {
            if (countryCode == null || officeNumber == 0)
                return GetAll();

            return Task.Run(() => DBSet.Where(x => x.Location.OfficeNumber == officeNumber && x.Location.CountryCode == countryCode).ToList());
        }

        public async Task<long> GetCountByDateRange(DateTime? from, DateTime? to)
        {
            return (await GetByDateRange(from, to)).Count;
        }
    }
}