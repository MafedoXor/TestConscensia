using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestConscensia.Data.Base;

namespace TestConscensia.Data.Entities
{
    public class ReportCodeEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public OfficeLocationEntity Location { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
