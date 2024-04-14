public abstract class BaseItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Remind Remind { get; set; }
    public bool IsRepeat { get; set; }
    public Priority Priority { get; set; }
    public Label? Label { get; set; }
    public string Note { get; set; } = string.Empty;
}

