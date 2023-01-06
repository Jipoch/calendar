using System;

namespace Calendar
{
    class Reminder:CalendarEvent
    {
        public Reminder(string title, string description, DateTime dateTime) : base(title, description)
        {
            Title = title;
            Description = description;
            EventStart = dateTime.ToString("HH:mm:ss");
        }

        public string EventStart { get; set; }
    }
}
