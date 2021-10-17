using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class WorkDayRepository
    {
        public WorkDayRepository()
        {
            WorkDays = new List<WorkDay>();
        }


        public string FilePath = @"C:\Users\scott\OneDrive\Documents\sites\SimpleWorkdayLogger\workdays.txt";

        public List<WorkDay> WorkDays { get; private set; }

        public DateTimeOffset MostRecentWorkDate { get; private set; }

        public string GetFilePath()
        {
            return FilePath;
        }


        public WorkDay Retrieve(string id)
        {

            WorkDay workDay = WorkDays.Find(day => day.WorkDayId == id);

            if (workDay == null)
            {
                throw new ArgumentOutOfRangeException("No workday with that id");
            }


            return workDay;
        }

        private List<String> GetLinesFromFile()
        {
            List<String> lines = new List<String>();
            var filePath = GetFilePath();

            lines = File.ReadAllLines(filePath).ToList();

            return lines;
        }

        public List<WorkDay> RetrieveAll()
        {
            List<WorkDay> workDays = new List<WorkDay>();
            List<String> lines = GetLinesFromFile();
            var filePath = GetFilePath();

            if (lines.Count > 0)
            {
                foreach (String line in lines)
                {
                    String[] items = line.Split(',');
                    WorkDay workDay = new WorkDay(items[0], items[1]);
                    workDays.Add(workDay);
                }
            }
            WorkDays = workDays;

            File.WriteAllLines(filePath, lines);

            return WorkDays;
        }

        public bool GetIsExistingWorkDate(DateTimeOffset dateToCompare)
        {
            if (WorkDays.Count > 0)
            {
                MostRecentWorkDate = WorkDays[WorkDays.Count - 1].Date;
            }

            if (MostRecentWorkDate == null)
            {
                return false;
            }

            bool isExistingWorkdate = DateTimeOffset.Equals(dateToCompare.Date, MostRecentWorkDate);

            if (isExistingWorkdate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetWorkDayAsCommaDelimited(WorkDay workday)
        {
            return $"{workday.WorkDayId}, {workday.Date}, {workday.IsWorkFromHome}";
        }

        private void AddWorkDayToFile(WorkDay workday)
        {
            var lines = GetLinesFromFile();
            var commaDelimitedWorkday = GetWorkDayAsCommaDelimited(workday);
            var filePath = GetFilePath();
            lines.Add(commaDelimitedWorkday);

            File.WriteAllLines(filePath, lines);
        }

        public WorkDay CreateWorkday()
        {
            var todayDate = Utility.GetDate();
            var isExistingWorkDate = GetIsExistingWorkDate(todayDate);

            if (isExistingWorkDate)
            {
                /// Execption handling here
                throw new ArgumentOutOfRangeException();
            }

            string id = Utility.GenerateID();
            WorkDay workday = new WorkDay(id);
            MostRecentWorkDate = workday.Date;

            WorkDays.Add(workday);
            AddWorkDayToFile(workday);

            Utility.CastToILoggable<WorkDay>((WorkDays) as List<WorkDay>);

            return workday;
        }
    }
}
