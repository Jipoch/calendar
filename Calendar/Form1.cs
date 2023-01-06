using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            timePicker.Value = DateTime.Now;
        }
        private void CalendarEventProcessor(object sender, EventArgs e)
        {
            BuildEventsOnScreen(GetList(dateTimePicker1.Value));
        }

        private void BuildEventsOnScreen(BindingList<CalendarEvent> calendarEventsByDate)
        {

            dataGridView1.DataSource = calendarEventsByDate;
        }


        public Form1()
        {
            InitializeComponent();
            InitializeDictionary();
            InitializeTimePickers();
            InitializeTimer();
        }

        private DateTimePicker timePicker;

        private Dictionary<string, BindingList<CalendarEvent>> calendarEvents;

        private void InitializeTimePickers()
        {
            timePicker = new DateTimePicker();
            timePicker.ShowCheckBox = false;
            timePicker.ShowUpDown = false;
            timePicker.Enabled = false;
            timePicker.Location = new Point(10, 10);
            timePicker.Width = 280;

            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "MMMM dd, yyyy - dddd  HH:mm:ss";
            Controls.Add(timePicker);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd  HH:mm:ss";
            dateTimePicker1.ValueChanged += new EventHandler(CalendarEventProcessor);
        }

        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Start();
        }

        private void InitializeDictionary()
        {
            calendarEvents = new Dictionary<string, BindingList<CalendarEvent>>();

            BindingList<CalendarEvent> list = new BindingList<CalendarEvent>();
            list.Add(new Holiday("holiday 1", "description of holiday 1"));
            list.Add(new Reminder("reminder 1", "description of reminder 1", DateTime.Now));
            list.Add(new Holiday("holiday 2", "description of holiday 2"));
            calendarEvents["2023-01-06"] = list;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void radioReminder_CheckedChanged(object sender, EventArgs e)
        {
            timePickerCreate.Enabled = true;
        }

        private void radioHoliday_CheckedChanged(object sender, EventArgs e)
        {
            timePickerCreate.Enabled = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textTitle.Text) || string.IsNullOrEmpty(textDescription.Text))
            {
                MessageBox.Show("Provide correct input");
                return;
            }

            BindingList<CalendarEvent> list = GetList(dateTimePicker1.Value);

            if (radioReminder.Checked)
            {
                Reminder evnt = new Reminder(textTitle.Text, textDescription.Text, timePickerCreate.Value);
                list.Add(evnt);
            } else
            {
                Holiday evnt = new Holiday(textTitle.Text, textDescription.Text);
                list.Add(evnt);
            }
        }


        private BindingList<CalendarEvent> GetList(DateTime date)
        {
            BindingList<CalendarEvent> calendarEventsByDate;

            if (calendarEvents.TryGetValue(date.ToString("yyyy-MM-dd"), out calendarEventsByDate))
            {
                Console.WriteLine(calendarEventsByDate);
                return calendarEventsByDate;
            }
            else
            {
                return new BindingList<CalendarEvent>();
            }
        }
    }
}
