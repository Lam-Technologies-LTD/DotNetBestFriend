using System.Diagnostics.CodeAnalysis;

namespace DotNetBestFriend;

public static class ValueTypeHelpers
{
    #region Integer
    /// <summary>
    /// Checks if the nullable int is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Int</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this int? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable int is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Int</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this int? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable int is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Int</param>
    /// <returns>True if the value is not null and below zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this int? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable int is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Int</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this int? value, int min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable int is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Int</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this int? value, int min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable int is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Int</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this int? value, int max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable int is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Int</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this int? value, int max) => value.GetValueOrDefault() <= max;

    /// <summary>
    /// Checks if nullable int is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Int</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this int? value, int number) => value.GetValueOrDefault().Equals(number);
    #endregion

    #region Guid
    /// <summary>
    /// Checks if the nullable guid is not null or an empty guid
    /// </summary>
    /// <param name="value">Nullable Guid</param>
    /// <returns>True if the value is not null or an empty guid</returns>
    public static bool IsValidValue([NotNullWhen(true)] this Guid? value) => value.GetValueOrDefault().NotEmptyGuid();

    /// <summary>
    /// Checks if value is an empty guid
    /// </summary>
    /// <param name="value">A <see cref="T:System.Guid" /> value</param>
    /// <returns>True if the value is an empty guid</returns>
    public static bool IsEmptyGuid(this Guid value) => value.Equals(default);

    /// <summary>
    /// Checks if value is not an empty guid
    /// </summary>
    /// <param name="value">A <see cref="T:System.Guid" /> value</param>
    /// <returns>True if the value is not an empty guid</returns>
    public static bool NotEmptyGuid(this Guid value) => !value.Equals(default);

    /// <summary>
    /// Checks if the nullable guid is not null and matches a guid
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.Guid" /> value</param>
    /// <param name="matching">Matching <see cref="T:System.Guid" /> value</param>
    /// <returns>True if the nullable guid is not null and matches a guid</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this Guid? value, Guid matching) => value.GetValueOrDefault().Equals(matching);

