using System.Collections.Generic;

namespace TestConscensia.Models.Dto
{
    public class OfficeLocationDto
    {
        public long Id { get; set; }

        public string CountryCode { get; set; }

        public int OfficeNumber { get; set; }

        public List<ReportCodeDto> ReportCodes { get; set; } = new List<ReportCodeDto>();
    }
}