public abstract class BaseItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Remind Remind { get; set; }
    public bool IsRepeat { get; set; }
    public Priority Priority { get; set; }
    public List<Label> Labels { get; set; } = new List<Label>();
    public string Note { get; set; } = string.Empty;
}

