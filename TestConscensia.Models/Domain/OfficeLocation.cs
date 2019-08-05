using System.Collections.Generic;
using TestConscensia.Models.Base;

namespace TestConscensia.Models.Domain
{
    public class OfficeLocation : IBaseModel
    {
        public long Id { get; set; }

        public string CountryCode { get; set; }

        public int OfficeNumber { get; set; }

        public List<ReportCode> ReportCodes { get; set; } = new List<ReportCode>();

        public override string ToString()
        {
            return CountryCode.ToString() + OfficeNumber.ToString().PadLeft(2, '0');
        }
    }
}