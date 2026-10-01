using System;
using Resume.Bussines.Extentions;
using Resume.Bussines.Convertors;

namespace Resume.Bussines.Extensions
{
    public static class CompatibilityExtensions
    {
        // Delegate to existing DateExtentions.ToShamsi (DateTime)
        public static string ToShamsi(this DateTime date)
        {
            return DateExtentions.ToShamsi(date);
        }

        // Delegate to existing DateConvertor.ToShamsi (DateOnly)
        public static string ToShamsi(this DateOnly date)
        {
            return DateConvertor.ToShamsi(date);
        }

        // Delegate to existing DateConvertor.ToShamsiMonthYear (string)
        public static string ToShamsiMonthYear(this string? shamsiDate)
        {
            return DateConvertor.ToShamsiMonthYear(shamsiDate);
        }
    }
}
