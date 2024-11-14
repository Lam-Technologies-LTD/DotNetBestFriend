using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DotNetBestFriend;

public static class StringHelpers
{
    /// <summary>
    /// Builds a single string with from a list of strings and a delimiter
    /// </summary>
    /// <param name="collection">List of objects</param>
    /// <param name="seperator">Any string value</param>
    /// <param name="throwOnError">Throws an exception on error</param>
    /// <returns>A new string joined together by a delimiter</returns>
    /// <exception cref="ArgumentNullException">Thrown if the collection is null and throwOnError is True</exception>
    public static string ToSeperatedString<T>(this IEnumerable<T>? collection, string? seperator, bool throwOnError = false)
    {
        if (collection.IsNullOrEmpty() || seperator is null)
        {
            if (throwOnError)
            {
                throw new ArgumentNullException("The collection of string is null or empty!");
            }

            return string.Empty;
        }

        return string.Join(seperator, collection);
    }

    /// <summary>
    /// Combines the whole list of strings into a comma seperated string
    /// </summary>
    /// <param name="collection">List of objects</param>
    /// <param name="throwOnError">Throws an exception on error</param>
    /// <returns>A comma seperated string</returns>
    public static string ToCommaSeperatedString<T>(this IEnumerable<T>? collection, bool throwOnError = false) => collection.ToSeperatedString(",", throwOnError);

    /// <summary>
    /// Trims the string regardless of null status
    /// </summary>
    /// <param name="value">The original string</param>
    /// <returns>A trimmed string is not null. An empty string if null or white spaces</returns>
    public static string SafeTrim(this string? value) => !string.IsNullOrWhiteSpace(value) ? value.Trim() : string.Empty;

    /// <summary>
    /// Seperates the captial letters
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="removeWhitespaces">Trim white spaces</param>
    /// <param name="throwOnError">Throw an exception on error</param>
    /// <returns>A string with the captial letters seperated</returns>
    /// <exception cref="ArgumentNullException">If the string is null or white spaces and throwOnError is True</exception>
    /// <exception cref="Exception">If there are no capital letters in the string and throwOnError is True</exception>
    public static string SeperateCapitalLetters(this string? value, bool removeWhitespaces = false, bool throwOnError = false)
    {
        if (value.IsNullOrWhiteSpace())
        {
            if (throwOnError)
            {
                throw new ArgumentNullException("The string should not be null or full of white spaces!");
            }

            return string.Empty;
        }

        var valueCopy = removeWhitespaces ? value.Trim() : value;

        var words = Regex.Split(valueCopy, @"(?<!^)(?=[A-Z])");

        if (words.IsNotNullOrEmpty())
        {
            var sb = new StringBuilder();

            foreach (var word in words)
            {
                sb.Append($"{word} ");
            }

            var retVal = sb.ToString();

            return retVal.Remove(retVal.Length - 1, 1);
        }

        if (throwOnError)
        {
            throw new Exception("There's no capital letters in this string!");
        }

        return value ?? string.Empty;
    }

    /// <summary>
    /// Sets the first letter of the string to an upper case letter
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="removeWhitespaces">Remove any whitespaces</param>
    /// <returns>A new string with a the first letter in upper case</returns>
    public static string SetFirstLetterToUpperCase(this string? value, bool removeWhitespaces = false)
    {
        if (value.IsNotNullOrWhiteSpace())
        {
            if (removeWhitespaces)
            {
                value = value.Trim();
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (char.IsLetter(value[i]))
                {
                    return $"{char.ToUpper(value[i])}{value.Substring(1).ToLower()}";
                }
            }
        }

        return value ?? string.Empty;
    }

