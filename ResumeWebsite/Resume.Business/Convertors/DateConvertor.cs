using System.Globalization;

namespace Resume.Bussines.Convertors;

public static class DateConvertor
{
    public static string ToShamsi(this DateOnly value)
    {
        PersianCalendar persianCalendar = new PersianCalendar();

        DateTime dateTime = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);

        return persianCalendar.GetYear(dateTime) + "/" +
               persianCalendar.GetMonth(dateTime).ToString("00") + "/" +
               persianCalendar.GetDayOfMonth(dateTime).ToString("00");
    }

    public static string ToShamsiMonthYear(this string? shamsiDate)
    {
        if (string.IsNullOrWhiteSpace(shamsiDate))
            return string.Empty;

        // Accept common separators: '/', '-', '.', ' '
        var separators = new[] { '/', '-', '.', ' ' };
        var parts = shamsiDate.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 2)
            return shamsiDate!;

        var year = parts[0];
        if (!int.TryParse(parts[1], out var month))
            return shamsiDate!;

        // Persian month names (1-based)
        var months = new[]
        {
                "فروردین",
                "اردیبهشت",
                "خرداد",
                "تیر",
                "مرداد",
                "شهریور",
                "مهر",
                "آبان",
                "آذر",
                "دی",
                "بهمن",
                "اسفند"
            };

        if (month < 1 || month > 12)
            return shamsiDate!;

        var monthName = months[month - 1];
        return $"{monthName} {year}";
    }
}