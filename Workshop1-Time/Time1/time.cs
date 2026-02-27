using System;
using System.Collections.Generic;
using System.Text;

namespace Time1
{
    public class Time
    {
        // Private Atributes //
        private int Ang_Hour;
        private int Ang_Minute;
        private int Ang_Second;
        private int Ang_milliseconds;

        // Default constructors//
        public Time()
        {
            Ang_Hour = 0;
            Ang_Minute = 0;
            Ang_Second = 0;
            Ang_milliseconds = 0;
        }
        // Constructor with hours //
        public Time (int hour)
        {
            Ang_Hour = hour;
        }
        // Constructor with hour and minute //
        public Time (int hour, int minute)
        {
            Ang_Hour = hour;
            Ang_Minute = minute;
        }
        // Constructor whit hour, minute and seconds //
        public Time (int hour, int minute, int seconds)
        {
            Ang_Hour = hour;
            Ang_Minute = minute;
            Ang_Second = seconds;
        }
        // Constructor whit hour, minute, seconds and millisecond //
        public Time(int hour, int minute, int seconds, int milliseconds)
        {
            Ang_Hour = hour;
            Ang_Minute = minute;
            Ang_Second = seconds;
            Ang_milliseconds = milliseconds;
        }
               


    }
}
