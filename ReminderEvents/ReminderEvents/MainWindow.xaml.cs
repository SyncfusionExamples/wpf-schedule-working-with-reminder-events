using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReminderEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DateTime currentDate = DateTime.Now;

            schedule.EnableReminderTimer = true;

            schedule.Appointments.Add(new ScheduleAppointment

            {

                StartTime = DateTime.Now.Date.AddHours(9),

                EndTime = DateTime.Now.Date.AddHours(12),

                AppointmentBackground = new SolidColorBrush(Color.FromArgb(0xFf, 0xA2, 0xC1, 0x39)),

                Subject = "Business Meeting",

                ReminderTime = ReminderTimeType.TenHours

            });

            schedule.Appointments.Add(new ScheduleAppointment

            {

                StartTime = currentDate.Date.AddDays(1).AddHours(10),

                EndTime = currentDate.Date.AddDays(1).AddHours(16),

                AppointmentBackground = new SolidColorBrush(Color.FromArgb(0xFf, 0xD8, 0x00, 0x73)),

                Subject = "Auditing",

                ReminderTime = ReminderTimeType.TwoDays

            });

            schedule.Appointments.Add(new ScheduleAppointment

            {

                StartTime = DateTime.Now.Date.AddDays(7).AddHours(10),

                EndTime = DateTime.Now.Date.AddDays(7).AddHours(13),

                AppointmentBackground = new SolidColorBrush(Color.FromArgb(0xFf, 0xF0, 0x96, 0x09)),

                Subject = "Conference",

                ReminderTime = ReminderTimeType.TwoWeeks

            });
            this.schedule.ReminderFormActionChanged += Schedule_ReminderFormActionChanged;
            this.schedule.ReminderClosed += Schedule_ReminderClosed;
            this.schedule.ReminderOpening += Schedule_ReminderOpening;
        }

        private void Schedule_ReminderOpening(object sender, ReminderControlOpeningEventArgs e)
        {
            //To get the list of reminder appointments from reminder window.
            var collection = e.RemindAppCollection;
        }

        private void Schedule_ReminderClosed(object sender, ReminderControlClosedEventArgs e)
        {
           
        }

        private void Schedule_ReminderFormActionChanged(object sender, ReminderFormActionChangedEventArgs e)
        {
            //To Get the action of schedule appointments.
            ReminderAction action = e.Action;
            //To Get list of appointments that are changed.
            var appointments = e.Appointments;
            //To Get the snooze time of action changed appointments.
            var timeSpan = e.SnoozeTime;
        }
    }
}
