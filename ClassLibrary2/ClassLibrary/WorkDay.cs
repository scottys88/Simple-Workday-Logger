using Common;
using System;
using System.ComponentModel;

namespace ClassLibrary
{
    public class WorkDay: ILoggable, INotifyPropertyChanged
    {
        public WorkDay()
        {

        }
        public WorkDay(string workDayId)
        {
            WorkDayId = workDayId;
            Date = Utility.GetDate();
            IsWorkFromHome = true;
        }

        public WorkDay(string workDayId, string dateString)
        {
            WorkDayId = workDayId;
            Date = Utility.GetDate(dateString);
            IsWorkFromHome = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string WorkDayId { get; private set; }

        private DateTimeOffset date;
        public DateTimeOffset Date
        {
            get { return date; }
            set
            {
                date = value;
                NotifyPropertyChanged("Date");
            }
        }

        public bool IsWorkFromHome { get; set; }

        public string Log() => $"Workday Id: {WorkDayId} Date: {Date.UtcDateTime}";

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

}

