namespace CleanDemo.API.Filters
{
    [AttributeUsage((AttributeTargets.Method)]
    public class LimitRequest:Attribute
    {
        public int TimeWindow { get; set; }
        public int MaxRequests { get; set; }
    }
}
