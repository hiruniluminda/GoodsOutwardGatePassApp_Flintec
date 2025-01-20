using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.WebUtilities;

namespace GatePassApplicaation.Models
{
    public class PassHeaderAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassNo { get; set; }
        public int ReasonId { get; set; }
        [ForeignKey("ReasonId")]
        public Reasons Reasons { get; set; }
        public string takenBy { get; set; }
        public string SendTo { get; set; }
        public DateOnly DateTime { get; set; }
        public string Facility { get; set; }
        public string SupplierName { get; set; }
        public string PreparedPerson { get; set; }
        public string Department { get; set; }
        public string AuthorizedPerson { get; set; }
        public ICollection<PassNoteAdmin> PassDetails { get; set; }

    }
}
