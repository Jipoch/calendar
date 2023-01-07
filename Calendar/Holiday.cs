namespace Calendar
{
    class Holiday: CalendarEvent
    {
        public Holiday(string title, string description) : base(title, description)
        {
            Title = title;
            Description = description;
        }
    }
}
