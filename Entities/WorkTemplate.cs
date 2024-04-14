public class WorkTemplate
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<WorkPeriod> Periods { get; set; } = new();
}

