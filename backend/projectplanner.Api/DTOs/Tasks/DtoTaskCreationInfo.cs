public class DtoTaskCreationInfo
{
    public int UserID { get; set; }
    public int? ParentID { get; set; }
    public int ProjectID { get; set; }
    public int AssignedToID { get; set; }
    public string TaskTitle { get; set; } = "";
    public string? TaskDescription { get; set; }
    public bool IsDefaultExpanded { get; set; }
}