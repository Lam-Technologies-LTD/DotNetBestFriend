namespace DotNetBestFriend;

public static class DateTimeHelpers
{
    /// <summary>
    /// Allows ToFileTime to be useable with nullable <see cref="T:System.DateTime" />
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <param name="setToNowOnNull">If value is null decide if DateTime.Now or DateTime.MinValue filetime gets returned</param>
    /// <returns>The value of the current <see cref="T:System.DateTime" /> object expressed as a Windows file time.</returns>
    public static long ToFileTime(this DateTime? value, bool setToNowOnNull = true)
    {
        if (value.HasValue)
        {
            return value.Value.ToFileTime();
        }

        return setToNowOnNull ? DateTime.Now.ToFileTime() : DateTime.MinValue.ToFileTime();
    }

    /// <summary>
    /// Allows ToFileTime to be useable with nullable <see cref="T:System.DateTime" /> in UTC format
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <param name="setToUtcNowOnNull">If value is null decide if DateTime.UtcNow or DateTime.MinValue filetime gets returned</param>
    /// <returns>The value of the current <see cref="T:System.DateTime" /> object expressed as a Windows file time.</returns>
    public static long ToFileTimeUtc(this DateTime? value, bool setToUtcNowOnNull = true)
    {
        if (value.HasValue)
        {
            return value.Value.ToFileTime();
        }

        return setToUtcNowOnNull ? DateTime.UtcNow.ToFileTime() : DateTime.MinValue.ToFileTime();
    }

    /// <summary>
    /// Sets the <see cref="T:System.DateTime" /> value to the last possible moment of the day
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <param name="setToNowOnNull">If value is null decide if DateTime.Now or DateTime.MinValue filetime gets returned</param>
    /// <returns>A <see cref="T:System.DateTime" /> object with the time value at the last second before midnight</returns>
    public static DateTime LastSecondOfTheDay(this DateTime? value, bool setToNowOnNull = true)
    {
        if (value.HasValue)
        {
            return value.Value.LastSecondOfTheDay();
        }

        return setToNowOnNull ? DateTime.Now.LastSecondOfTheDay() : DateTime.MinValue.LastSecondOfTheDay();
    }

    /// <summary>
    /// Sets the <see cref="T:System.DateTime" /> value to the last possible moment of the day for UTC
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <param name="setToUtcNowOnNull">If value is null decide if DateTime.UtcNow or DateTime.MinValue filetime gets returned</param>
    /// <returns>A <see cref="T:System.DateTime" /> object with the time value at the last second before midnight</returns>
    public static DateTime LastSecondOfTheDayUtc(this DateTime? value, bool setToUtcNowOnNull = true)
    {
        if (value.HasValue)
        {
            return value.Value.LastSecondOfTheDay();
        }

        return setToUtcNowOnNull ? DateTime.UtcNow.LastSecondOfTheDay() : DateTime.MinValue.LastSecondOfTheDay();
    }

    /// <summary>
    /// Sets the <see cref="T:System.DateTime" /> value to the last possible moment of the day for UTC
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <returns>A <see cref="T:System.DateTime" /> object with the time value at the last second before midnight</returns>
    public static DateTime LastSecondOfTheDay(this DateTime value) => new DateTime(value.Year, value.Month, value.Day).AddDays(1).AddMilliseconds(-1);

    /// <summary>
    /// Sets the <see cref="T:System.DateTime" /> value to exactly mid day
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <param name="setToNowOnNull">If value is null decide if DateTime.Now or DateTime.MinValue filetime gets returned</param>
    /// <returns>A <see cref="T:System.DateTime" /> object set to 12pm on the dot</returns>
    public static DateTime Noon(this DateTime? value, bool setToNowOnNull = true)
    {
        if (value.HasValue)
        {
            return value.Value.Noon();
        }

        return setToNowOnNull ? DateTime.Now.Noon() : DateTime.MinValue.Noon();
    }

    /// <summary>
    /// Sets the <see cref="T:System.DateTime" /> value to exactly mid day
    /// </summary>
    /// <param name="value"><see cref="T:System.DateTime" /> nullable object</param>
    /// <param name="setToUtcNowOnNull">If value is null decide if DateTime.UtcNow or DateTime.MinValue filetime gets returned</param>
    /// <returns>A <see cref="T:System.DateTime" /> object set to 12pm on the dot</returns>
    public static DateTime NoonUtc(this DateTime? value, bool setToUtcNowOnNull = true)
    {
        if (value.HasValue)
        {
            return value.Value.Noon();
        }

        return setToUtcNowOnNull ? DateTime.UtcNow.Noon() : DateTime.MinValue.Noon();
    }

