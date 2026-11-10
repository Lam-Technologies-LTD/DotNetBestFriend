namespace DotNetBestFriend;

public static class DateTimeHelpers
{
    extension(DateTime? value)
    {
        /// <summary>
        /// Allows ToFileTime to be useable with nullable <see cref="T:System.DateTime" />
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <param name="setToNowOnNull">If value is null decide if DateTime.Now or DateTime.MinValue filetime gets returned</param>
        /// <returns>The value of the current <see cref="T:System.DateTime" /> object expressed as a Windows file time.</returns>
        public long ToFileTime(bool setToNowOnNull = true)
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
        public long ToFileTimeUtc(bool setToUtcNowOnNull = true)
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
        public DateTime LastSecondOfTheDay(bool setToNowOnNull = true)
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
        public DateTime LastSecondOfTheDayUtc(bool setToUtcNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.LastSecondOfTheDay();
            }

            return setToUtcNowOnNull ? DateTime.UtcNow.LastSecondOfTheDay() : DateTime.MinValue.LastSecondOfTheDay();
        }

        /// <summary>
        /// Sets the <see cref="T:System.DateTime" /> value to exactly mid day
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <param name="setToNowOnNull">If value is null decide if DateTime.Now or DateTime.MinValue filetime gets returned</param>
        /// <returns>A <see cref="T:System.DateTime" /> object set to 12pm on the dot</returns>
        public DateTime Noon(bool setToNowOnNull = true)
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
        public DateTime NoonUtc(bool setToUtcNowOnNull = true)
        {
            if (value.HasValue)
            {
                return value.Value.Noon();
            }

            return setToUtcNowOnNull ? DateTime.UtcNow.Noon() : DateTime.MinValue.Noon();
        }

        /// <summary>
        /// Checks if the value is not null and also not default <see cref="T:System.DateTime" /> (DateTime.Min)
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <returns>True if the value is not null and not DateTime.Min</returns>
        public bool IsValidValue() => value.GetValueOrDefault() != default(DateTime);

        /// <summary>
        /// Checks if the value has not yet expired
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <param name="dateOnly">Focus on the date and not the time</param>
        /// <returns>True if the value has not past DateTime.Now</returns>
        public bool HasNotExpired(bool dateOnly = false) => value.GetValueOrDefault().HasNotExpired(dateOnly);

        /// <summary>
        /// Checks if the value has not expired for UTC
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <param name="dateOnly">Focus on the date and not the time</param>
        /// <returns>True if the value has not past DateTime.UtcNow</returns>
        public bool HasNotExpiredUtc(bool dateOnly = false) => value.GetValueOrDefault().HasNotExpiredUtc(dateOnly);

        /// <summary>
        /// Checks if the value has expired
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <param name="dateOnly">Focus on the date and not the time</param>
        /// <returns>True if the value has gone past DateTime.Now</returns>
        public bool HasExpired(bool dateOnly = false) => value.GetValueOrDefault().HasExpired(dateOnly);

        /// <summary>
        /// Checks if the value has expired for UTC
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <param name="dateOnly">Focus on the date and not the time</param>
        /// <returns>True if the value has gone past DateTime.UtcNow</returns>
        public bool HasExpiredUtc(bool dateOnly = false) => value.GetValueOrDefault().HasExpiredUtc(dateOnly);

        /// <summary>
        /// Checks if the date is today
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <returns>True if the value is the current date</returns>
        public bool IsToday() => value.GetValueOrDefault().IsToday();

        /// <summary>
        /// Checks if the date is today for UTC
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <returns>True if the value is the current UTC date</returns>
        public bool IsTodayUtc() => value.GetValueOrDefault().IsTodayUtc();

        /// <summary>
        /// Gets the age of the date provided
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>An interger</returns>
        public int GetAge() => value.HasValue ? value.Value.GetAge() : default;

        /// <summary>
        /// Gets the age of the date provided using UTC
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>An interger</returns>
        public int GetAgeUtc() => value.HasValue ? value.Value.GetAgeUtc() : default;


        /// <summary>
        /// Sets the <see cref="T:System.DateTime" /> object to midnight
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>An interger</returns>
        public DateTime StartOfDay() => value.HasValue ? value.Value.StartOfDay() : DateTime.Now.StartOfDay();

        /// <summary>
        /// Sets the <see cref="T:System.DateTime" /> object to midnight for UTC
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>An interger</returns>
        public DateTime StartOfDayUtc() => value.HasValue ? value.Value.StartOfDay() : DateTime.UtcNow.StartOfDay();

        /// <summary>
        /// Checks if the <see cref="T:System.DateTime" /> object has started
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>True if the current dateTime has gone past value</returns>
        public bool HasStarted() => value.GetValueOrDefault().HasStarted();

        /// <summary>
        /// Checks if the <see cref="T:System.DateTime" /> object has started for UTC
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>True if the current UTC dateTime has gone past value</returns>
        public bool HasStartedUtc() => value.GetValueOrDefault().HasStartedUtc();

