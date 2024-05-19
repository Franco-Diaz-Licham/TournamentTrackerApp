namespace TrackerWPFUI;

public static class EventAggregationProvider
{
    public static EventAggregator TrackerEventAggregator { get; set; } = new();
}
