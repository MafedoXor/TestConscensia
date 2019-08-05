using TestConscensia.Abstractions.DataServices;
using TestConscensia.Abstractions.Mapper;
using TestConscensia.Data;
using TestConscensia.Data.Base;
using TestConscensia.Data.Entities;
using TestConscensia.Models.Domain;

namespace TestConscensia.Services.DataServices
{
    public class OfficeLocationDataService : DataServiceBase<OfficeLocation, OfficeLocationEntity>, IOfficeLocationDataService
    {
        public OfficeLocationDataService(IAppMapper appMapper) : base(appMapper)
        {
        }

        protected override IRepository<OfficeLocationEntity> GetRepository(UnitOfWork unit)
        {
            return unit.OfficeLocationRepository;
        }
    }
}