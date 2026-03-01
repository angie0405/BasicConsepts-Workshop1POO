using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Time1
{
    public class Time
    {
        // Private Atributes //
        private int ang_hour;
        private int ang_minute;
        private int ang_second;
        private int ang_milliseconds;

        // Default constructors//
        public Time()
        {
            ang_hour = 0;
            ang_minute = 0;
            ang_second = 0;
            ang_milliseconds = 0;
        }
        // Constructor with hours //
        public Time (int hour)
        {
            Hour = hour;
        }
        // Constructor with hour and minute //
        public Time (int hour, int minute)
        {
            Hour = hour;
           Minute = minute;
        }
        // Constructor whit hour, minute and seconds //
        public Time (int hour, int minute, int seconds)
        {
            Hour = hour;
            Minute = minute;
            Second = seconds;
        }
        // Constructor whit hour, minute, seconds and millisecond //
        public Time(int hour, int minute, int seconds, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = seconds;
            Millisecond = millisecond;
        }
        
        // Properties //
        public int Hour
        {
            get => ang_hour;
            set => ang_hour = ValidateHour(value);
        }
        public int Minute
        {
            get => ang_minute;
            set => ang_minute = ValidateMinute(value);
        }

        public int Second
        {
            get => ang_second;
            set => ang_second = ValidateSecond(value);
        }

        public int Millisecond
        {
            get => ang_milliseconds;
            set => ang_milliseconds = ValidateMillisecond(value);
        }



        //  Time Validations 
        private int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new Exception($"The hour: {hour}, is not valid.");
            }
            return hour;
        }

        private int ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new Exception($"The minute: {minute}, is not valid.");
            }
            return minute;
        }

        private int ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new Exception($"The second: {second}, is not valid.");
            }
            return second;
        }

        private int ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new Exception($"The millisecond: {millisecond}, is not valid.");
            }
            return millisecond;
        }
        // Calculation methods

        // Tomilliseconds
        public int ToMilliseconds()
        {
            return (Hour * 3600000) +
                   (Minute * 60000) +
                   (Second * 1000) +
                   Millisecond;
        }

        // ToSeconds
        public int ToSeconds()
        {
            return (Hour * 3600) +
                   (Minute * 60) +
                   Second +
                   (Millisecond / 1000);
        }

        //ToMinute
        public int ToMinutes()
        {
            return (Hour * 60) +
                Minute +
                (Second / 60) +
                (Millisecond / 60000);
        }
        // Add(Time other)
        public Time Add(Time other)
        {
            int ms = this.Millisecond + other.Millisecond;
            int s = this.Second + other.Second;
            int m = this.Minute + other.Minute;
            int h = this.Hour + other.Hour;

            if (ms > 999)
            {
                s += ms / 1000;
                ms %= 1000;
            }

            if (s > 59)
            {
                m += s / 60;
                s %= 60;
            }

            if (m > 59)
            {
                h += m / 60;
                m %= 60;
            }

            if (h > 23)
            {
                h %= 24;
            }
            return new Time(h, m, s, ms);
        }
        // IsOtherDay
        public bool IsOtherDay(Time other)
        {
            int totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            int OneDayMs = 24 * 3600000;

            return totalMs >= OneDayMs;
        }
        // ToString
        public override string ToString()
        {
            int h12 = Hour % 12;
            if (h12 == 0) h12 = 12;
            {
                string period = Hour < 12 ? "AM" : "PM";
                return $"{h12:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
            }
        }
    }
}
 