using GatePassApplicaation.Models;

public class PassHeaderViewModel
{
    public PassHeader PassHeader { get; set; }
    public Reasons Reasons { get; set; }
    public ICollection<PassNote> PassDetails { get; set; }
}
