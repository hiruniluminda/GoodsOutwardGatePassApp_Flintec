//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//namespace GatePassApplicaation.Models
//{
//    public class AuthorizedBy
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int PreparedById { get; set; }
//        public string NameOfGoods { get; set; }
//        public int ReasonId { get; set; }
//        [ForeignKey("ReasonId")]
//        public Reasons Reasons { get; set; }
//        public string Facility { get; set; }
//        public string SupplierName { get; set; }
//        public string PreparedPerson { get; set; }
//        public string AuthorizedPerson { get; set; }
//        public string Description { get; set; }
//        public string takenBy { get; set; }
//        public string SendTo { get; set; }
//        public string Department { get; set; }
//        public int LineNo { get; set; }
//        public DateOnly DateTime { get; set; }
//        public string PartNo { get; set; }
//        public int Quantity { get; set; }
//        public double Value { get; set; }
//    }
//}
