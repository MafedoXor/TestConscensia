using System;
using TestConscensia.Models.Base;

namespace TestConscensia.Models.Domain
{
    public class ReportCode : IBaseModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public OfficeLocation Location { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}