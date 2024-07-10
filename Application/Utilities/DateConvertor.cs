using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelPrintingEF.Domain.Utilities
{
    public static class DateConvertor

    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetHour(value) + ":" + pc.GetMinute(value).ToString("00") + ":" +
                   pc.GetSecond(value).ToString("00") + " " + pc.GetYear(value) + "/" +
                   pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("0");
        }

        public static string ToShamsiLabel(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" +
                   pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("0") + " " +
                   pc.GetHour(value) + ":" + pc.GetMinute(value).ToString("00") + ":" +
                   pc.GetSecond(value).ToString("00");
        }

        public static string ToShamsiDate(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" +
                   pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("0");
        }



        public static DateTime ToDateTime(this string dateTime)
        {
            dateTime = dateTime.Fa2En().FixPersianChars();

            var p = new PersianCalendar();
            string[] parts = dateTime.Split(new[] { '/', '-' });
            var r = p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 0, 0,
                0, 0);
            return r;
        }


        public static DateTime ToDateTime(this string dateTime, string time)
        {
            var p = new PersianCalendar();
            dateTime = dateTime.Fa2En().FixPersianChars();

            string[] parts = dateTime.Split(new[] { '/', '-' });
            string[] times = time.Split(":");
            return p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]),
                Convert.ToInt32(times[0]), Convert.ToInt32(times[1]),
                Convert.ToInt32(times[2]), 0);
        }



        public static DateTime ToDateTime(this DateTime dateTime, TimeSpan? timeSpan)
        {
            var finalDateTime = timeSpan == null
                ? dateTime
                : new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, timeSpan.Value.Hours,
                    timeSpan.Value.Minutes, 0);

            return finalDateTime;
        }




        public static string ToMiladi(this DateTime value)
        {
            GregorianCalendar pc = new GregorianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00") + " " +
                   pc.GetHour(value) + ":" + pc.GetMinute(value).ToString("00") + ":" +
                   pc.GetSecond(value).ToString("00");
            ;
        }

        public static DateTime? ToGregorianDate(this string dateTime)
        {
            try
            {

                dateTime = dateTime.Fa2En().FixPersianChars();
                if (string.IsNullOrEmpty(dateTime))
                    return null;
                if (dateTime.Contains("-"))
                    dateTime = dateTime.Split("-")[1];
                string[] parts = dateTime.Split(new[] { '/', '-', ':' });
                try
                {
                    if (string.IsNullOrEmpty(dateTime))
                        return null;

                    dateTime = dateTime.Fa2En().FixPersianChars();

                    PersianCalendar p = new PersianCalendar();

                    return p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 0,
                        0, 0, 0);
                }
                catch (Exception e)
                {
                    try
                    {
                        var date = Convert.ToDateTime(dateTime);
                        var change = date.ToString("yyyy/MM/dd");
                        var day1 = Convert.ToInt32(change.Substring(8, 2));
                        var mon1 = Convert.ToInt32(change.Substring(5, 2));
                        var year1 = Convert.ToInt32(change.Substring(0, 4));
                        var pc = new PersianCalendar();
                        change = (pc.ToDateTime(year1, mon1, day1, 0, 0, 0, 0).ToString("yyyy/MM/dd").Substring(0, 10));
                        return Convert.ToDateTime(change);
                    }
                    catch (Exception exception)
                    {
                        PersianCalendar pc = new PersianCalendar();
                        DateTime dt = new DateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), pc);
                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
               return DateTime.Now;
            }
        }

        public static DateTime? ToGregorian(this string dateTime)
        {
            dateTime = dateTime.Fa2En().FixPersianChars();
            if (string.IsNullOrEmpty(dateTime))
                return null;
            if (dateTime.Contains("-"))
                dateTime = dateTime.Split("-")[1];
            string[] parts = dateTime.Split(new[] { '/', '-', ':' });
            try
            {
                if (string.IsNullOrEmpty(dateTime))
                    return null;

                dateTime = dateTime.Fa2En().FixPersianChars();

                PersianCalendar p = new PersianCalendar();

                return p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]),
                    Convert.ToInt32(parts[3]), Convert.ToInt32(parts[4]), 0, 0);
            }
            catch (Exception e)
            {
                try
                {
                    var date = Convert.ToDateTime(dateTime);
                    var change = date.ToString("yyyy/MM/dd");
                    var day1 = Convert.ToInt32(change.Substring(8, 2));
                    var mon1 = Convert.ToInt32(change.Substring(5, 2));
                    var year1 = Convert.ToInt32(change.Substring(0, 4));
                    var pc = new PersianCalendar();
                    change = (pc.ToDateTime(year1, mon1, day1, 0, 0, 0, 0).ToString("yyyy/MM/dd").Substring(0, 10));
                    return Convert.ToDateTime(change);
                }
                catch (Exception exception)
                {
                    PersianCalendar pc = new PersianCalendar();
                    DateTime dt = new DateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), pc);
                    return dt;
                }
            }
        }

        public static string ToShamsiDate(this string dateTime)
        {

            var date = DateTime.Parse(dateTime, new CultureInfo("en-US", true));

            return ToShamsiDate(date);
        }

        public static DateTime? ToGregorianDateTimeFirst(this string dateTime)
        {
            dateTime = dateTime.Fa2En().FixPersianChars();
            if (string.IsNullOrEmpty(dateTime))
                return null;

            if (dateTime.Contains("-"))
                dateTime = dateTime.Split("-")[1];
            

            string[] parts = dateTime.Split(new[] { '/', '-', ':' });
            try
            {
               

                PersianCalendar p = new PersianCalendar();

                return p.ToDateTime(Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]), 0,
                    0, 0, 0);
            }
            catch (Exception e)
            {
                try
                {
                    var date = Convert.ToDateTime(dateTime);
                    var change = date.ToString("yyyy/MM/dd");
                    var day1 = Convert.ToInt32(change.Substring(8, 2));
                    var mon1 = Convert.ToInt32(change.Substring(5, 2));
                    var year1 = Convert.ToInt32(change.Substring(0, 4));
                    var pc = new PersianCalendar();
                    change = (pc.ToDateTime(year1, mon1, day1, 0, 0, 0, 0).ToString("yyyy/MM/dd").Substring(0, 10));
                    return Convert.ToDateTime(change);
                }
                catch (Exception exception)
                {
                    PersianCalendar pc = new PersianCalendar();
                    DateTime dt = new DateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), pc);
                    return dt;
                }
            }
        }

        public static bool IsMidnight(this DateTime dateTime)
        {
            return dateTime.TimeOfDay == TimeSpan.Zero;
        }
        public static DateTime? ToGregorianTimeFirst(this string dateTime)
        {

            dateTime = dateTime.Fa2En().FixPersianChars();
            if (string.IsNullOrEmpty(dateTime))
                return null;
            //if (dateTime.Contains("-"))
            //    dateTime = dateTime.Split("-")[1];
            string[] parts = dateTime.Split(new[] { '/', '-', ':' });

            try
            {
                PersianCalendar p = new PersianCalendar();

                return p.ToDateTime(Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]), Convert.ToInt32(parts[4]),
                    Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), 0, 0);
            }
            catch (Exception e)
            {
                try
                {
                    var date = Convert.ToDateTime(dateTime);
                    var change = date.ToString("yyyy/MM/dd");
                    var day1 = Convert.ToInt32(change.Substring(8, 2));
                    var mon1 = Convert.ToInt32(change.Substring(5, 2));
                    var year1 = Convert.ToInt32(change.Substring(0, 4));
                    var pc = new PersianCalendar();
                    change = (pc.ToDateTime(year1, mon1, day1, 0, 0, 0, 0).ToString("yyyy/MM/dd").Substring(0, 10));
                    return Convert.ToDateTime(change);
                }
                catch (Exception exception)
                {

                    try
                    {
                        PersianCalendar pc = new PersianCalendar();
                        DateTime dt = new DateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), pc);
                        return dt;
                    }
                    catch (Exception e1)
                    {
                        // جدا کردن تاریخ و ساعت
                        parts = dateTime.Split(' ');
                        string timePart, datePart;

                        // تشخیص فرمت و جدا کردن زمان و تاریخ
                        if (parts[0].Contains(":"))
                        {
                            timePart = parts[0];
                            datePart = parts[1];
                        }
                        else
                        {
                            timePart = parts[1];
                            datePart = parts[0];
                        }

                        // جدا کردن سال، ماه و روز
                        string[] dateParts = datePart.Split('/');
                        int year = int.Parse(dateParts[0]);
                        int month = int.Parse(dateParts[1]);
                        int day = int.Parse(dateParts[2]);

                        // جدا کردن ساعت، دقیقه و ثانیه
                        string[] timeParts = timePart.Split(':');
                        int hour = int.Parse(timeParts[0]);
                        int minute = int.Parse(timeParts[1]);
                        int second = int.Parse(timeParts[2]);

                        // ایجاد شی تقویم فارسی
                        PersianCalendar persianCalendar = new PersianCalendar();

                        // تبدیل به تاریخ میلادی
                        DateTime gregorianDateTime = new DateTime(year, month, day, hour, minute, second, persianCalendar);

                        return gregorianDateTime;
                    }
                   
                }

            }
        }


        public static DateTime ToGregorianTimeFirstforSMSReport(this string dateTime)
        {

            dateTime = dateTime.Fa2En().FixPersianChars();
            if (string.IsNullOrEmpty(dateTime))
                return DateTime.Now;

            if (dateTime.Contains("-"))
                dateTime = dateTime.Split("-")[1];

            string[] parts = dateTime.Split(new[] { '/', '-', ':' });

            try
            {
                PersianCalendar p = new PersianCalendar();

                return p.ToDateTime(Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]), Convert.ToInt32(parts[4]),
                    Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), 0, 0);
            }
            catch (Exception e)
            {
                try
                {
                    var date = Convert.ToDateTime(dateTime);
                    var change = date.ToString("yyyy/MM/dd");
                    var day1 = Convert.ToInt32(change.Substring(8, 2));
                    var mon1 = Convert.ToInt32(change.Substring(5, 2));
                    var year1 = Convert.ToInt32(change.Substring(0, 4));
                    var pc = new PersianCalendar();
                    change = (pc.ToDateTime(year1, mon1, day1, 0, 0, 0, 0).ToString("yyyy/MM/dd").Substring(0, 10));
                    return Convert.ToDateTime(change);

                }

                catch (Exception exception)
                {
                    PersianCalendar pc = new PersianCalendar();
                    DateTime dt = new DateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]),
                        Convert.ToInt32(parts[2]), pc);
                    return dt;
                }

            }
        }

        public static string GetDay(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    {
                        return "جمعه";
                    }
                case DayOfWeek.Monday:
                    {
                        return "دوشنبه";
                    }
                case DayOfWeek.Saturday:
                    {
                        return "شنبه";
                    }
                case DayOfWeek.Sunday:
                    {
                        return "یکشنبه";
                    }
                case DayOfWeek.Thursday:
                    {
                        return "پنچشنبه";
                    }
                case DayOfWeek.Wednesday:
                    {
                        return "چهارشنبه";
                    }
                case DayOfWeek.Tuesday:
                    {
                        return "سه شنبه";
                    }
                default:
                    {
                        return "هیچ";
                    }
            }

        }

        public static string GetMonth(this int month, int year)
        {
            return month switch
            {
                1 => "فروردین" + year,
                2 => "اردیبهشت" + year,
                3 => "خرداد" + year,
                4 => "تیر" + year,
                5 => "مرداد" + year,
                6 => "شهریور" + year,
                7 => "مهر" + year,
                8 => "آبان" + year,
                9 => "آذر" + year,
                10 => "دی" + year,
                11 => "بهمن" + year,
                12 => "اسفند" + year,
                _ => ""
            };
        }

        public static ValueTuple<DateTime, DateTime, string, string> GetRangeDate(this int month, int year)
        {

            switch (month)
            {
                case 1:
                    {
                        var startDate = year + "/01/01";
                        var endDate = year + "/02/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "فروردین" + year , "فروردین");
                    }
                case 2:
                    {
                        var startDate = year + "/02/01";
                        var endDate = year + "/03/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "اردیبهشت" + year, "اردیبهشت");
                    }
                case 3:
                    {
                        var startDate = year + "/03/01";
                        var endDate = year + "/04/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "خرداد" + year, "خرداد");
                    }
                case 4:
                    {
                        var startDate = year + "/04/01";
                        var endDate = year + "/05/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "تیر" + year, "تیر");
                    }
                case 5:
                    {
                        var startDate = year + "/05/01";
                        var endDate = year + "/06/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "مرداد" + year, "مرداد");
                    }
                case 6:
                    {
                        var startDate = year + "/05/01";
                        var endDate = year + "/06/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "شهریور" + year, "شهریور");
                    }
                case 7:
                    {
                        var startDate = year + "/06/01";
                        var endDate = year + "/07/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "مهر" + year, "مهر");
                    }
                case 8:
                    {
                        var startDate = year + "/08/01";
                        var endDate = year + "/09/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "آبان" + year, "آبان");
                    }
                case 9:
                    {
                        var startDate = year + "/09/01";
                        var endDate = year + "/10/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "آذر" + year, "آذر");
                    }
                case 10:
                    {
                        var startDate = year + "/10/01";
                        var endDate = year + "/11/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "دی" + year, "دی");
                    }
                case 11:
                    {
                        var startDate = year + "/11/01";
                        var endDate = year + "/12/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "بهمن" + year, "بهمن");
                    }
                case 12:
                    {
                        var startDate = year + "/12/01";
                        var endDate = year + 1 + "" + "/01/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "اسفند" + year, "اسفند");
                    }
                default:
                    return ValueTuple.Create(DateTime.Now, DateTime.Now, "", "");
            }
        }
    }
}
