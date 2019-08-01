using TestConscensia.Data.Base;
using TestConscensia.Data.Entities;

namespace TestConscensia.Data.Repositories
{
    public class OfficeLocationRepository : GenericRepository<OfficeLocationEntity>
    {
        public OfficeLocationRepository(IDbContext context) : base(context)
        {

        }
    }
}