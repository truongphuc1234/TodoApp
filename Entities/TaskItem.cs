public class TaskItem : BaseItem
{
    public Status Status {get;set;}
    public DateTimeOffset? StartAt{get;set;}
    public DateTimeOffset? EndAt {get;set;}
}
