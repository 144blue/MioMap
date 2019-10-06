using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
   public class GenericTime
    {
        public static String POST_MERIDIEM = "pm";
        public static String ANTE_MERIDIEM = "am";
        public static String DECEMBER = "DIC";
        public static String NOVEMBER= "NOV";
        public static String OCTOBER = "OCT";
        public static String SEPTEMBER = "SEP";
        public static String AUGUST = "AGO";
        public static String JUNE = "JUN";
        public static String JULY = "JUL";
        public static String MAY = "MAY";
        public static String APRIL = "ABR";
        public static String MARCH = "MAR";
        public static String FEBRUARY = "FEB";
        public static String JANUARY = "MAR";
        private int year;
        private int day;
        private String monthS;
        private int month;
        private int minute;
        private int hour;
        private int second;
        private String meridiem;

        

        public GenericTime(int year, int day, String monthS, int minute, int hour, int second)
        {
            this.year = year;
            this.day = day;
            this.monthS = monthS;
            this.month = parseMonth(monthS);
            this.minute = minute;
            this.hour = hour;
            this.second = second;
        }

        public int Year { get => year; set => year = value; }
        public int Day { get => day; set => day = value; }
        public String MonthS { get => monthS; set => monthS = value; }
        public int Minute { get => minute; set => minute = value; }
        public int Hour { get => hour; set => hour = value; }
        public int Second { get => second; set => second = value; }

        public int parseMonth(string name)
        {
            int value=0;

            if (name.Equals(DECEMBER))
            {
                value = 12;
            }else if (name.Equals(NOVEMBER))
            {
                value = 11;
            }
            else if (name.Equals(OCTOBER))
            {
                value = 10;
            }
            else if (name.Equals(SEPTEMBER))
            {
                value = 9;
            }
            else if (name.Equals(AUGUST))
            {
                value = 8;
            }
            else if (name.Equals(JULY))
            {
                value = 7;
            }
            else if (name.Equals(JUNE))
            {
                value = 6;
            }
            else if (name.Equals(MAY))
            {
                value = 5;
            }
            else if (name.Equals(APRIL))
            {
                value = 4;
            }
            else if (name.Equals(MARCH))
            {
                value = 3;
            }
            else if (name.Equals(FEBRUARY))
            {
                value = 2;
            }
            else if (name.Equals(JANUARY))
            {
                value = 1;
            }
            else
            {
                value = 11;
            }

            return value;
        }

        public void passSecond()
        {

            if (second!=60)
            {
                second++;
            }
            else
            {
                second = 0;
                passminute();
            }


        }

        private void passminute()
        {

            if (minute!=60)
            {
                minute++;
            }
            else
            {
                minute = 0;
                passHour();
            }
        }

        private void passHour()
        {
            if (hour!=12)
            {
                hour++;
            }else if (meridiem.Equals(POST_MERIDIEM))
            {
                meridiem = ANTE_MERIDIEM;
                passDay();
            }
            else
            {
                meridiem = POST_MERIDIEM;
            }
        }

        private void passDay()
        {
            if (day!=30)
            {
                day++;
            }else
            {
                day = 0;
                passMonth();
            }
        }

        private void passMonth()
        {
            if (month!=12)
            {
                month++;
            }
            else
            {
                month = 0;
                passYear();
            }
        }


        private void passYear()
        {
            year++;
        }

        private String generateDataTime()
        {
            string actual = day + "-" + month + "-" + year + " " + hour + "." + minute + "." + second + "." + meridiem;

            return actual;


        }


    }
}
