using GatePassApplicaation.Models;

public class ApprovedViewModel
{
    public PassHeaderLead PassHeaderLead { get; set; }
    public GatePassApplicaation.Models.Action Actions { get; set; }
    public Reasons Reasons { get; set; }
    public ICollection<PassNoteLead> PassDetails { get; set; }
}
