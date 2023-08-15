namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public virtual List<SubActivity> SubActivities { get; set; }
    }

    public class SubActivity
    {
        public Guid Id { get; set; }
        public string SubTitle { get; set; }
    }
}