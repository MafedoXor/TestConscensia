using System.Collections.Generic;
using System.Linq;
using TestConscensia.Models.Domain;

namespace TestConscensiaWebService.Utilities
{
    public static class LocationFakeGeneration
    {
        public static IEnumerable<OfficeLocation> GenerateFakeList()
        {
            List<OfficeLocation> list = new List<OfficeLocation>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(new OfficeLocation()
                {
                    CountryCode = "UA",
                    OfficeNumber = i
                });

                list.Add(new OfficeLocation()
                {
                    CountryCode = "US",
                    OfficeNumber = i
                });

                list.Add(new OfficeLocation()
                {
                    CountryCode = "GE",
                    OfficeNumber = i
                });

                list.Add(new OfficeLocation()
                {
                    CountryCode = "DE",
                    OfficeNumber = i
                });
            }

            return list.OrderBy(x => x.CountryCode).ThenBy(x => x.OfficeNumber);
        }
    }
}