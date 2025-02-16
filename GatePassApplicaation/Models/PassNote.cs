using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GatePassApplicaation.Models
{
    public class PassNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoodsId { get; set; }
        public string NameOfGoods { get; set; }
        //public string AuthorizedPerson { get; set; }
        public string Description { get; set; }
        public int LineNo { get; set; }
        public string PartNo { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public int PassNo { get; set; }
        public int PassHeaderId { get; set; }
        [ForeignKey("PassHeaderId")]
        public PassHeader PassHeader { get; set; }
    }
}