    /// <summary>
    /// Sets the <see cref="T:System.DateTime" /> value to exactly mid day
    /// </summary>
    /// <param name="value"><see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object set to 12pm on the dot</returns>
    public static DateTime Noon(this DateTime value) => new DateTime(value.Year, value.Month, value.Day, 12, 0, 0, 0);

    /// <summary>
    /// Checks if the value is not null and also not default <see cref="T:System.DateTime" /> (DateTime.Min)
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <returns>True if the value is not null and not DateTime.Min</returns>
    public static bool IsValidValue(this DateTime? value) => value.GetValueOrDefault() != default(DateTime);

    /// <summary>
    /// Checks if the value has not yet expired
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <param name="dateOnly">Focus on the date and not the time</param>
    /// <returns>True if the value has not past DateTime.Now</returns>
    public static bool HasNotExpired(this DateTime? value, bool dateOnly = false) => value.GetValueOrDefault().HasNotExpired(dateOnly);

    /// <summary>
    /// Checks if the value has not expired for UTC
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <param name="dateOnly">Focus on the date and not the time</param>
    /// <returns>True if the value has not past DateTime.UtcNow</returns>
    public static bool HasNotExpiredUtc(this DateTime? value, bool dateOnly = false) => value.GetValueOrDefault().HasNotExpiredUtc(dateOnly);

    /// <summary>
    /// Checks if the value has expired
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <param name="dateOnly">Focus on the date and not the time</param>
    /// <returns>True if the value has gone past DateTime.Now</returns>
    public static bool HasExpired(this DateTime? value, bool dateOnly = false) => value.GetValueOrDefault().HasExpired(dateOnly);

    /// <summary>
    /// Checks if the value has expired for UTC
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <param name="dateOnly">Focus on the date and not the time</param>
    /// <returns>True if the value has gone past DateTime.UtcNow</returns>
    public static bool HasExpiredUtc(this DateTime? value, bool dateOnly = false) => value.GetValueOrDefault().HasExpiredUtc(dateOnly);

    /// <summary>
    /// Checks if the date is today
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <returns>True if the value is the current date</returns>
    public static bool IsToday(this DateTime? value) => value.GetValueOrDefault().IsToday();

    /// <summary>
    /// Checks if the date is today for UTC
    /// </summary>
    /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
    /// <returns>True if the value is the current UTC date</returns>
    public static bool IsTodayUtc(this DateTime? value) => value.GetValueOrDefault().IsTodayUtc();

