
public abstract class BaseItem
{

    public string Title { get; set; }
    public Remind Remind { get; set; }
    public string Title { get; set; }
    public string Title { get; set; }
    public string Title { get; set; }
    public string Title { get; set; }
    public string Title { get; set; }
    public string Title { get; set; }
    public string Title { get; set; }
    public string Title { get; set; }
    public string Title { get; set; }
    + Title 
    + Time
    + Reminder
    + isRepeat
    +Priority
    + TrackProgress :TODO
    +Label 
    + Note
}

public enum Remind
{
    None = 0,
    OnTime,
    5Min ,
    10Min,
    15Min, 
    30Min,
        1Hour,
        1Day


}
