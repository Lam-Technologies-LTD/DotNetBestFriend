using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace DotNetBestFriend;

public static class ListHelpers
{
    #region IEnumerable...
    #region LINQ...
    /// <summary>
    /// Checks if a collection is null or empty
    /// </summary>
    /// <typeparam name="T">The collection's object type</typeparam>
    /// <param name="collection">The collection type</param>
    /// <returns>True if the collection's instance is null or has 0 count</returns>
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? collection) => collection is null || !collection.Any();

    /// <summary>
    /// Checks if a collection is not null and is filled
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="collection">The collection type</param>
    /// <returns>True if the collection's instance is not null and has a count above 0</returns>
    
    public static bool IsNotNullOrEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? collection) => collection != null && collection.Any();

    /// <summary>
    /// Allows the safe use of the Any() method in case of a null instance
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="collection">The collection type</param>
    /// <param name="predicate">Same as a normal Any()</param>
    public static bool IsNotNullAndAny<T>([NotNullWhen(true)] this IEnumerable<T>? collection, Func<T, bool> predicate) => collection != null && collection.Any(predicate);

    /// <summary>
    /// Allows the safe use of the Contains() method in case of a null instance
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="collection">The collection type</param>
    /// <param name="predicate">Same as a normal Contains()</param>
    public static bool IsNotNullAndContains<T>([NotNullWhen(true)] this IEnumerable<T>? collection, T item) => collection != null && collection.Contains(item);

    /// <summary>
    /// Allows the safe use of the All() method in case of a null instance
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="collection">The collection type</param>
    /// <param name="predicate">Same as a normal All()</param>
    public static bool IsNotNullAndAll<T>([NotNullWhen(true)] this IEnumerable<T>? collection, Func<T, bool> predicate) => collection != null && collection.All(predicate);

    /// <summary>
    /// Allows the safe use of the Except() method in case of a null instance
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="collection">The collection type</param>
    /// <param name="predicate">Same as a normal Except()</param>
    public static IEnumerable<T> IsNotNullAndExcept<T>(this IEnumerable<T>? collection, IEnumerable<T>? second)
    {
        var collectionCopy = collection ?? Array.Empty<T>();

        var collectionSecondCopy = second ?? Array.Empty<T>();

        return collectionCopy.Except(collectionSecondCopy);
    }

    /// <summary>
    /// Allows the safe use of the Intersect() method in case of a null instance
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="collection">The collection type</param>
    /// <param name="predicate">Same as a normal Intersect()</param>
    public static IEnumerable<T> IsNotNullAndIntersect<T>(this IEnumerable<T>? collection, IEnumerable<T>? second)
    {
        var collectionCopy = collection ?? Array.Empty<T>();

        var collectionSecondCopy = second ?? Array.Empty<T>();

        return collectionCopy.Intersect(collectionSecondCopy);
    }

    /// <summary>
    /// Safely returns a list of object
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <returns>A new list if null</returns>
    public static List<T> SafeToList<T>(this IEnumerable<T>? source) => source.IsNotNullOrEmpty() ? source.ToList() : new List<T>();

    /// <summary>
    /// Safely interates through the list
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="action">The action to perform during each iteration</param>
    public static void SafeForEach<T>(this IEnumerable<T>? source, Action<T> action) => source.SafeToList().ForEach(action);

    /// <summary>
    /// Safely filters a list
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="predicate">Where function</param>
    /// <returns>A filtered list</returns>
    public static IEnumerable<T> SafeWhere<T>(this IEnumerable<T>? source, Func<T, bool> predicate) => source.IsNotNullOrEmpty() ? source.Where(predicate) : Array.Empty<T>();

    /// <summary>
    /// Safely returns the first element based on the predicate
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="predicate">Where function</param>
    /// <returns>An object if found and a null if not found</returns>
    public static T? SafeFirstOrDefault<T>(this IEnumerable<T>? source, Func<T, bool> predicate) => source.IsNotNullOrEmpty() ? source.FirstOrDefault(predicate) : default;

    /// <summary>
    /// Safely returns the first element based on the predicate
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <returns>An object if found and a null if not found</returns>
    public static T? SafeFirstOrDefault<T>(this IEnumerable<T>? source) => source.IsNotNullOrEmpty() ? source.FirstOrDefault() : default;

    /// <summary>
    /// Safely returns the last element based on the predicate
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="predicate">Where function</param>
    /// <returns>An object if found and a null if not found</returns>
    public static T? SafeLastOrDefault<T>(this IEnumerable<T>? source, Func<T, bool> predicate) => source.IsNotNullOrEmpty() ? source.FirstOrDefault(predicate) : default;

    /// <summary>
    /// Safely returns the last element based on the predicate
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <returns>An object if found and a null if not found</returns>
    public static T? SafeLastOrDefault<T>(this IEnumerable<T>? source) => source.IsNotNullOrEmpty() ? source.FirstOrDefault() : default;

    /// <summary>
    /// Orders an list
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <typeparam name="TKey">Ordering type</typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="keySelector">Sorting delegate</param>
    /// <returns>An ordered list</returns>
    public static IOrderedEnumerable<T> SafeOrderBy<T, TKey>(this IEnumerable<T>? source, Func<T, TKey> keySelector) => source.IsNotNullOrEmpty() ? source.OrderBy(keySelector) : Array.Empty<T>().OrderBy(keySelector);

    /// <summary>
    /// Orders an list by descending
    /// </summary>
    /// <typeparam name="TKey">Ordering type</typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="keySelector">Sorting delegate</param>
    /// <returns>An ordered list</returns>
    public static IOrderedEnumerable<T> SafeOrderByDescending<T, TKey>(this IEnumerable<T>? source, Func<T, TKey> keySelector) => source.IsNotNullOrEmpty() ? source.OrderByDescending(keySelector) : Array.Empty<T>().OrderByDescending(keySelector);

    /// <summary>
    /// Safely adds an item to a list
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="element">Item to add at the start of the list</param>
    /// <returns>A list with the new element inside</returns>
    public static IEnumerable<T> SafePrepend<T>(this IEnumerable<T>? source, T element) => source.IsNotNullOrEmpty() ? source.Prepend(element) : new List<T> { element };

    /// <summary>
    /// Safely reserves the list
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <returns>A reversed list</returns>
    public static IEnumerable<T> SafeReverse<T>(this IEnumerable<T>? source) => source.IsNotNullOrEmpty() ? source.Reverse() : Array.Empty<T>();

    /// <summary>
    /// Safely selects a new list
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <typeparam name="TResult">Returning generic type</typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="selector">Select method from LINQ</param>
    /// <returns>A list with new results</returns>
    public static IEnumerable<TResult> SafeSelect<T, TResult>(this IEnumerable<T>? source, Func<T, TResult> selector) => source.IsNotNullOrEmpty() ? source.Select(selector) : Array.Empty<TResult>();

    /// <summary>
    /// Safely selects a single entity
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <returns>A single entity or null if not found</returns>
    public static T? SafeSingleOrDefault<T>(this IEnumerable<T>? source) => source.IsNotNullOrEmpty() ? source.SingleOrDefault() : default;

    /// <summary>
    /// Safely selects a single entity
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="predicate">SingleOrDefault predicate function</param>
    /// <returns>A single entity or null if not found</returns>
    public static T? SafeSingleOrDefault<T>(this IEnumerable<T>? source, Func<T, bool> predicate) => source.IsNotNullOrEmpty() ? source.SingleOrDefault(predicate) : default;
    #endregion

    #region String Lists...
    /// <summary>
    /// Filters out all the nulls, empty and white spaced strings
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// <returns>A list of strings without any blank entries</returns>
    public static IEnumerable<string> NoEmptiesOnly(this IEnumerable<string>? value) => value.IsNotNullOrEmpty() ? value.Where(x => x.IsNotNullOrWhiteSpace()) : Array.Empty<string>();

    // <summary>
    /// Filters out all the nulls, empty and white spaced strings and then trims the remaining entries
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// <returns>A list of trimmed strings without any blank entries</returns>
    public static IEnumerable<string> NoEmptiesOnlyTrimAll(this IEnumerable<string>? value) => value.NoEmptiesOnly().Select(x => x.SafeTrim());

    /// <summary>
    /// Picks the first entry that isn't blank
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// <returns>The first string of the list that isn't blank</returns>
    public static string FirstNoEmptiesOnly(this IEnumerable<string>? value) => value.NoEmptiesOnly().FirstOrDefault() ?? string.Empty;

    /// <summary>
    /// Picks the last entry that isn't blank
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// <returns>The last string of the list that isn't blank</returns>
    public static string LastNoEmptiesOnly(this IEnumerable<string>? value) => value.NoEmptiesOnly().LastOrDefault() ?? string.Empty;

    /// <summary>
    /// Picks the first entry that isn't blank
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// <param name="predicate">Normal predicate function for FirstOrDefault()</param>
    /// <returns>The first string of the list that isn't blank</returns>
    public static string FirstNoEmptiesOnly(this IEnumerable<string>? value, Func<string, bool> predicate) => value.NoEmptiesOnly().FirstOrDefault(predicate) ?? string.Empty;

    /// <summary>
    /// Picks the last entry that isn't blank
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// <param name="predicate">Normal predicate function for LastOrDefault()</param>
    /// <returns>The last string of the list that isn't blank</returns>
    public static string LastNoEmptiesOnly(this IEnumerable<string>? value, Func<string, bool> predicate) => value.NoEmptiesOnly().LastOrDefault(predicate) ?? string.Empty;

    /// <summary>
    /// Picks the first entry that isn't blank trimmed
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// <returns>The first string of the list that isn't blank with the whitespaces on both ends removed</returns>
    public static string FirstNoEmptiesOnlyTrimmed(this IEnumerable<string>? value) => value.FirstNoEmptiesOnly().SafeTrim();

    /// <summary>
    /// Picks the last entry that isn't blank trimmed
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// <returns>The last string of the list that isn't blank with the whitespaces on both ends removed</returns>
    public static string LastNoEmptiesOnlyTrimmed(this IEnumerable<string>? value) => value.LastNoEmptiesOnly().SafeTrim();

    /// <summary>
    /// Picks the first entry that isn't blank trimmed
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// /// <param name="predicate">Normal predicate function for FirstOrDefault()</param>
    /// <returns>The first string of the list that isn't blank with the whitespaces on both ends removed</returns>
    public static string FirstNoEmptiesOnlyTrimmed(this IEnumerable<string>? value, Func<string, bool> predicate) => value.FirstNoEmptiesOnly(predicate).SafeTrim();

    /// <summary>
    /// Picks the last entry that isn't blank trimmed
    /// </summary>
    /// <param name="value">A collection of strings</param>
    /// /// <param name="predicate">Normal predicate function for LastOrDefault()</param>
    /// <returns>The last string of the list that isn't blank with the whitespaces on both ends removed</returns>
    public static string LastNoEmptiesOnlyTrimmed(this IEnumerable<string>? value, Func<string, bool> predicate) => value.LastNoEmptiesOnly(predicate).SafeTrim();
    #endregion

    #region Misc...
    /// <summary>
    /// Creates a paged content of a list
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="source">The collection type</param>
    /// <param name="pageSize">The size of each page</param>
    /// <returns>An List of a List</returns>
    public static IEnumerable<IEnumerable<T>> ConvertListToPage<T>(this IEnumerable<T>? source, int pageSize)
    {
        if (source.IsNullOrEmpty())
        {
            throw new ArgumentNullException("List cannot be empty!");
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException("Page size cannot be lower than 1!");
        }

        using (var enumerator = source.GetEnumerator())
        {
            var currentPage = new List<T>(pageSize)
            {
                enumerator.Current
            };

            while (currentPage.Count < pageSize && enumerator.MoveNext())
            {
                currentPage.Add(enumerator.Current);
            }

            yield return new ReadOnlyCollection<T>(currentPage);
        }
    }

    /// <summary>
    /// Quickly converts a list into a DataTable to be used in a SQL stored procedure table parameter
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <param name="columnName">The name of the column from the table parameter</param>
    /// <returns>A DataTable with a single column and rows filled with the generic type</returns>
    public static DataTable ToSProcTableParam<T>(this IEnumerable<T>? source, string columnName = "Id")
    {
        var retVal = new DataTable();

        retVal.Columns.Add(columnName, typeof(T));

        var genericType = typeof(T);

        if ((genericType.IsValueType || genericType == typeof(string)) && source.IsNotNullOrEmpty())
        {
            foreach (var item in source)
            {
                retVal.Rows.Add(item);
            }
        }

        return retVal;
    }

    /// <summary>
    /// Gets a random element out of the list
    /// </summary>
    /// <typeparam name="T">Generic Type</typeparam>
    /// <param name="source">Generic List</param>
    /// <returns>A single entity or null if not found</returns>
    public static T? GetRandom<T>(this IEnumerable<T>? source)
    {
        var retVal = default(T?);

        if (source.IsNotNullOrEmpty())
        {
            var arr = source.ToArray();

            var initialCount = source.Count() - 1;

            var random = new Random();

            for (var i = 0; i < initialCount; i++)
            {
                var idx = random.Next(0, arr.Count());

                retVal = arr[idx];

                if (retVal is not null)
                {
                    break;
                }
            }
        }

        return retVal;
    }
    #endregion

    #region SafeSum...
    /// <summary>
    /// Checks if an instance is null before adding up all the numbers in the list
    /// </summary>
    /// <param name="source">A collection of integers</param>
    /// <returns>An interger that is sum of everything in the list</returns>
    public static int SafeSum(this IEnumerable<int>? source) => source.IsNotNullOrEmpty() ? source.Sum() : default;

    /// <summary>
    /// Checks if an instance is null before adding up all the numbers in the list
    /// </summary>
    /// <param name="source">A collection of 64-bit integers</param>
    /// <returns>A 64-bit that is sum of everything in the list</returns>
    public static long SafeSum(this IEnumerable<long>? source) => source.IsNotNullOrEmpty() ? source.Sum() : default;

    /// <summary>
    /// Checks if an instance is null before adding up all the numbers in the list
    /// </summary>
    /// <param name="source">A collection of decimal numbers</param>
    /// <returns>A decimal that is sum of everything in the list</returns>
    public static decimal SafeSum(this IEnumerable<decimal>? source) => source.IsNotNullOrEmpty() ? source.Sum() : default;

    /// <summary>
    /// Checks if an instance is null before adding up all the numbers in the list
    /// </summary>
    /// <param name="source">A collection of floating point numbers</param>
    /// <returns>A float that is sum of everything in the list</returns>
    public static float SafeSum(this IEnumerable<float>? source) => source.IsNotNullOrEmpty() ? source.Sum() : default;

    /// <summary>
    /// Checks if an instance is null before adding up all the numbers in the list
    /// </summary>
    /// <param name="source">A collection of double precision number</param>
    /// <returns>A double that is sum of everything in the list</returns>
    public static double SafeSum(this IEnumerable<double>? source) => source.IsNotNullOrEmpty() ? source.Sum() : default;
    #endregion

    #region SafeMin...
    /// <summary>
    /// Checks if an instance is null before choosing the lowest number in the list
    /// </summary>
    /// <param name="source">A collection of integers</param>
    /// <returns>The lowest value</returns>
    public static int SafeMin(this IEnumerable<int>? source) => source.IsNotNullOrEmpty() ? source.Sum() : default;

    /// <summary>
    /// Checks if an instance is null before choosing the lowest number in the list
    /// </summary>
    /// <param name="source">A collection of 64-bit integers</param>
    /// <returns>The lowest value</returns>
    public static long SafeMin(this IEnumerable<long>? source) => source.IsNotNullOrEmpty() ? source.Min() : default;

    /// <summary>
    /// Checks if an instance is null before choosing the lowest number in the list
    /// </summary>
    /// <param name="source">A collection of decimal numbers</param>
    /// <returns>The lowest value</returns>
    public static decimal SafeMin(this IEnumerable<decimal>? source) => source.IsNotNullOrEmpty() ? source.Min() : default;

    /// <summary>
    /// Checks if an instance is null before choosing the lowest number in the list
    /// </summary>
    /// <param name="source">A collection of floating point numbers</param>
    /// <returns>The lowest value</returns>
    public static float SafeMin(this IEnumerable<float>? source) => source.IsNotNullOrEmpty() ? source.Min() : default;

    /// <summary>
    /// Checks if an instance is null before choosing the lowest number in the list
    /// </summary>
    /// <param name="source">A collection of double precision number</param>
    /// <returns>The lowest value</returns>
    public static double SafeMin(this IEnumerable<double>? source) => source.IsNotNullOrEmpty() ? source.Min() : default;
    #endregion

    #region SafeMax...
    /// <summary>
    /// Checks if an instance is null before choosing the highest number in the list
    /// </summary>
    /// <param name="source">A collection of integers</param>
    /// <returns>The highest value</returns>
    public static int SafeMax(this IEnumerable<int>? source) => source.IsNotNullOrEmpty() ? source.Max() : default;

    /// <summary>
    /// Checks if an instance is null before choosing the highest number in the list
    /// </summary>
    /// <param name="source">A collection of 64-bit integers</param>
    /// <returns>The highest value</returns>
    public static long SafeMax(this IEnumerable<long>? source) => source.IsNotNullOrEmpty() ? source.Max() : default;

    /// <summary>
    /// Checks if an instance is null before choosing the highest number in the list
    /// </summary>
    /// <param name="source">A collection of decimal numbers</param>
    /// <returns>The highest value</returns>
    public static decimal SafeMax(this IEnumerable<decimal>? source) => source.IsNotNullOrEmpty() ? source.Max() : default;

    /// <summary>
    /// Checks if an instance is null before choosing the highest number in the list
    /// </summary>
    /// <param name="source">A collection of floating point numbers</param>
    /// <returns>The highest value</returns>
    public static float SafeMax(this IEnumerable<float>? source) => source.IsNotNullOrEmpty() ? source.Max() : default;

    /// <summary>
    /// Checks if an instance is null before choosing the highest number in the list
    /// </summary>
    /// <param name="source">A collection of double precision number</param>
    /// <returns>The highest value</returns>
    public static double SafeMax(this IEnumerable<double>? source) => source.IsNotNullOrEmpty() ? source.Max() : default;
    #endregion
    #endregion

    #region ICollection...
    /// <summary>
    /// Checks if the instance is null before adding
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="source">The collection object</param>
    /// <param name="item">The item to add to the collection</param>
    /// <returns>True when added. False when an exception has been caight</returns>
    public static void SafeAdd<T>(this ICollection<T>? source, T item)
    {
        try
        {
            if (source is null)
            {
                source = new Collection<T>
                {
                    item
                };
            }
            else
            {
                if (!source.Contains(item))
                {
                    source.Add(item);
                }
            }
        }
        catch (Exception)
        {

        }
    }

    /// <summary>
    /// Checks if the instance is null before removing
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    /// <param name="source">The collection object</param>
    /// <param name="item">The item to remove from the collection</param>
    public static void SafeRemove<T>(this ICollection<T>? source, T item)
    {
        try
        {
            if (source.IsNotNullAndContains(item))
            {
                source.Remove(item);
            }
        }
        catch (Exception)
        {

        }
    }
    #endregion

    #region IList...
    /// <summary>Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.</summary>
    /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
    /// <returns>The index of <paramref name="item" /> if found in the list; otherwise, -1.</returns>
    public static int SafeIndexOf<T>(this IList<T> source, T item)
    {
        try
        {
            return source.IsNotNullOrEmpty() ? source.IndexOf(item) : -1;
        }
        catch (Exception)
        {
            return -1;
        }
    }

    /// <summary>Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.</summary>
    /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
    /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
    public static void SafeInsert<T>(this IList<T>? source, int index, T item)
    {
        try
        {
            if (source is null)
            {
                source =
                [
                    item
                ];
            }
            else
            {
                if (index < default(int) || !source.Any()) // If the index is invalid or there's nothing in the list
                {
                    source.Insert(0, item); // Add it at the top
                }
                else if (index > source.Count - 1) // If the index goes beyond the amount of the items in the list
                {
                    source.Add(item); // Add it to the bottom
                }
                else
                {
                    source.Insert(index, item); // Add it to the correct index of the list
                }
            }
        }
        catch (Exception)
        {

        }
    }

    /// <summary>Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.</summary>
    /// <param name="index">The zero-based index of the item to remove.</param>
    public static void SafeRemoveAt<T>(this IList<T>? source, int index)
    {
        try
        {
            if (source.IsNotNullOrEmpty() && index > -1 && index < source.Count)
            {
                source.RemoveAt(index);
            }
        }
        catch (Exception)
        {

        }
    }
    #endregion
}