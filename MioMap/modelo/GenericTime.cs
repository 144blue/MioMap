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
        public String parseMonth(int name)
        {
            String value = "";

            if (name == (12))
            {
                value = "DIC";
            }
            else if (name == (11))
            {
                value = "NOV";
            }
            else if (name == (10))
            {
                value = "OCT";
            }
            else if (name == (09))
            {
                value = "SEP";
            }
            else if (name == (08))
            {
                value = "AGO";
            }
            else if (name == (07))
            {
                value = "JUL";
            }
            else if (name == (06))
            {
                value = "JUN";
            }
            else if (name == (05))
            {
                value = "MAY";
            }
            else if (name == (04))
            {
                value = "ABR";
            }
            else if (name == (03))
            {
                value = "MAR";
            }
            else if (name == (02))
            {
                value = "FEB";
            }
            else if (name == (01))
            {
                value = "ENE";
            }

            return value;
        }

        private void passYear()
        {
            year++;
        }

        public String generateDataTime()
        {
            string actual = day + "-" + parseMonth(month) + "-" + year + " " + hour + "." + minute + "." + second + " " + meridiem;

            return actual;


        }

        public String showTime()
        {
            string actual = "Fecha: " + day + " " + parseMonth(month) + " " + year + "\nHora:  " + hour + ":" + minute + ":" + second + " " + meridiem;

            return actual;


        }
    }
}