    /// <summary>
    /// Checks if the string is a valid url
    /// </summary>
    /// <param name="url">The original string</param>
    /// <returns>True if the string is a valid url</returns>
    public static bool IsValidUrl(this string? url)
    {
        try
        {
            if (url.IsNotNullOrWhiteSpace())
            {
                return Uri.TryCreate(url.Trim(), UriKind.Absolute, out var uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            }

            return false;
        }
        catch (Exception)
        {
            return true;
        }
    }

    /// <summary>
    /// Maps a Json string to an generic type
    /// </summary>
    /// <typeparam name="T">Can be value or reference type</typeparam>
    /// <param name="json">The original string (does not have be a serialized string)</param>
    /// <param name="throwOnError">Throws an exception on error</param>
    /// <param name="options">System.Text.Json parse options</param>
    /// <returns>The generic type with the string mapped</returns>
    public static T MapJsonString<T>(this string? json, bool throwOnError = false, JsonSerializerOptions? options = null)
    {
        try
        {
            var trimmedJson = json.IsNotNullOrWhiteSpace() ? json.Trim() : string.Empty;

            var genericType = typeof(T);

            if (genericType == typeof(string))
            {
                return (T)Convert.ChangeType(trimmedJson, genericType);
            }

            if (genericType.IsValueType)
            {
                object retVal;

                if (genericType == typeof(int) || genericType == typeof(int?))
                {
                    retVal = int.Parse(trimmedJson);
                }
                else if (genericType == typeof(double) || genericType == typeof(double?))
                {
                    retVal = double.Parse(trimmedJson);
                }
                else if (genericType == typeof(DateTime) || genericType == typeof(DateTime?))
                {
                    retVal = DateTime.Parse(trimmedJson);
                }
                else if (genericType == typeof(bool) || genericType == typeof(bool?))
                {
                    retVal = bool.Parse(trimmedJson.ToLower());
                }
                else if (genericType == typeof(decimal) || genericType == typeof(decimal?))
                {
                    retVal = decimal.Parse(trimmedJson);
                }
                else if (genericType == typeof(float) || genericType == typeof(float?))
                {
                    retVal = float.Parse(trimmedJson);
                }
                else if (genericType == typeof(Guid) || genericType == typeof(Guid?))
                {
                    retVal = Guid.Parse(trimmedJson);
                }
                else if (genericType == typeof(sbyte) || genericType == typeof(sbyte?))
                {
                    retVal = sbyte.Parse(trimmedJson);
                }
                else if (genericType == typeof(byte) || genericType == typeof(byte?))
                {
                    retVal = byte.Parse(trimmedJson);
                }
                else if (genericType == typeof(short) || genericType == typeof(short?))
                {
                    retVal = short.Parse(trimmedJson);
                }
                else if (genericType == typeof(ushort) || genericType == typeof(ushort?))
                {
                    retVal = ushort.Parse(trimmedJson);
                }
                else if (genericType == typeof(uint) || genericType == typeof(uint?))
                {
                    retVal = uint.Parse(trimmedJson);
                }
                else if (genericType == typeof(ulong) || genericType == typeof(ulong?))
                {
                    retVal = ulong.Parse(trimmedJson);
                }
                else if (genericType == typeof(char) || genericType == typeof(char?))
                {
                    retVal = char.Parse(trimmedJson);
                }
                else if (genericType == typeof(long) || genericType == typeof(long?))
                {
                    retVal = long.Parse(trimmedJson);
                }
                else
                {
                    throw new Exception($"{genericType.Name} is not supported");
                }

                return (T)Convert.ChangeType(retVal, genericType);
            }

            if (options is null)
            {
                options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
            }

            return JsonSerializer.Deserialize<T>(json, options);
        }
        catch (ArgumentNullException)
        {
            if (throwOnError)
            {
                throw;
            }
        }
        catch (Exception)
        {
            if (throwOnError)
            {
                throw;
            }
        }

        return default;
    }

    /// <summary>
    /// Converts the string to a Interger (32-bit number)
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Interger</returns>
    public static int ToInt(this object value, bool throwOnError = false) => value.ToNullableInt(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable Integer (32-bit number)
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable Interger</returns>
    public static int? ToNullableInt(this object value, bool throwOnError = false)
    {
        try
        {
            if (int.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a Double
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Double</returns>
    public static double ToDouble(this object value, bool throwOnError = false) => value.ToNullableDouble(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable Double
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable Double</returns>
    public static double? ToNullableDouble(this object value, bool throwOnError = false)
    {
        try
        {
            if (double.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a Float
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Float</returns>
    public static float ToFloat(this object value, bool throwOnError = false) => value.ToNullableFloat(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable Float
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable Float</returns>
    public static float? ToNullableFloat(this object value, bool throwOnError = false)
    {
        try
        {
            if (float.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a bool
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>True is the string is True</returns>
    public static bool IsTrue(this object value, bool throwOnError = false) => value.ToSafeString().MapJsonString<bool>(throwOnError);

    /// <summary>
    /// Converts the string to a Decimal
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Decimal</returns>
    public static decimal ToDecimal(this object value, bool throwOnError = false) => value.ToNullableDecimal(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable Decimal
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable Decimal</returns>
    public static decimal? ToNullableDecimal(this object value, bool throwOnError = false)
    {
        try
        {
            if (decimal.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a DateTime
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A DateTime</returns>
    public static DateTime ToDateTime(this object value, bool throwOnError = false) => value.ToNullableDateTime(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable DateTime
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable DateTime</returns>
    public static DateTime? ToNullableDateTime(this object value, bool throwOnError = false)
    {
        try
        {
            if (DateTime.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a Guid
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Guid</returns>
    public static Guid ToGuid(this object value, bool throwOnError = false) => value.ToNullableGuid(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable Guid
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable Guid</returns>
    public static Guid? ToNullableGuid(this object value, bool throwOnError = false)
    {
        try
        {
            if (Guid.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a long (64 bit number)
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Long (64-bit number)</returns>
    public static long ToLong(this object value, bool throwOnError = false) => value.ToNullableLong(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable long (64 bit number)
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable Long</returns>
    public static long? ToNullableLong(this object value, bool throwOnError = false)
    {
        try
        {
            if (long.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a Boolean
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Boolean</returns>
    public static bool ToBool(this object value, bool throwOnError = false) => value.ToNullableBool(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable boolean
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable boolean</returns>
    public static bool? ToNullableBool(this object value, bool throwOnError = false)
    {
        try
        {
            if (bool.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a short (16 bit number)
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A short</returns>
    public static short ToShort(this object value, bool throwOnError = false) => value.ToNullableShort(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable short (16 bit number)
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable short</returns>
    public static short? ToNullableShort(this object value, bool throwOnError = false)
    {
        try
        {
            if (short.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a byte (8 bit number)
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A byte</returns>
    public static byte ToByte(this object value, bool throwOnError = false) => value.ToNullableByte(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable byte (8 bit number)
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable byte</returns>
    public static byte? ToNullableByte(this object value, bool throwOnError = false)
    {
        try
        {
            if (byte.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a ulong
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A ulong</returns>
    public static ulong ToUlong(this object value, bool throwOnError = false) => value.ToNullableUlong(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable ulong
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable ulong</returns>
    public static ulong? ToNullableUlong(this object value, bool throwOnError = false)
    {
        try
        {
            if (ulong.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a uint
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A uint</returns>
    public static uint ToUint(this object value, bool throwOnError = false) => value.ToNullableUint(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable uint
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable uint</returns>
    public static uint? ToNullableUint(this object value, bool throwOnError = false)
    {
        try
        {
            if (uint.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a ushort
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A ushort</returns>
    public static ushort ToUshort(this object value, bool throwOnError = false) => value.ToNullableUshort(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable ushort
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable ushort</returns>
    public static ushort? ToNullableUshort(this object value, bool throwOnError = false)
    {
        try
        {
            if (ushort.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Converts the string to a sbyte
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A sbyte</returns>
    public static sbyte ToSbyte(this object value, bool throwOnError = false) => value.ToNullableSbyte(throwOnError).GetValueOrDefault();

    /// <summary>
    /// Converts the string to a nullable sbyte
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="throwOnError">Throw exception on error</param>
    /// <returns>A Nullable sbyte</returns>
    public static sbyte? ToNullableSbyte(this object value, bool throwOnError = false)
    {
        try
        {
            if (sbyte.TryParse(value.ToSafeString(), out var retVal))
                return retVal;

            return default;
        }
        catch (Exception)
        {
            if (throwOnError)
                throw;

            return default;
        }
    }

    /// <summary>
    /// Turns the string into camelCase
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="removeWhitespaces">Trims the string</param>
    /// <returns>A new string in camelCase</returns>
    public static string ToCamelCase(this string? value, bool removeWhitespaces = false)
    {
        if (value.IsNotNullOrWhiteSpace())
        {
            if (removeWhitespaces)
            {
                value = value.Trim();
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (char.IsLetter(value[i]))
                {
                    return $"{char.ToLower(value[i])}{value.Substring(1).ToLower()}";
                }
            }
        }

        return value ?? string.Empty;
    }

    /// <summary>
    /// Checks if the string is null or full of whitespaces
    /// </summary>
    /// <param name="value">The original string</param>
    /// <returns>True if the string does not have any characters inside</returns>
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value) => string.IsNullOrWhiteSpace(value.SafeTrim());

    /// <summary>
    /// Checks if the string is not null or full of whitespaces
    /// </summary>
    /// <param name="value">The original string</param>
    /// <returns>True if the string has characters inside</returns>
    public static bool IsNotNullOrWhiteSpace([NotNullWhen(true)] this string? value) => !string.IsNullOrWhiteSpace(value.SafeTrim());

    /// <summary>
    /// Quickly converts a list of objects in a url query string
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    /// <param name="args">List of objects</param>
    /// <param name="argumentName">Name of the argument to fill</param>
    /// <param name="throwOnError">Throw exceptions on error</param>
    /// <param name="queryStringStarted">Decides if the returning string starts with a question mark or ampersand</param>
    /// <returns>A string ready to use as the url query string</returns>
    public static string ToUrlQueryString<T>(this IList<T>? args, string? argumentName, bool throwOnError = false, bool queryStringStarted = false)
    {
        try
        {
            if (args.IsNullOrEmpty())
            {
                throw new ArgumentNullException("The lists cannot be empty!");
            }

            if (argumentName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("The argument name cannot be null!");
            }

            var retVal = new StringBuilder(queryStringStarted ? "&" : "?");

            var genericType = typeof(T);

            if (genericType == typeof(string))
            {
                for (var i = 0; i < args.Count; i++)
                {
                    if (args[i] is null)
                    {
                        continue;
                    }

                    retVal.Append($"{argumentName}={args[i].ToSafeString()}&");
                }
            }
            else if (genericType.IsValueType)
            {
                for (var i = 0; i < args.Count; i++)
                {
                    retVal.Append($"{argumentName}={args[i]}&");
                }
            }
            else
            {
                for (var i = 0; i < args.Count; i++)
                {
                    retVal.Append($"{argumentName}={JsonSerializer.Serialize(args[i])}&");
                }
            }

            return retVal.ToString().RemoveLastCharacter();
        }
        catch (ArgumentNullException)
        {
            if (throwOnError)
            {
                throw;
            }
        }
        catch (Exception)
        {
            if (throwOnError)
            {
                throw;
            }
        }

        return string.Empty;
    }

    /// <summary>
    /// Safely converts the StringBuilder object to a string regardless of null status
    /// </summary>
    /// <param name="sb">StringBuilder object</param>
    /// <returns>Empty string if the object is null</returns>
    public static string ToSafeString(this StringBuilder? sb) => sb is null ? string.Empty : sb.ToString().SafeTrim();

    /// <summary>
    /// Removes the very last character of the string
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="removeWhitespaces">Trim off any white spaces</param>
    /// <param name="throwOnError">Throws exceptions on errors</param>
    /// <returns>A string with its last character removed</returns>
    public static string RemoveLastCharacter(this string? value, bool removeWhitespaces = false, bool throwOnError = false) => value.RemoveEndCharacters(1, removeWhitespaces, throwOnError);

    /// <summary>
    /// Removes a set amount of characters at the end of the string
    /// </summary>
    /// <param name="value">The original string</param>
    /// <param name="endCharactersToRemove">Number of characters to remove</param>
    /// <param name="removeWhitespaces">Trim off any white spaces</param>
    /// <param name="throwOnError">Throws exceptions on errors</param>
    /// <returns>A new string with the end characters removed</returns>
    /// <exception cref="ArgumentNullException">The original string is null or white spaces and throwOnError is True</exception>
    /// <exception cref="ArgumentOutOfRangeException">Number of characters to remove are invalid and throwOnError is True</exception>
    public static string RemoveEndCharacters(this string? value, int endCharactersToRemove, bool removeWhitespaces = false, bool throwOnError = false)
    {
        if (value.IsNullOrWhiteSpace())
        {
            if (throwOnError)
            {
                throw new ArgumentNullException("String cannot be null or empty");
            }

            return string.Empty;
        }

        if (removeWhitespaces)
        {
            value = value.Trim();
        }

        if (endCharactersToRemove < 1)
        {
            if (throwOnError)
            {
                throw new ArgumentOutOfRangeException("Please specifiy a character greater than zero!");
            }

            return value;
        }

        if (endCharactersToRemove == value.Length)
        {
            if (throwOnError)
            {
                throw new ArgumentOutOfRangeException("Cannot remove the same amount of total characters in the string");
            }

            return value;
        }


        if (endCharactersToRemove > value.Length)
        {
            if (throwOnError)
            {
                throw new ArgumentOutOfRangeException("Cannot remove the more characters than the total characters in the string");
            }

            return value;
        }

        return value.Remove(value.Length - endCharactersToRemove);
    }

    /// <summary>
    /// Gets all the text in between 2 characters or words
    /// </summary>
    /// <param name="value">The full string</param>
    /// <param name="characterBeginning">Starting point</param>
    /// <param name="characterEnd">Ending point</param>
    /// <param name="throwOnError">Throw exeception on error</param>
    /// <returns>A list of string in between the two characters/words</returns>
    /// <exception cref="ArgumentNullException">If any of the strings are null or white spaces</exception>
    /// <exception cref="ArgumentOutOfRangeException">If there are no characters from any of the splits or the beginning string could not be found</exception>
    public static List<string> GetTextBetweenTwoCharacters(string? value, string? characterBeginning, string? characterEnd, bool throwOnError = false)
    {
        var retVal = new List<string>();

        if (value.IsNullOrWhiteSpace() || characterBeginning.IsNullOrWhiteSpace() || characterEnd.IsNullOrWhiteSpace())
        {
            if (throwOnError)
            {
                throw new ArgumentNullException("All three string arguments must not be null or white spaces!");
            }

            return retVal;
        }

        if (value.Contains(characterBeginning))
        {
            var leftSplit = value.Split(characterBeginning).ToList();

            if (leftSplit.IsNotNullOrEmpty())
            {
                foreach (var firstSplit in leftSplit.NoEmptiesOnly())
                {
                    if (firstSplit.Contains(characterEnd))
                    {
                        var rightSplit = firstSplit.SafeTrim().Split(characterEnd).ToList();

                        if (rightSplit.IsNotNullOrEmpty())
                        {
                            retVal.AddRange(rightSplit.NoEmptiesOnlyTrimAll());
                        }
                    }
                }
            }
            else
            {
                if (throwOnError)
                {
                    throw new ArgumentOutOfRangeException("There are no text after the first character");
                }
            }
        }
        else
        {
            if (throwOnError)
            {
                throw new ArgumentOutOfRangeException("Could not locate the beginning character!");
            }
        }

        return retVal;
    }

    /// <summary>
    /// Checks for inline SQL code that could potentially result in SQL injection
    /// </summary>
    /// <param name="value">String value</param>
    /// <returns>True if there is any SQL code inside</returns>
    public static bool ContainsSQLInjection(this string? value)
    {
        if (value.IsNotNullOrWhiteSpace())
        {
            var invalidSqlCode = GetListOfPotentialSqlInjectionStrings();

            var checkString = value.Replace("'", "''").SafeTrim();

            return invalidSqlCode.Any(x => checkString.IndexOf(x, StringComparison.OrdinalIgnoreCase) > -1);
        }

        return false;
    }

    /// <summary>
    /// Checks if the list has SQL injection
    /// </summary>
    /// <param name="collection">List of strings</param>
    /// <returns>True if the list has any SQL injection</returns>
    public static bool ContainsSQLInjection(this IEnumerable<string>? collection) => collection.IsNotNullAndAny(x => x.ContainsSQLInjection());

    /// <summary>
    /// Gets a list of the array indexes that have SQL injection code in the string
    /// </summary>
    /// <param name="collection">List of strings</param>
    /// <returns>An array that points out which index in the list has SQL injection</returns>
    public static IEnumerable<int> GetCollectionIndexContainingSQLInjection(this IList<string>? collection)
    {
        var retVal = new List<int>();

        if (collection.IsNotNullOrEmpty())
        {
            for (var i = 0; i < collection.Count; i++)
            {
                if (collection[i].ContainsSQLInjection())
                {
                    retVal.Add(i);
                }
            }
        }

        return retVal;
    }

    /// <summary>
    /// Checks every single string in the collection for SQL injection
    /// </summary>
    /// <param name="collection">List of strings</param>
    /// <returns>A dictionary with all the strings accessed on each index</returns>
    public static IDictionary<int, bool> GetDictionaryInformationOfSqlInjection(this IList<string>? collection)
    {
        var retVal = new Dictionary<int, bool>();

        if (collection.IsNotNullOrEmpty())
        {
            for (var i = 0; i < collection.Count; i++)
            {
                retVal.Add(i, collection[i].ContainsSQLInjection());
            }
        }

        return retVal;
    }

    /// <summary>
    /// Checks if all the characters in the string is in upper case
    /// </summary>
    /// <param name="value">String value</param>
    /// <param name="throwOnError">Throws an exception on error</param>
    /// <returns>True if all chracters is in upper case</returns>
    /// <exception cref="ArgumentNullException">If value is null or whitespace and throwOnError is set to True</exception>
    public static bool AllCharactersIsUpper(this string? value, bool throwOnError = false)
    {
        if (value.IsNullOrWhiteSpace())
        {
            if (throwOnError)
            {
                throw new ArgumentNullException("String cannot be empty or full of whitespaces");
            }

            return true;
        }

        return value.ToCharArray().Where(x => char.IsLetter(x)).All(x => char.IsUpper(x));
    }

    /// <summary>
    /// Checks if all the characters in the string is in lower case
    /// </summary>
    /// <param name="value">String value</param>
    /// <param name="throwOnError">Throws an exception on error</param>
    /// <returns>True if all chracters is in lower case</returns>
    /// <exception cref="ArgumentNullException">If value is null or whitespace and throwOnError is set to True</exception>
    public static bool AllCharactersIsLower(this string? value, bool throwOnError = false)
    {
        if (value.IsNullOrWhiteSpace())
        {
            if (throwOnError)
            {
                throw new ArgumentNullException("String cannot be empty or full of whitespaces");
            }

            return true;
        }

        return value.ToCharArray().Where(x => char.IsLetter(x)).All(x => char.IsLower(x));
    }

    /// <summary>
    /// Safely converts an object to string
    /// </summary>
    /// <param name="value">Any data type</param>
    /// <returns>A string version of the object</returns>
    public static string ToSafeString(this object value) => Convert.ToString(value).SafeTrim();

    /// <summary>
    /// Allows nulls to be assessed
    /// </summary>
    /// <param name="value">String</param>
    /// <param name="equals">An object type</param>
    /// <param name="throwOnError">A boolean</param>
    /// <returns>True if both values are null; False if only one of them is null; whatever String.Equals returns</returns>
    public static bool SafeEquals(this string? value, object? equals, bool throwOnError = false) 
    {
        try 
        {
            if (value is null && equals is null)
            {
                return true;
            }
            
            if ((value is null && equals is not null) || (value is not null && equals is null))
            {
                return false;
            }

            return value.Equals(equals);
        }
        catch (Exception)
        {
            if (throwOnError)
            {
                throw;
            }

            return default;
        }
    }

    /// <summary>
    /// Allows nulls to be assessed with a string comparison
    /// </summary>
    /// <param name="value">String</param>
    /// <param name="equals">String</param>
    /// <param name="comparisonType">StringComparison enum</param>
    /// <param name="throwOnError">A boolean</param>
    /// <returns>True if both values are null; False if only one of them is null; whatever String.Equals returns</returns>
    public static bool SafeEquals(this string? value, string? equals, StringComparison comparisonType, bool throwOnError = false)
    {
        try
        {
            if (value is null && equals is null)
            {
                return true;
            }

            if ((value is null && equals is not null) || (value is not null && equals is null))
            {
                return false;
            }

            return value.Equals(equals, comparisonType);
        }
        catch (Exception)
        {
            if (throwOnError)
            {
                throw;
            }

            return default;
        }
    }

    /// <summary>
    /// Returns a list of frequently used T-SQL code and symbols used for SQL Injection
    /// </summary>
    /// <returns>A list of strings</returns>
    public static IEnumerable<string> GetListOfPotentialSqlInjectionStrings() =>
    [
        "--",
        ";--",
        ";",
        "/*",
        "*/",
        "@@",
        "@",
        "%%",
        "%",
        "char",
        "nchar",
        "varchar",
        "nvarchar",
        "alter",
        "begin",
        "cast",
        "create",
        "cursor",
        "declare",
        "delete",
        "drop",
        "end",
        "exec",
        "execute",
        "fetch",
        "insert",
        "kill",
        "select",
        "sys",
        "sysobjects",
        "syscolumns",
        "table",
        "update",
        "like"
    ];

    /// <summary>
    /// Converts a generic type to Base 64 string UTF8
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    /// <param name="value">Generic value</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringUTF8<T>(T? value)
    {
        try
        {
            if (value is not null)
            {
                return typeof(T).IsValueType ? Convert.ToString(value).ConvertToBase64StringUTF8() : JsonSerializer.Serialize(value).ConvertToBase64StringUTF8();
            }

            return string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Converts a generic type to Base 64 string UTF32
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    /// <param name="value">Generic value</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringUTF32<T>(T? value)
    {
        try
        {
            if (value is not null)
            {
                return typeof(T).IsValueType ? Convert.ToString(value).ConvertToBase64StringUTF32() : JsonSerializer.Serialize(value).ConvertToBase64StringUTF32();
            }

            return string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Converts a generic type to Base 64 string ASCII
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    /// <param name="value">Generic value</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringASCII<T>(T? value)
    {
        try
        {
            if (value is not null)
            {
                return typeof(T).IsValueType ? Convert.ToString(value).ConvertToBase64StringASCII() : JsonSerializer.Serialize(value).ConvertToBase64StringASCII();
            }

            return string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Converts a generic type to Base 64 string Unicode
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    /// <param name="value">Generic value</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringUnicode<T>(T? value)
    {
        try
        {
            if (value is not null)
            {
                return typeof(T).IsValueType ? Convert.ToString(value).ConvertToBase64StringUnicode() : JsonSerializer.Serialize(value).ConvertToBase64StringUnicode();
            }

            return string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Converts a generic type to Base 64 string Latin1
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    /// <param name="value">Generic value</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringLatin1<T>(T? value)
    {
        try
        {
            if (value is not null)
            {
                return typeof(T).IsValueType ? Convert.ToString(value).ConvertToBase64StringUTF8() : JsonSerializer.Serialize(value).ConvertToBase64StringUTF8();
            }

            return string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Converts a generic type to Base 64 string Default
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    /// <param name="value">Generic value</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringDefault<T>(T? value)
    {
        try
        {
            if (value is not null)
            {
                return typeof(T).IsValueType ? Convert.ToString(value).ConvertToBase64StringDefault() : JsonSerializer.Serialize(value).ConvertToBase64StringDefault();
            }

            return string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Converts a generic type to Base 64 string BigEndianUnicode
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    /// <param name="value">Generic value</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringBigEndianUnicode<T>(T? value)
    {
        try
        {
            if (value is not null)
            {
                return typeof(T).IsValueType ? Convert.ToString(value).ConvertToBase64StringBigEndianUnicode() : JsonSerializer.Serialize(value).ConvertToBase64StringBigEndianUnicode();
            }

            return string.Empty;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Converts a string to Base 64 string UTF8
    /// </summary>
    /// <param name="value">String argument</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringUTF8(this string? value) => Encoding.UTF8.GetBytes(value.SafeTrim()).ConvertToBase64();

    /// <summary>
    /// Converts a string to Base 64 string UTF32
    /// </summary>
    /// <param name="value">String argument</param>
    /// <returns>Base 64 string</returns>

    public static string ConvertToBase64StringUTF32(this string? value) => Encoding.UTF32.GetBytes(value.SafeTrim()).ConvertToBase64();

    /// <summary>
    /// Converts a string to Base 64 string ASCII
    /// </summary>
    /// <param name="value">String argument</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringASCII(this string? value) => Encoding.ASCII.GetBytes(value.SafeTrim()).ConvertToBase64();

    /// <summary>
    /// Converts a string to Base 64 string Unicode
    /// </summary>
    /// <param name="value">String argument</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringUnicode(this string? value) => Encoding.Unicode.GetBytes(value.SafeTrim()).ConvertToBase64();

    /// <summary>
    /// Converts a string to Base 64 string Latin1
    /// </summary>
    /// <param name="value">String argument</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringLatin1(this string? value) => Encoding.Latin1.GetBytes(value.SafeTrim()).ConvertToBase64();

    /// <summary>
    /// Converts a string to Base 64 string Default
    /// </summary>
    /// <param name="value">String argument</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringDefault(this string? value) => Encoding.Default.GetBytes(value.SafeTrim()).ConvertToBase64();

    /// <summary>
    /// Converts a string to Base 64 string BigEndianUnicode
    /// </summary>
    /// <param name="value">String argument</param>
    /// <returns>Base 64 string</returns>
    public static string ConvertToBase64StringBigEndianUnicode(this string? value) => Encoding.BigEndianUnicode.GetBytes(value.SafeTrim()).ConvertToBase64();

    /// <summary>
    /// Decrypts a Base 64 string 
    /// </summary>
    /// <param name="value">Base 64 String</param>
    /// <returns>The original text</returns>
    public static string RevertBase64StringUTF8(this string? value)
    {
        if (value.IsNullOrEmpty())
        {
            return string.Empty;
        }

        var data = Convert.FromBase64String(value);

        return data.IsNotNullOrEmpty() ? Encoding.UTF8.GetString(data) : string.Empty;
    }

    /// <summary>
    /// Decrypts a Base 64 string 
    /// </summary>
    /// <param name="value">Base 64 String</param>
    /// <returns>The original text</returns>
    public static string RevertBase64StringUTF32(this string? value)
    {
        if (value.IsNullOrEmpty())
        {
            return string.Empty;
        }

        var data = Convert.FromBase64String(value);

        return data.IsNotNullOrEmpty() ? Encoding.UTF32.GetString(data) : string.Empty;
    }

    /// <summary>
    /// Decrypts a Base 64 string 
    /// </summary>
    /// <param name="value">Base 64 String</param>
    /// <returns>The original text</returns>
    public static string RevertBase64StringASCII(this string? value)
    {
        if (value.IsNullOrEmpty())
        {
            return string.Empty;
        }

        var data = Convert.FromBase64String(value);

        return data.IsNotNullOrEmpty() ? Encoding.ASCII.GetString(data) : string.Empty;
    }

    /// <summary>
    /// Decrypts a Base 64 string 
    /// </summary>
    /// <param name="value">Base 64 String</param>
    /// <returns>The original text</returns>
    public static string RevertBase64StringUnicode(this string? value)
    {
        if (value.IsNullOrEmpty())
        {
            return string.Empty;
        }

        var data = Convert.FromBase64String(value);

        return data.IsNotNullOrEmpty() ? Encoding.Unicode.GetString(data) : string.Empty;
    }

    /// <summary>
    /// Decrypts a Base 64 string 
    /// </summary>
    /// <param name="value">Base 64 String</param>
    /// <returns>The original text</returns>
    public static string RevertBase64StringLatin1(this string? value)
    {
        if (value.IsNullOrEmpty())
        {
            return string.Empty;
        }

        var data = Convert.FromBase64String(value);

        return data.IsNotNullOrEmpty() ? Encoding.Latin1.GetString(data) : string.Empty;
    }

    /// <summary>
    /// Decrypts a Base 64 string 
    /// </summary>
    /// <param name="value">Base 64 String</param>
    /// <returns>The original text</returns>
    public static string RevertBase64StringDefault(this string? value)
    {
        if (value.IsNullOrEmpty())
        {
            return string.Empty;
        }
        
        var data = Convert.FromBase64String(value);

        return data.IsNotNullOrEmpty() ? Encoding.Default.GetString(data) : string.Empty;
    }
}