public class DtoTaskEditingInfo
{
    public int UserID { get; set; }
    public int TaskID { get; set; }
    public int? ParentID { get; set; }
    public int AssignedToID { get; set; }
    public string TaskTitle { get; set; } = "";
    public string? TaskDescription { get; set; }
    public bool IsCompleted { get; set; }
    public int? CompletedByID { get; set; }
    public DateTime? CompletedDate { get; set; }
    public bool IsDefaultExpanded { get; set; }
}