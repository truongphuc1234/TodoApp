static class Constants
{
    public static Lookup<Remind>[] REMINDS = new[] {
        new Lookup<Remind> {
            Id = Remind.None,
            Description = "None"
        },
        new Lookup<Remind> {
            Id = Remind.OnTime,
            Description = "On Time"
        },
        new Lookup<Remind> {
            Id = Remind.FiveMinute,
            Description = "5 Minutes"
        },
        new Lookup<Remind> {
            Id = Remind.TenMinute,
            Description = "10 Minute"
        },
        new Lookup<Remind> {
            Id = Remind.FifteenMinute,
            Description = "15 Minutes"
        },
        new Lookup<Remind> {
            Id = Remind.ThirtyMinute,
            Description = "30 Minutes"
        },
        new Lookup<Remind> {
            Id = Remind.Hour,
            Description = "1 Hour"
        },
        new Lookup<Remind> {
            Id = Remind.Day,
            Description = "1 Day"
        },
    };
    public static Lookup<Priority>[] PRIORITIES = new[] {
        new Lookup<Priority> {
            Id = Priority.None,
            Description = "None"
        },
        new Lookup<Priority> {
            Id = Priority.LowPriority,
            Description = "Low Priority"
        },
        new Lookup<Priority> {
            Id = Priority.MediumPriority,
            Description = "MediumPriority"
        },
        new Lookup<Priority> {
            Id = Priority.HighPriority,
            Description = "HighPriority"
        },
    };
}

