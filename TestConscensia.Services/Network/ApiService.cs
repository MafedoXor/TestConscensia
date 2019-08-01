using TestConscensia.Abstractions.Mapper;
using TestConscensia.Abstractions.Network;

namespace TestConscensia.Services.Network
{
    public class ApiService : IApiService
    {
        private readonly IAppMapper _appMapper;

        public ApiService(IAppMapper appMapper)
        {
            _appMapper = appMapper;
        }


    }
}