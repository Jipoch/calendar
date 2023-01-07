namespace Calendar
{
    class CalendarEvent
    {
        public CalendarEvent(string title, string description)
        {
            Title = title;
            Description = description;
        }

        // Заголовок события
        public string Title { get; set; }

        // Описание события
        public string Description { get; set; }
    }
}
