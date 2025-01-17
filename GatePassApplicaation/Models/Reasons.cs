using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GatePassApplicaation.Models
{
    public class Reasons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReasonId { get; set; }
        public string ReasonName { get; set; }
    }
}
