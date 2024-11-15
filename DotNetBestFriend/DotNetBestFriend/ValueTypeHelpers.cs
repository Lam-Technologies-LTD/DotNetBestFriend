using System.Diagnostics.CodeAnalysis;

namespace DotNetBestFriend;

public static class ValueTypeHelpers
{
    #region Integer
    public static bool IsValidValue([NotNullWhen(true)] this int? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this int? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this int? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this int? value, int min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this int? value, int min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this int? value, int max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this int? value, int max) => value.GetValueOrDefault() <= max;

    public static bool IsValidAndMatches([NotNullWhen(true)] this int? value, int number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this int? value, string number) 
    { 
        if (!int.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion

    #region Guid
    public static bool IsValidValue([NotNullWhen(true)] this Guid? value) => value.GetValueOrDefault().NotEmptyGuid();

    public static bool IsEmptyGuid([NotNullWhen(true)] this Guid value) => value.Equals(default);

    public static bool NotEmptyGuid([NotNullWhen(true)] this Guid value) => !value.Equals(default);

    public static bool IsValidAndMatches([NotNullWhen(true)] this Guid? value, Guid matching) => value.GetValueOrDefault().Equals(matching);

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
    public static bool IsValidValue([NotNullWhen(true)] this double? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this double? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this double? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this double? value, double min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this double? value, double min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this double? value, double max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this double? value, double max) => value.GetValueOrDefault() <= max;

    public static bool IsValidAndMatches([NotNullWhen(true)] this double? value, double number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this double? value, string number) 
    {
        if (!double.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion

    #region Float
    public static bool IsValidValue([NotNullWhen(true)] this float? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this float? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this float? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this float? value, float min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this float? value, float min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this float? value, float max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this float? value, float max) => value.GetValueOrDefault() <= max;

    public static bool IsValidAndMatches([NotNullWhen(true)] this float? value, float number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this float? value, string number)
    {
        if (!float.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion

    #region Boolean
    public static bool IsTrue([NotNullWhen(true)] this bool? value) => value.GetValueOrDefault();

    public static bool IsFalse([NotNullWhen(true)] this bool? value) => !value.GetValueOrDefault();
    #endregion

    #region Decimal
    public static bool IsValidValue([NotNullWhen(true)] this decimal? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this decimal? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this decimal? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this decimal? value, decimal min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this decimal? value, decimal min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this decimal? value, decimal max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this decimal? value, decimal max) => value.GetValueOrDefault() <= max;

    public static bool IsValidAndMatches([NotNullWhen(true)] this decimal? value, decimal number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this decimal? value, string number)
    {
        if (!decimal.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }

    public static decimal RoundToNearest(this decimal value, int places = 2) => Math.Round(value, places);

    public static decimal RoundToNearest(this decimal? value, int places = 2) => value.GetValueOrDefault().RoundToNearest(places);

    public static decimal FormatToCurrency(this decimal value) => value.RoundToNearest(2);

    public static decimal FormatToCurrency(this decimal? value) => value.GetValueOrDefault().RoundToNearest(2);

    public static string ToCurrencyString(this decimal value) => value.RoundToNearest(2).ToString("0.00");

    public static string ToCurrencyString(this decimal? value) => value.GetValueOrDefault().ToCurrencyString();
    #endregion

    #region Long
    public static bool IsValidValue([NotNullWhen(true)] this long? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this long? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this long? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this long? value, long min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this long? value, long min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this long? value, long max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this long? value, long min) => value.GetValueOrDefault() <= min;

    public static bool IsValidAndMatches([NotNullWhen(true)] this long? value, long number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this long? value, string number)
    {
        if (!long.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion

    #region Byte
    public static bool IsValidValue([NotNullWhen(true)] this byte? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this byte? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this byte? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this byte? value, byte min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this byte? value, byte min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this byte? value, byte max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this byte? value, byte max) => value.GetValueOrDefault() <= max;

    public static bool IsValidAndMatches([NotNullWhen(true)] this byte? value, byte number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this byte? value, string number)
    {
        if (!byte.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion

    #region SByte
    public static bool IsValidValue([NotNullWhen(true)] this sbyte? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this sbyte? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this sbyte? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this sbyte? value, sbyte min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this sbyte? value, sbyte min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this sbyte? value, sbyte max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this sbyte? value, sbyte max) => value.GetValueOrDefault() <= max;

    public static bool IsValidAndMatches([NotNullWhen(true)] this sbyte? value, sbyte number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this sbyte? value, string number)
    {
        if (!sbyte.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion

    #region Ushort
    public static bool IsValidValue([NotNullWhen(true)] this ushort? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this ushort? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this ushort? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this ushort? value, ushort min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this ushort? value, ushort min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this ushort? value, ushort max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this ushort? value, ushort max) => value.GetValueOrDefault() <= max;

    public static bool IsValidAndMatches([NotNullWhen(true)] this ushort? value, ushort number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this ushort? value, string number)
    {
        if (!ushort.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion

    #region Uint
    public static bool IsValidValue([NotNullWhen(true)] this uint? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this uint? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this uint? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this uint? value, uint min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this uint? value, uint min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this uint? value, uint max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this uint? value, uint max) => value.GetValueOrDefault() <= max;

    public static bool IsValidAndMatches([NotNullWhen(true)] this uint? value, uint number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this uint? value, string number)
    {
        if (!uint.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion

    #region Ulong
    public static bool IsValidValue([NotNullWhen(true)] this ulong? value) => !value.GetValueOrDefault().Equals(default);

    public static bool IsValidAndAboveZero([NotNullWhen(true)] this ulong? value) => value.IsValidAndAbove(default);

    public static bool IsValidAndBelowZero([NotNullWhen(true)] this ulong? value) => value.IsValidAndBelow(default);

    public static bool IsValidAndAbove([NotNullWhen(true)] this ulong? value, ulong min) => value.GetValueOrDefault() > min;

    public static bool IsValidAndEqualsOrAbove([NotNullWhen(true)] this ulong? value, ulong min) => value.GetValueOrDefault() >= min;

    public static bool IsValidAndBelow([NotNullWhen(true)] this ulong? value, ulong max) => value.GetValueOrDefault() < max;

    public static bool IsValidAndEqualsOrBelow([NotNullWhen(true)] this ulong? value, ulong max) => value.GetValueOrDefault() <= max;

    public static bool IsValidAndMatches([NotNullWhen(true)] this ulong? value, ulong number) => value.GetValueOrDefault().Equals(number);

    public static bool IsValidAndMatches([NotNullWhen(true)] this ulong? value, string number)
    {   
        if (!ulong.TryParse(number, out var parsedValue))
        {
            return false;
        }

        return value.GetValueOrDefault().Equals(parsedValue);
    }
    #endregion
}