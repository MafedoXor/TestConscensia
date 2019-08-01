using System;

namespace TestConscensia.Models.Dto
{
    public class ReportCodeDto
    {
        public long Id { get; set; }

        public OfficeLocationDto Location { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
