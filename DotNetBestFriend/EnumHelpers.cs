using System.ComponentModel;

namespace DotNetBestFriend;

public static class EnumHelpers
{
    #region Get All...
    /// <summary>
    /// Get all of the enum number values into a list
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <returns>A List of ints with all the possible numbers for that enum</returns>
    public static IEnumerable<int> GetAllEnumValues<Enum>() => System.Enum.GetValues(typeof(Enum)).Cast<int>().ToList();

    /// <summary>
    /// Gets all the enum names
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <returns>A list of all names</returns>
    public static IEnumerable<string> GetAllNames<Enum>() => System.Enum.GetNames(typeof(Enum));

    /// <summary>
    /// Gets all the descriptions into a list
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <param name="ignore">Numbers to ignore</param>
    /// <returns>A list of strings</returns>
    public static IEnumerable<string> GetAllDescriptions<Enum>(IEnumerable<int>? ignore = null)
    {
        var retVal = new List<string>();

        var enumType = typeof(Enum);

        foreach (var name in GetAllNames<Enum>())
        {
            if (ignore.IsNotNullAndContains((int)System.Enum.Parse(enumType, name)))
            {
                continue;
            }

            var descriptionAttribute = FindDescriptionAttribute<Enum>(name);

            if (descriptionAttribute.IsNullOrEmpty())
            {
                continue;
            }

            retVal.Add(descriptionAttribute[0].Description);
        }

        return retVal;
    }
    #endregion

    #region Enum Numbers...
    /// <summary>
    /// Gets the highest number of an enum
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <returns>The highest int of the collection</returns>
    public static int GetHighestNumber<Enum>() => GetAllEnumValues<Enum>().Max();

    /// <summary>
    /// Gets the lowest number of the enum
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <param name="excludeZero">Remove 0 from the list if 0 represents a default value</param>
    /// <returns>The lowest int of the collection</returns>
    public static int GetLowestNumber<Enum>(bool excludeZero = false)
    {
        var enumNumbers = GetAllEnumValues<Enum>().ToList();

        return excludeZero ? enumNumbers.Where(x => x != default).Min() : enumNumbers.Min();
    }

    /// <summary>
    /// Checks if a number is in the enum range
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <param name="value">32-bit signed interger</param>
    /// <returns>True if not in range</returns>
    public static bool IsNotInRangeOfEnum<Enum>(this int value) => !GetAllEnumValues<Enum>().IsNotNullAndContains(value);

    /// <summary>
    /// Checks if the int value is inside of the list of enum
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <param name="value">32-bit signed int value</param>
    /// <returns>True if the number is in the enum</returns>
    public static bool IsInRangeOfEnum<Enum>(this int value) => GetAllEnumValues<Enum>().IsNotNullAndContains(value);

    /// <summary>
    /// Converts a list of ints into a list of enums
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    /// <param name="enumVals">List of ints</param>
    /// <returns>A list of enums</returns>
    public static IEnumerable<T> ConvertToListOfEnums<T>(this IEnumerable<int>? enumVals)
    {
        try
        {
            if (enumVals.IsNotNullOrEmpty())
            {
                var enumType = typeof(T);

                if (enumType.IsEnum)
                {
                    return GetAllEnumValues<T>().Intersect(enumVals).Select(x => (T)Enum.ToObject(enumType, x));
                }
            }

            return Array.Empty<T>();
        }
        catch (Exception)
        {
            return Array.Empty<T>();
        }
    }

