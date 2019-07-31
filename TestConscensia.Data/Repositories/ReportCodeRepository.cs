using TestConscensia.Data.Base;
using TestConscensia.Data.Entities;

namespace TestConscensia.Data.Repositories
{
    public class ReportCodeRepository : GenericRepository<ReportCodeEntity>
    {
        public ReportCodeRepository(IDbContext context) : base(context)
        {

        }
    }
}
