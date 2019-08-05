using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestConscensia.Data.Base;

namespace TestConscensia.Data.Entities
{
    public class OfficeLocationEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string CountryCode { get; set; }

        public int OfficeNumber { get; set; }

        public List<ReportCodeEntity> ReportCodes { get; set; }

        public override string ToString()
        {
            return CountryCode.ToString() + OfficeNumber.ToString().PadLeft(2, '0');
        }
    }
}