    /// <summary>
    /// Converts a string ints into a list of enums
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    /// <param name="value">Delimited string</param>
    /// <param name="seperator">Delimiter</param>
    /// <returns>A list of enums</returns>
    public static IEnumerable<T>? ConvertDelimittedIntStringToListOfEnums<T>(this string value, string seperator)
    {
        try
        {
            if (value.IsNotNullOrWhiteSpace() && seperator.IsNotNullOrWhiteSpace())
            {
                var enumType = typeof(T);

                if (enumType.IsEnum)
                {
                    var listOfInts = value.Split(seperator).Where(x => int.TryParse(x, out var val)).Select(x => int.Parse(x));

                    if (listOfInts.IsNotNullOrEmpty())
                    {
                        return listOfInts.ConvertToListOfEnums<T>();
                    }
                }
            }

            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Converts a string ints into a list of enums
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    /// <param name="value">Delimited string</param>
    /// <param name="seperator">Delimiter</param>
    /// <returns>A list of enums</returns>
    public static IEnumerable<T>? ConvertDelimittedIntStringToListOfEnums<T>(this string value, char seperator)
    {
        try
        {
            if (value.IsNotNullOrWhiteSpace())
            {
                var enumType = typeof(T);

                if (enumType.IsEnum)
                {
                    var listOfInts = value.Split(seperator).Where(x => int.TryParse(x, out var val)).Select(x => int.Parse(x));

                    if (listOfInts.IsNotNullOrEmpty())
                    {
                        return listOfInts.ConvertToListOfEnums<T>();
                    }
                }
            }

            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Converts a list of valid enum names back into the enum values
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    /// <param name="strings">List of strings</param>
    /// <returns>List of enums</returns>
    public static IEnumerable<T> ConvertListOfNamesToListOfEnums<T>(this IEnumerable<string> enumNames)
    {
        try
        {
            if (enumNames.IsNotNullOrEmpty())
            {
                var enumType = typeof(T);

                if (enumType.IsEnum)
                {
                    return GetDictionaryOfEnumValueAndName<T>().Where(x => enumNames.Contains(x.Value)).Select(x => x.Key);
                }
            }

            return Array.Empty<T>();
        }
        catch
        {
            return Array.Empty<T>();
        }
    }

    /// <summary>
    /// Gets all the enum value based on their descriptions
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    /// <param name="descriptions">List of strings</param>
    /// <returns>List of enums</returns>
    public static IEnumerable<T> ConvertListOfDescriptionsToListOfEnums<T>(this IEnumerable<string>? descriptions)
    {
        try
        {
            if (descriptions.IsNotNullOrEmpty())
            {
                var enumType = typeof(T);

                if (enumType.IsEnum)
                {
                    return GetDictionaryOfEnumValueAndDescription<T>().Where(x => descriptions.Contains(x.Value)).Select(x => x.Key);
                }
            }

            return Array.Empty<T>();
        }
        catch (Exception)
        {
            return Array.Empty<T>();
        }
    }
    #endregion

    #region Description Attribute...
    /// <summary>
    /// Gets all the description attributes for the enum value
    /// </summary>
    /// <param name="value">Enum value</param>
    /// <returns>A DescriptionAttribute array</returns>
    public static DescriptionAttribute[] FindDescriptionAttribute(Enum value) => (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false) ?? Array.Empty<DescriptionAttribute>();

    /// <summary>
    /// Gets all the description attributes for the enum value of a type
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <param name="name">Name of enum value</param>
    /// <returns>A DescriptionAttribute array</returns>
    public static DescriptionAttribute[] FindDescriptionAttribute<Enum>(string name) => (DescriptionAttribute[])typeof(Enum).GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), true) ?? Array.Empty<DescriptionAttribute>();

    /// <summary>
    /// Gets the first description attribute of the enum value
    /// </summary>
    /// <param name="value">Enum value</param>
    /// <returns>The string inside of the description attribute if found. Otherwise the name of the enum with the capital letter seperated</returns>
    public static string GetDescription(this Enum value)
    {
        var attributes = FindDescriptionAttribute(value);

        return attributes.IsNotNullOrEmpty() ? attributes[0].Description : value.ToString().SeperateCapitalLetters();
    }

    /// <summary>
    /// Checks if the enum has a description attribute
    /// </summary>
    /// <param name="value">Enum value</param>
    /// <returns>True if the enum has a description attribute</returns>
    public static bool HasDescriptionAttribute(this Enum value) => FindDescriptionAttribute(value).IsNotNullOrEmpty();
    #endregion

    #region Dictionary...
    /// <summary>
    /// Gets a dictionary of enum value and it's corresponding name
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    /// <param name="ignore">Numbers to ignore</param>
    /// <returns>A dictionary of enum value and string</returns>
    public static IDictionary<T, string> GetDictionaryOfEnumValueAndName<T>(IEnumerable<int>? ignore = null)
    {
        var retVal = new Dictionary<T, string>();

        var enumType = typeof(T);

        if (enumType.IsEnum)
        {
            foreach (var name in GetAllNames<T>())
            {
                var enumNumber = (int)Enum.Parse(enumType, name);

                if (ignore.IsNotNullAndContains(enumNumber))
                {
                    continue;
                }

                retVal.Add((T)Enum.ToObject(enumType, enumNumber), name);
            }
        }

        return retVal;
    }

    /// <summary>
    /// Gets a dictionary of enum value and it's corresponding description
    /// </summary>
    /// <typeparam name="T">Enum type</typeparam>
    /// <param name="ignore">Numbers to ignore</param>
    /// <returns>A dictionary of enum value and string</returns>
    public static IDictionary<T, string> GetDictionaryOfEnumValueAndDescription<T>(IEnumerable<int>? ignore = null)
    {
        var retVal = new Dictionary<T, string>();

        var enumType = typeof(T);

        if (enumType.IsEnum)
        {
            foreach (var name in GetAllNames<T>())
            {
                var enumNumber = (int)System.Enum.Parse(enumType, name);

                if (ignore.IsNotNullAndContains(enumNumber))
                {
                    continue;
                }

                var descriptionAttribute = FindDescriptionAttribute<Enum>(name);

                retVal.Add((T)Enum.ToObject(enumType, enumNumber), descriptionAttribute.IsNotNullOrEmpty() ? descriptionAttribute[0].Description : string.Empty);
            }
        }

        return retVal;
    }

    /// <summary>
    /// Breaks down the enum's int value and description
    /// </summary>
    /// <returns>A dictionary of the enum int values as the key and the description attribute (or name if it doesn't have one) as the value</returns>
    public static IDictionary<int, string> GetDictionaryOfEnumAndDescription<Enum>(IEnumerable<int>? ignore = null)
    {
        var retVal = new Dictionary<int, string>();

        var enumType = typeof(Enum);

        foreach (var name in GetAllNames<Enum>())
        {
            var enumNumber = (int)System.Enum.Parse(enumType, name);

            if (ignore.IsNotNullAndContains(enumNumber))
            {
                continue;
            }

            var descriptionAttribute = FindDescriptionAttribute<Enum>(name);

            retVal.Add(enumNumber, descriptionAttribute.IsNotNullOrEmpty() ? descriptionAttribute[0].Description : name.SeperateCapitalLetters());
        }

        return retVal;
    }

    /// <summary>
    /// Gets a dictionary of the enum
    /// </summary>
    /// <typeparam name="Enum">The enum type</typeparam>
    /// <param name="ignore">A list of ints to omit from the dictionary</param>
    /// <returns>A dictionary with int as the key and string as the value</returns>
    public static IDictionary<int, string> GetDictionaryOfEnumAndName<Enum>(IEnumerable<int>? ignore = null)
    {
        var retVal = new Dictionary<int, string>();

        var enumType = typeof(Enum);

        foreach (var name in GetAllNames<Enum>())
        {
            var enumNumber = (int)System.Enum.Parse(enumType, name);

            if (ignore.IsNotNullAndContains(enumNumber))
            {
                continue;
            }

            retVal.Add(enumNumber, name);
        }

        return retVal;
    }

    /// <summary>
    /// Gets a dictionary of the enum
    /// </summary>
    /// <typeparam name="Enum">The enum type</typeparam>
    /// <param name="ignore">A list of ints to omit from the dictionary</param>
    /// <returns>A dictionary with string as the key and string as the value</returns>
    public static IDictionary<string, string> GetDictionaryOfNameAndDescription<Enum>(IEnumerable<int>? ignore = null)
    {
        var retVal = new Dictionary<string, string>();

        foreach (var name in GetAllNames<Enum>())
        {
            var enumNumber = (int)System.Enum.Parse(typeof(Enum), name);

            if (ignore.IsNotNullAndContains(enumNumber))
            {
                continue;
            }

            var descriptionAttribute = FindDescriptionAttribute<Enum>(name);

            retVal.Add(name, descriptionAttribute.IsNotNullOrEmpty() ? descriptionAttribute[0].Description : string.Empty);
        }

        return retVal;
    }
    #endregion

    #region Comma Seperated String...
    /// <summary>
    /// Gets all enum values into a single comma seperated string
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <returns>A comma seperated string</returns>
    public static string AllValuesAsCommaSeperatedString<Enum>() => string.Join(", ", GetAllEnumValues<Enum>());

    /// <summary>
    /// Gets all the descriptions in the enum (that exists) into a comma seperated string
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <returns>A comma seperated string</returns>
    public static string AllDescriptionsAsCommaSeperatedString<Enum>() => string.Join(", ", GetAllDescriptions<Enum>());

    /// <summary>
    /// Gets all the names into a comma seperated string
    /// </summary>
    /// <typeparam name="Enum">Enum type</typeparam>
    /// <returns>A comma seperated string</returns>
    public static string AllNamesAsCommaSeperatedString<Enum>() => string.Join(", ", GetAllNames<Enum>());
    #endregion
}