        /// <summary>
        /// Gets the start of the UTC month
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object that is set to the first of the current month</returns>
        public DateTime StartOfMonthUtc()
        {
            if (value.HasValue)
            {
                return new DateTime(value.Value.Year, value.Value.Month, 1).StartOfDay();
            }

            var currentDate = DateTime.UtcNow;

            return new DateTime(currentDate.Year, currentDate.Month, 1).StartOfDay();
        }

        /// <summary>
        /// Gets the start of the current system month
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object that is set to the first of the current month</returns>
        public DateTime StartOfMonth()
        {
            if (value.HasValue)
            {
                return new DateTime(value.Value.Year, value.Value.Month, 1).StartOfDay();
            }

            var currentDate = DateTime.Now;

            return new DateTime(currentDate.Year, currentDate.Month, 1).StartOfDay();
        }

        /// <summary>
        /// Gets the end of the current system month
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object that is set to the end of the current month</returns>
        public DateTime EndOfMonth() => value.HasValue
            ? new DateTime(value.Value.Year, value.Value.Month, 1).EndOfMonth() : DateTime.Now.EndOfMonth();

        /// <summary>
        /// Gets the end of the UTC month
        /// </summary>
        /// <param name="value">A nullable <see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object that is set to the end of the current month</returns>
        public DateTime EndOfMonthUtc() => value.HasValue
            ? new DateTime(value.Value.Year, value.Value.Month, 1).EndOfMonth() : DateTime.UtcNow.EndOfMonth();
    }

    extension(DateTime value)
    {
        /// <summary>
        /// Sets the <see cref="T:System.DateTime" /> value to the last possible moment of the day for UTC
        /// </summary>
        /// <param name="value">Nullable <see cref="T:System.DateTime" /></param>
        /// <returns>A <see cref="T:System.DateTime" /> object with the time value at the last second before midnight</returns>
        public DateTime LastSecondOfTheDay() => new DateTime(value.Year, value.Month, value.Day).AddDays(1).AddMilliseconds(-1);

        /// <summary>
        /// Sets the <see cref="T:System.DateTime" /> value to exactly mid day
        /// </summary>
        /// <param name="value"><see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object set to 12pm on the dot</returns>
        public DateTime Noon() => new DateTime(value.Year, value.Month, value.Day, 12, 0, 0, 0);

        /// <summary>
        /// Checks if the value has not yet expired
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <param name="dateOnly">Focus on the date and not the time</param>
        /// <returns>True if the value has not past DateTime.Now</returns>
        public bool HasNotExpired(bool dateOnly = false) => dateOnly ? value.Date >= DateTime.Now.Date : value >= DateTime.Now;

        /// <summary>
        /// Checks if the value has not expired for UTC
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <param name="dateOnly">Focus on the date and not the time</param>
        /// <returns>True if the value has not past DateTime.UtcNow</returns>
        public bool HasNotExpiredUtc(bool dateOnly = false) => dateOnly ? value.Date >= DateTime.UtcNow.Date : value >= DateTime.UtcNow;

        /// <summary>
        /// Checks if the value has expired
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <param name="dateOnly">Focus on the date and not the time</param>
        /// <returns>True if the value has gone past DateTime.Now</returns>
        public bool HasExpired(bool dateOnly = false) => dateOnly ? value.Date < DateTime.Now.Date : value < DateTime.Now;

        /// <summary>
        /// Checks if the value has expired for UTC
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <param name="dateOnly">Focus on the date and not the time</param>
        /// <returns>True if the value has gone past DateTime.UtcNow</returns>
        public bool HasExpiredUtc(bool dateOnly = false) => dateOnly ? value.Date < DateTime.UtcNow.Date : value < DateTime.UtcNow;

        /// <summary>
        /// Checks if the date is today for UTC
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>True if the value is the current date</returns>
        public bool IsToday() => value.Date == DateTime.Now.Date;

        /// <summary>
        /// Checks if the date is today for UTC
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>True if the value is the current UTC date</returns>
        public bool IsTodayUtc() => value.Date == DateTime.UtcNow.Date;

        /// <summary>
        /// Sets the value to the very start of the year
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object set to 1st January of the current year</returns>
        public DateTime BeginningOfTheYear() => new DateTime(value.Year, 1, 1);

        /// <summary>
        /// Sets the value to the last moment of the year
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object set to the 31st December of the current year at 11:59:59.999 PM</returns>
        public DateTime EndOfTheYear() => new DateTime(value.Year, 12, 31, 23, 59, 59, 999);

        /// <summary>
        /// Returns the full month string of the value
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>The name of the month</returns>
        public string GetMonthFull() => value.ToString("MMMM");

        /// <summary>
        /// Returns the short month string of the value
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>The abbreviation of the month</returns>
        public string GetMonthShort() => value.ToString("MMM");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Day/Month/Year</returns>
        public string ToDMYStringSlash() => value.ToString("dd/MM/yyyy");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Day/Month/Year Hours:Minutes:Seconds</returns>
        public string ToDMY24HourStringSlash() => value.ToString("dd/MM/yyyy HH:mm:ss");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Day/Month/Year Hours:Minutes:Seconds AM/PM</returns>
        public string ToDMY12HourStringSlash() => value.ToString("dd/MM/yyyy hh:mm:ss tt");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Month/Day/Year</returns>
        public string ToMDYStringSlash() => value.ToString("MM/dd/yyyy");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Month/Day/Year Hours:Minutes:Seconds</returns>
        public string ToMDY24HourStringSlash() => value.ToString("MM/dd/yyyy HH:mm:ss");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Month/Day/Year Hours:Minutes:Seconds AM/PM</returns>
        public string ToMDY12HourStringSlash() => value.ToString("MM/dd/yyyy hh:mm:ss tt");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Year/Month/Date</returns>
        public string ToYMDStringSlash() => value.ToString("yyyy/MM/dd");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Year/Month/Date Hours:Minutes:Seconds</returns>
        public string ToYMD24HourStringSlash() => value.ToString("yyyy/MM/dd HH:mm:ss");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Year/Month/Date Hours:Minutes:Seconds AM/PM</returns>
        public string ToYMD12HourStringSlash() => value.ToString("yyyy/MM/dd hh:mm:ss tt");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Day-Month-Year</returns>
        public string ToDMYStringDash() => value.ToString("dd-MM-yyyy");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Day-Month-Year Hours:Minutes:Seconds</returns>
        public string ToDMY24HourStringDash() => value.ToString("dd-MM-yyyy HH:mm:ss");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Day-Month-Year Hours:Minutes:Seconds AM/PM</returns>
        public string ToDMY12HourStringDash() => value.ToString("dd-MM-yyyy hh:mm:ss tt");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Month/Day/Year</returns>
        public string ToMDYStringDash() => value.ToString("MM-dd-yyyy");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Month/Day/Year Hours:Minutes:Seconds</returns>
        public string ToMDY24HourStringDash() => value.ToString("MM-dd-yyyy HH:mm:ss");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Month/Day/Year Hours:Minutes:Seconds AM/PM</returns>
        public string ToMDY12HourStringDash() => value.ToString("MM-dd-yyyy HH:mm:ss tt");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Year-Month-Date</returns>
        public string ToYMDStringDash() => value.ToString("yyyy-MM-dd");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Year-Month-Date Hours:Minutes:Seconds</returns>
        public string ToYMD24HourStringDash() => value.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// Returns the date of the value in string format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Year-Month-Date Hours:Minutes:Seconds AM/PM</returns>
        public string ToYMD12HourStringDash() => value.ToString("yyyy-MM-dd HH:mm:ss tt");

        /// <summary>
        /// Returns the time string only in 24 hour format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>A string in the format of Hours:Minutes:Seconds</returns>
        public string Get24HourTimeOnlyString() => value.ToString("HH:mm:ss");

        /// <summary>
        /// Returns the time string only in 12 hour format
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>A string in the format of Hours:Minutes:Seconds AM/PM</returns>
        public string Get12HourTimeOnlyString() => value.ToString("hh:mm:ss tt");

        /// <summary>
        /// Returns the date in a formatted string without any spaces
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Year Month Date string</returns>
        public string ToYMDOnlyString() => value.ToString("yyyyMMdd");

        /// <summary>
        /// Returns the date in a formatted string without any spaces
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Month Date Year string</returns>
        public string ToMDYOnlyString() => value.ToString("MMddyyyy");

        /// <summary>
        /// Returns the date in a formatted string without any spaces
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>Date Month Year string</returns>
        public string ToDMYOnlyString() => value.ToString("ddMMyyyy");

        /// <summary>
        /// Gets the age of the date provided
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>An interger</returns>
        public int GetAge()
        {
            var retVal = new DateTime((DateTime.Now - value).Ticks).Year - 1;

            return retVal > default(int) ? retVal : default;
        }

        /// <summary>
        /// Gets the age of the date provided using UTC
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>An interger</returns>
        public int GetAgeUtc() => DateTime.UtcNow.Year - value.Year;

        /// <summary>
        /// Sets the <see cref="T:System.DateTime" /> object to midnight
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object</returns>
        public DateTime StartOfDay() => new DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0);

        /// <summary>
        /// Checks if the <see cref="T:System.DateTime" /> object has started
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>True if the current dateTime has gone past value</returns>
        public bool HasStarted() => value <= DateTime.Now;

        /// <summary>
        /// Checks if the <see cref="T:System.DateTime" /> object has started for UTC
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>True if the current UTC dateTime has gone past value</returns>
        public bool HasStartedUtc() => value <= DateTime.UtcNow;

        /// <summary>
        /// Gets the start of the current system month
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object that is set to the first of the current month</returns>
        public DateTime StartOfMonth() => new DateTime(value.Year, value.Month, 1).StartOfDay();

        /// <summary>
        /// Gets the end of the current system month
        /// </summary>
        /// <param name="value">A <see cref="T:System.DateTime" /> object</param>
        /// <returns>A <see cref="T:System.DateTime" /> object that is set to the end of the current month</returns>
        public DateTime EndOfMonth() => value.StartOfMonth().AddMonths(1).AddMilliseconds(-1);
    }
}