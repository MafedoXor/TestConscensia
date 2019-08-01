using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConscensia.Models.Domain
{
    public class OfficeLocation
    {
        public long Id { get; set; }

        public string CountryCode { get; set; }

        public int OfficeNumber { get; set; }

        public List<ReportCode> ReportCodes { get; set; } = new List<ReportCode>();
    }
}