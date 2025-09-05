public class DtoProjectCreationInfo
{
    public int UserID { get; set; }
    public string ProjectTitle { get; set; } = "";
    public string? ProjectDescription { get; set; }
    public bool IsDefaultExpanded { get; set; }
}