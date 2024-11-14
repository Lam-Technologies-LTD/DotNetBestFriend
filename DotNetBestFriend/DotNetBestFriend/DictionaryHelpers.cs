using System.Collections.Generic;
using System.Linq;

namespace DotNetBestFriend;

public static class DictionaryHelpers
{
    #region IDictionary
    /// <summary>
    /// Checks if a key exists and is not the default value
    /// </summary>
    /// <typeparam name="TKey">Key data type</typeparam>
    /// <typeparam name="TValue">Value data type</typeparam>
    /// <param name="keyValuePairs">IDictionary object</param>
    /// <param name="key">Key value</param>
    /// <returns>True if the TKey exists in the dictionary and the value is the default value of TValue</returns>
    public static bool ContainsKeyAndNotDefault<TKey, TValue>(this IDictionary<TKey, TValue>? keyValuePairs, TKey key) =>
        keyValuePairs is not null && keyValuePairs.ContainsKey(key) && !keyValuePairs[key].Equals(default(TValue));

    /// <summary>
    /// Gets a value from the dictionary regardless of null collection object
    /// </summary>
    /// <typeparam name="TKey">Key data type</typeparam>
    /// <typeparam name="TValue">Value data type</typeparam>
    /// <param name="keyValuePairs">IDictionary object</param>
    /// <param name="key">Key value</param>
    /// <returns>The correct value if found, but a default TValue if not found</returns>
    public static TValue SafeGetValue<TKey, TValue>(this IDictionary<TKey, TValue>? keyValuePairs, TKey key)
    {
        try
        {
            return keyValuePairs is not null ? keyValuePairs[key] : default;
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Safely updates the value of a key in case of a null dictionary object
    /// </summary>
    /// <typeparam name="TKey">Key data type</typeparam>
    /// <typeparam name="TValue">Value data type</typeparam>
    /// <param name="keyValuePairs">IDictionary object</param>
    /// <param name="key">Key value</param>
    /// <param name="value">Value of the key</param>
    /// <returns>True upon successful adding</returns>
    public static bool SafeUpdateValue<TKey, TValue>(this IDictionary<TKey, TValue>? keyValuePairs, TKey key, TValue value)
    {
        try
        {
            if (keyValuePairs is null)
            {
                keyValuePairs = new Dictionary<TKey, TValue>();
            }

            if (keyValuePairs.ContainsKey(key))
            {
                keyValuePairs[key] = value;
            }
            else
            {
                keyValuePairs.Add(key, value);
            }

            return true;
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Grabs a list of the keys
    /// </summary>
    /// <typeparam name="TKey">Key data type</typeparam>
    /// <typeparam name="TValue">Value data type</typeparam>
    /// <param name="keyValuePairs">Dictionary object</param>
    /// <returns>A list of the keys</returns>
    public static List<TKey> AllKeys<TKey, TValue>(this IDictionary<TKey, TValue>? keyValuePairs) =>
        keyValuePairs.IsNotNullOrEmpty() ? keyValuePairs.Select(x => x.Key).ToList() : new List<TKey>();

    /// <summary>
    /// Grabs a list of the values
    /// </summary>
    /// <typeparam name="TKey">Key data type</typeparam>
    /// <typeparam name="TValue">Value data type</typeparam>
    /// <param name="keyValuePairs">Dictionary object</param>
    /// <returns>A list of the values</returns>
    public static List<TValue> AllValues<TKey, TValue>(this IDictionary<TKey, TValue> keyValuePairs) =>
        keyValuePairs.IsNotNullOrEmpty() ? keyValuePairs.Select(x => x.Value).ToList() : new List<TValue>();
    #endregion
}