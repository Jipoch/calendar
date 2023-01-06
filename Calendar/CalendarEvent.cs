namespace Calendar
{
    class CalendarEvent
    {
        public CalendarEvent(string title, string description)
        {
            Title = title;
            Description = description;
            EventStart = "";
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string EventStart { get; set; }
    }
}