    /// <summary>
    /// Checks if the value has not yet expired
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <param name="dateOnly">Focus on the date and not the time</param>
    /// <returns>True if the value has not past DateTime.Now</returns>
    public static bool HasNotExpired(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date >= DateTime.Now.Date : value >= DateTime.Now;

    /// <summary>
    /// Checks if the value has not expired for UTC
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <param name="dateOnly">Focus on the date and not the time</param>
    /// <returns>True if the value has not past DateTime.UtcNow</returns>
    public static bool HasNotExpiredUtc(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date >= DateTime.UtcNow.Date : value >= DateTime.UtcNow;

    /// <summary>
    /// Checks if the value has expired
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <param name="dateOnly">Focus on the date and not the time</param>
    /// <returns>True if the value has gone past DateTime.Now</returns>
    public static bool HasExpired(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date < DateTime.Now.Date : value < DateTime.Now;

    /// <summary>
    /// Checks if the value has expired for UTC
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <param name="dateOnly">Focus on the date and not the time</param>
    /// <returns>True if the value has gone past DateTime.UtcNow</returns>
    public static bool HasExpiredUtc(this DateTime value, bool dateOnly = false) => dateOnly ? value.Date < DateTime.UtcNow.Date : value < DateTime.UtcNow;

    /// <summary>
    /// Checks if the date is today for UTC
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>True if the value is the current date</returns>
    public static bool IsToday(this DateTime value) => value.Date == DateTime.Now.Date;

    /// <summary>
    /// Checks if the date is today for UTC
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>True if the value is the current UTC date</returns>
    public static bool IsTodayUtc(this DateTime value) => value.Date == DateTime.UtcNow.Date;

    /// <summary>
    /// Sets the value to the very start of the year
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object set to 1st January of the current year</returns>
    public static DateTime BeginningOfTheYear(this DateTime value) => new DateTime(value.Year, 1, 1);

    /// <summary>
    /// Sets the value to the last moment of the year
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object set to the 31st December of the current year at 11:59:59.999 PM</returns>
    public static DateTime EndOfTheYear(this DateTime value) => new DateTime(value.Year, 12, 31, 23, 59, 59, 999);

    /// <summary>
    /// Returns the full month string of the value
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>The name of the month</returns>
    public static string GetMonthFull(this DateTime value) => value.ToString("MMMM");

    /// <summary>
    /// Returns the short month string of the value
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>The abbreviation of the month</returns>
    public static string GetMonthShort(this DateTime value) => value.ToString("MMM");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Day/Month/Year</returns>
    public static string ToDMYStringSlash(this DateTime value) => value.ToString("dd/MM/yyyy");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Day/Month/Year Hours:Minutes:Seconds</returns>
    public static string ToDMY24HourStringSlash(this DateTime value) => value.ToString("dd/MM/yyyy HH:mm:ss");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Day/Month/Year Hours:Minutes:Seconds AM/PM</returns>
    public static string ToDMY12HourStringSlash(this DateTime value) => value.ToString("dd/MM/yyyy hh:mm:ss tt");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Month/Day/Year</returns>
    public static string ToMDYStringSlash(this DateTime value) => value.ToString("MM/dd/yyyy");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Month/Day/Year Hours:Minutes:Seconds</returns>
    public static string ToMDY24HourStringSlash(this DateTime value) => value.ToString("MM/dd/yyyy HH:mm:ss");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Month/Day/Year Hours:Minutes:Seconds AM/PM</returns>
    public static string ToMDY12HourStringSlash(this DateTime value) => value.ToString("MM/dd/yyyy hh:mm:ss tt");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Year/Month/Date</returns>
    public static string ToYMDStringSlash(this DateTime value) => value.ToString("yyyy/MM/dd");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Year/Month/Date Hours:Minutes:Seconds</returns>
    public static string ToYMD24HourStringSlash(this DateTime value) => value.ToString("yyyy/MM/dd HH:mm:ss");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Year/Month/Date Hours:Minutes:Seconds AM/PM</returns>
    public static string ToYMD12HourStringSlash(this DateTime value) => value.ToString("yyyy/MM/dd hh:mm:ss tt");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Day-Month-Year</returns>
    public static string ToDMYStringDash(this DateTime value) => value.ToString("dd-MM-yyyy");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Day-Month-Year Hours:Minutes:Seconds</returns>
    public static string ToDMY24HourStringDash(this DateTime value) => value.ToString("dd-MM-yyyy HH:mm:ss");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Day-Month-Year Hours:Minutes:Seconds AM/PM</returns>
    public static string ToDMY12HourStringDash(this DateTime value) => value.ToString("dd-MM-yyyy hh:mm:ss tt");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Month/Day/Year</returns>
    public static string ToMDYStringDash(this DateTime value) => value.ToString("MM-dd-yyyy");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Month/Day/Year Hours:Minutes:Seconds</returns>
    public static string ToMDY24HourStringDash(this DateTime value) => value.ToString("MM-dd-yyyy HH:mm:ss");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Month/Day/Year Hours:Minutes:Seconds AM/PM</returns>
    public static string ToMDY12HourStringDash(this DateTime value) => value.ToString("MM-dd-yyyy HH:mm:ss tt");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Year-Month-Date</returns>
    public static string ToYMDStringDash(this DateTime value) => value.ToString("yyyy-MM-dd");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Year-Month-Date Hours:Minutes:Seconds</returns>
    public static string ToYMD24HourStringDash(this DateTime value) => value.ToString("yyyy-MM-dd HH:mm:ss");

    /// <summary>
    /// Returns the date of the value in string format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Year-Month-Date Hours:Minutes:Seconds AM/PM</returns>
    public static string ToYMD12HourStringDash(this DateTime value) => value.ToString("yyyy-MM-dd HH:mm:ss tt");

    /// <summary>
    /// Returns the time string only in 24 hour format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>A string in the format of Hours:Minutes:Seconds</returns>
    public static string Get24HourTimeOnlyString(this DateTime value) => value.ToString("HH:mm:ss");

    /// <summary>
    /// Returns the time string only in 12 hour format
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>A string in the format of Hours:Minutes:Seconds AM/PM</returns>
    public static string Get12HourTimeOnlyString(this DateTime value) => value.ToString("hh:mm:ss tt");

    /// <summary>
    /// Returns the date in a formatted string without any spaces
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Year Month Date string</returns>
    public static string ToYMDOnlyString(this DateTime value) => value.ToString("yyyyMMdd");

    /// <summary>
    /// Returns the date in a formatted string without any spaces
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Month Date Year string</returns>
    public static string ToMDYOnlyString(this DateTime value) => value.ToString("MMddyyyy");

    /// <summary>
    /// Returns the date in a formatted string without any spaces
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>Date Month Year string</returns>
    public static string ToDMYOnlyString(this DateTime value) => value.ToString("ddMMyyyy");

    /// <summary>
    /// Gets the age of the date provided
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>An interger</returns>
    public static int GetAge(this DateTime value)
    {
        var retVal = new DateTime((DateTime.Now - value).Ticks).Year - 1;

        return retVal > default(int) ? retVal : default;
    }

    /// <summary>
    /// Gets the age of the date provided
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>An interger</returns>
    public static int GetAge(this DateTime? value) => value.HasValue ? value.Value.GetAge() : default;

    /// <summary>
    /// Gets the age of the date provided using UTC
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>An interger</returns>
    public static int GetAgeUtc(this DateTime value) => DateTime.UtcNow.Year - value.Year;

    /// <summary>
    /// Gets the age of the date provided using UTC
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>An interger</returns>
    public static int GetAgeUtc(this DateTime? value) => value.HasValue ? value.Value.GetAgeUtc() : default;

    /// <summary>
    /// Sets the <see cref="T:System.DateTime" /> object to midnight
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object</returns>
    public static DateTime StartOfDay(this DateTime value) => new DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0);

    /// <summary>
    /// Sets the <see cref="T:System.DateTime" /> object to midnight
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>An interger</returns>
    public static DateTime StartOfDay(this DateTime? value) => value.HasValue ? value.Value.StartOfDay() : DateTime.Now.StartOfDay();

    /// <summary>
    /// Sets the <see cref="T:System.DateTime" /> object to midnight for UTC
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>An interger</returns>
    public static DateTime StartOfDayUtc(this DateTime? value) => value.HasValue ? value.Value.StartOfDay() : DateTime.UtcNow.StartOfDay();

    /// <summary>
    /// Checks if the <see cref="T:System.DateTime" /> object has started
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>True if the current dateTime has gone past value</returns>
    public static bool HasStarted(this DateTime value) => value <= DateTime.Now;

    /// <summary>
    /// Checks if the <see cref="T:System.DateTime" /> object has started for UTC
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>True if the current UTC dateTime has gone past value</returns>
    public static bool HasStartedUtc(this DateTime value) => value <= DateTime.UtcNow;

    /// <summary>
    /// Checks if the <see cref="T:System.DateTime" /> object has started
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>True if the current dateTime has gone past value</returns>
    public static bool HasStarted(this DateTime? value) => value.GetValueOrDefault().HasStarted();

    /// <summary>
    /// Checks if the <see cref="T:System.DateTime" /> object has started for UTC
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>True if the current UTC dateTime has gone past value</returns>
    public static bool HasStartedUtc(this DateTime? value) => value.GetValueOrDefault().HasStartedUtc();

    /// <summary>
    /// Gets the start of the current system month
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object that is set to the first of the current month</returns>
    public static DateTime StartOfMonth(this DateTime value) => new DateTime(value.Year, value.Month, 1).StartOfDay();

    /// <summary>
    /// Gets the start of the current system month
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object that is set to the first of the current month</returns>
    public static DateTime StartOfMonth(this DateTime? value)
    {
        if (value.HasValue)
        {
            return new DateTime(value.Value.Year, value.Value.Month, 1).StartOfDay();
        }

        var currentDate = DateTime.Now;

        return new DateTime(currentDate.Year, currentDate.Month, 1).StartOfDay();
    }

    /// <summary>
    /// Gets the start of the UTC month
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object that is set to the first of the current month</returns>
    public static DateTime StartOfMonthUtc(this DateTime? value)
    {
        if (value.HasValue)
        {
            return new DateTime(value.Value.Year, value.Value.Month, 1).StartOfDay();
        }

        var currentDate = DateTime.UtcNow;

        return new DateTime(currentDate.Year, currentDate.Month, 1).StartOfDay();
    }

    /// <summary>
    /// Gets the end of the current system month
    /// </summary>
    /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object that is set to the end of the current month</returns>
    public static DateTime EndOfMonth(this DateTime value) => value.StartOfMonth().AddMonths(1).AddMilliseconds(-1);

    /// <summary>
    /// Gets the end of the current system month
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object that is set to the end of the current month</returns>
    public static DateTime EndOfMonth(this DateTime? value) => value.HasValue
        ? new DateTime(value.Value.Year, value.Value.Month, 1).EndOfMonth() : DateTime.Now.EndOfMonth();

    /// <summary>
    /// Gets the end of the UTC month
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
    /// <returns>A <see cref="T:System.DateTime" /> object that is set to the end of the current month</returns>
    public static DateTime EndOfMonthUtc(this DateTime? value) => value.HasValue
        ? new DateTime(value.Value.Year, value.Value.Month, 1).EndOfMonth() : DateTime.UtcNow.EndOfMonth();
}