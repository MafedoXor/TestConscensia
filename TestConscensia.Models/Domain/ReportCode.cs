using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConscensia.Models.Domain
{
    public class ReportCode
    {
        public long Id { get; set; }

        public OfficeLocation Location { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}