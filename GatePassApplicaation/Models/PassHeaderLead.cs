using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.WebUtilities;

namespace GatePassApplicaation.Models
{
    public class PassHeaderLead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PassNo { get; set; }
        public int ReasonId { get; set; }
        [ForeignKey("ReasonId")]
        public Reasons Reasons { get; set; }
        public int ActionId { get; set; }
        [ForeignKey("ActionId")]
        public Action Actions { get; set; }
        public string takenBy { get; set; }
        public string SendTo { get; set; }
        public DateOnly DateTime { get; set; }
        public string Facility { get; set; }
        public string SupplierName { get; set; }
        public string PreparedPerson { get; set; }
        public string Department { get; set; }
        public string AuthorizedPerson { get; set; }
        public ICollection<PassNoteLead> PassDetails { get; set; }


    }
}