    /// <summary>
    /// Checks if the nullable guid is not null and matches a guid
    /// </summary>
    /// <param name="value">A nullable <see cref="T:System.Guid" /> value</param>
    /// <param name="matching">Matching string to be parsed into a <see cref="T:System.Guid" /> value</param>
    /// <returns>True if the nullable guid is not null and matches the parsed guid</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this Guid? value, string matching)
    {
        if (!Guid.TryParse(matching, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion

    #region Double
    /// <summary>
    /// Checks if the nullable double is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Double</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this double? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable double is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Double</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this double? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable double is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Double</param>
    /// <returns>True if the value is not null and below zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this double? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable double is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Double</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this double? value, double min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable double is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Double</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this double? value, double min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable double is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Double</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this double? value, double max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable double is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Double</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this double? value, double max) => value.GetValueOrDefault() <= max;

    /// <summary>
    /// Checks if nullable double is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Double</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this double? value, double number) => value.GetValueOrDefault().Equals(number);
    #endregion

    #region Float
    /// <summary>
    /// Checks if the nullable float is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Float</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this float? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable float is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Float</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this float? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable float is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Float</param>
    /// <returns>True if the value is not null and below zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this float? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable float is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Float</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this float? value, float min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable float is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Float</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this float? value, float min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable float is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Float</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this float? value, float max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable float is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Float</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this float? value, float max) => value.GetValueOrDefault() <= max;

    /// <summary>
    /// Checks if nullable float is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Float</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this float? value, float number) => value.GetValueOrDefault().Equals(number);
    #endregion

    #region Boolean
    /// <summary>
    /// Checks if the nullable boolean is true
    /// </summary>
    /// <param name="value">Nullable boolean</param>
    /// <returns>True if the value is not null and is true</returns>
    public static bool IsTrue([NotNullWhen(true)] this bool? value) => value.GetValueOrDefault();

    /// <summary>
    /// Checks if the nullable boolean is false
    /// </summary>
    /// <param name="value">Nullable boolean</param>
    /// <returns>True if the value is not null and is false</returns>
    public static bool IsFalse([NotNullWhen(true)] this bool? value) => !value.GetValueOrDefault();
    #endregion

    #region Decimal
    /// <summary>
    /// Checks if the nullable decimal is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this decimal? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable decimal is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this decimal? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable decimal is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <returns>True if the value is not null and below zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this decimal? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable decimal is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this decimal? value, decimal min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable decimal is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this decimal? value, decimal min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable decimal is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this decimal? value, decimal max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable decimal is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this decimal? value, decimal max) => value.GetValueOrDefault() <= max;

    /// <summary>
    /// Checks if nullable decimal is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this decimal? value, decimal number) => value.GetValueOrDefault().Equals(number);

    /// <summary>
    /// Rounds the decimal number to the nearest digits
    /// </summary>
    /// <param name="value">Decimal</param>
    /// <param name="places">Number of decimal places (Defaulted to 2)</param>
    /// <returns>A decimal that's been rounded</returns>
    public static decimal RoundToNearest(this decimal value, int places = 2) => Math.Round(value, places);

    /// <summary>
    /// Rounds the decimal number to the nearest digits
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <param name="places">Number of decimal places (Defaulted to 2)</param>
    /// <returns>A decimal that's been rounded</returns>
    [return: NotNullIfNotNull(nameof(value))]
    public static decimal RoundToNearest(this decimal? value, int places = 2) => value.GetValueOrDefault().RoundToNearest(places);

    /// <summary>
    /// Rounds the decimal to two decimal places for currency
    /// </summary>
    /// <param name="value">Decimal</param>
    /// <returns>A decimal that's been rounded to two places</returns>
    public static decimal FormatToCurrency(this decimal value) => value.RoundToNearest();

    /// <summary>
    /// Rounds the decimal to two decimal places for currency
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <returns>A decimal that's been rounded to two places</returns>
    [return: NotNullIfNotNull(nameof(value))]
    public static decimal FormatToCurrency(this decimal? value) => value.GetValueOrDefault().RoundToNearest(2);

    /// <summary>
    /// Turns a decimal into a standard currency string (Example: 1.59)
    /// </summary>
    /// <param name="value">Decimal</param>
    /// <returns>A string that been defaulted to currency</returns>
    public static string ToCurrencyString(this decimal value) => value.RoundToNearest(2).ToString("0.00");

    /// <summary>
    /// Turns a decimal into a standard currency string (Example: 1.59)
    /// </summary>
    /// <param name="value">Nullable Decimal</param>
    /// <returns>A string that been defaulted to currency</returns>
    [return: NotNullIfNotNull(nameof(value))]
    public static string ToCurrencyString(this decimal? value) => value.GetValueOrDefault().ToCurrencyString();
    #endregion

    #region Long
    /// <summary>
    /// Checks if the nullable long is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Long</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this long? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable long is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Long</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this long? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable long is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Long</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this long? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable long is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Long</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this long? value, long min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable long is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Long</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this long? value, long min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable long is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Long</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this long? value, long max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable long is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Long</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this long? value, long min) => value.GetValueOrDefault() <= min;

    /// <summary>
    /// Checks if nullable long is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Long</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this long? value, long number) => value.GetValueOrDefault().Equals(number);
    #endregion

    #region Byte
    /// <summary>
    /// Checks if the nullable byte is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Byte</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this byte? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable byte is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Byte</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this byte? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable byte is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Byte</param>
    /// <returns>True if the value is not null and below zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this byte? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable byte is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Byte</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this byte? value, byte min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable byte is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Byte</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this byte? value, byte min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable byte is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Byte</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this byte? value, byte max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable byte is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Byte</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this byte? value, byte max) => value.GetValueOrDefault() <= max;

    /// <summary>
    /// Checks if nullable byte is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Byte</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this byte? value, byte number) => value.GetValueOrDefault().Equals(number);
    #endregion

    #region SByte
    /// <summary>
    /// Checks if the nullable sbyte is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Sbyte</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this sbyte? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable sbyte is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Sbyte</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this sbyte? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable sbyte is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Sbyte</param>
    /// <returns>True if the value is not null and below zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this sbyte? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable sbyte is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Sbyte</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this sbyte? value, sbyte min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable sbyte is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Sbyte</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this sbyte? value, sbyte min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable sbyte is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Sbyte</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this sbyte? value, sbyte max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable sbyte is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Sbyte</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this sbyte? value, sbyte max) => value.GetValueOrDefault() <= max;

    /// <summary>
    /// Checks if nullable sbyte is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Sbyte</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this sbyte? value, sbyte number) => value.GetValueOrDefault().Equals(number);
    #endregion

    #region Ushort
    /// <summary>
    /// Checks if the nullable unsigned short is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Ushort</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this ushort? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable ushort is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Ushort</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this ushort? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable ushort is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Ushort</param>
    /// <returns>True if the value is not null and below zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this ushort? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable ushort is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Ushort</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this ushort? value, ushort min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable ushort is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Ushort</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this ushort? value, ushort min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable ushort is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Ushort</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this ushort? value, ushort max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable ushort is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Ushort</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this ushort? value, ushort max) => value.GetValueOrDefault() <= max;

    /// <summary>
    /// Checks if nullable ushort is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Ushort</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this ushort? value, ushort number) => value.GetValueOrDefault().Equals(number);
    #endregion

    #region Uint
    /// <summary>
    /// Checks if the nullable uint is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Uint</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this uint? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable uint is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Uint</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this uint? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable uint is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Uint</param>
    /// <returns>True if the value is not null and below zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this uint? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable uint is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Uint</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this uint? value, uint min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable uint is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Uint</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this uint? value, uint min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable uint is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Uint</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this uint? value, uint max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable uint is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Uint</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this uint? value, uint max) => value.GetValueOrDefault() <= max;

    /// <summary>
    /// Checks if nullable uint is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Uint</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this uint? value, uint number) => value.GetValueOrDefault().Equals(number);
    #endregion

    #region Ulong
    /// <summary>
    /// Checks if the nullable unsigned long is not null and not zero
    /// </summary>
    /// <param name="value">Nullable Ulong</param>
    /// <returns>True if the value is not null or zero</returns>
    public static bool IsValidValue([NotNullWhen(true)] this ulong? value) => !value.GetValueOrDefault().Equals(default);

    /// <summary>
    /// Checks if nullable ulong is not null and above zero
    /// </summary>
    /// <param name="value">Nullable Ulong</param>
    /// <returns>True if the value is not null and above zero</returns>
    public static bool IsValidAndAboveZero([NotNullWhen(true)] this ulong? value) => value.IsValidAndAbove(default);

    /// <summary>
    /// Checks if nullable ulong is not null and below zero
    /// </summary>
    /// <param name="value">Nullable Ulong</param>
    /// <returns>True if the value is not null and below zero</returns>
    public static bool IsValidAndBelowZero([NotNullWhen(true)] this ulong? value) => value.IsValidAndBelow(default);

    /// <summary>
    /// Checks if nullable ulong is not null and above the min value
    /// </summary>
    /// <param name="value">Nullable Ulong</param>
    /// <param name="min">Number to must be greater than</param>
    /// <returns>True if the value is not null and above min value</returns>
    public static bool IsValidAndAbove([NotNullWhen(true)] this ulong? value, ulong min) => value.GetValueOrDefault() > min;

    /// <summary>
    /// Checks if nullable ulong is not null and is equal or above the min value
    /// </summary>
    /// <param name="value">Nullable Ulong</param>
    /// <param name="min">Number to match or be greater than</param>
    /// <returns>True if the value is not null and is equal or above the min value</returns>
    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this ulong? value, ulong min) => value.GetValueOrDefault() >= min;

    /// <summary>
    /// Checks if nullable ulong is not null and is below the max value
    /// </summary>
    /// <param name="value">Nullable Ulong</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and is below the max value</returns>
    public static bool IsValidAndBelow([NotNullWhen(true)] this ulong? value, ulong max) => value.GetValueOrDefault() < max;

    /// <summary>
    /// Checks if nullable ulong is not null and matches or is below the max value
    /// </summary>
    /// <param name="value">Nullable Ulong</param>
    /// <param name="max">Number must be less than</param>
    /// <returns>True if the value is not null and matches or is below the max value</returns>
    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this ulong? value, ulong max) => value.GetValueOrDefault() <= max;

    /// <summary>
    /// Checks if nullable ulong is not null and matches number
    /// </summary>
    /// <param name="value">Nullable Ulong</param>
    /// <param name="number">Matching number</param>
    /// <returns>True if the value is not null and matches number</returns>
    public static bool IsValidAndMatches([NotNullWhen(true)] this ulong? value, ulong number) => value.GetValueOrDefault().Equals(number);
    #endregion
}