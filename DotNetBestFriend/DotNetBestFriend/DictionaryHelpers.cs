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
    public static bool ContainsKeyAndNotDefault<TKey, TValue>(this IDictionary<TKey, TValue>? keyValuePairs, TKey key)
    {
        if (keyValuePairs.IsNotNullOrEmpty() && keyValuePairs.ContainsKey(key))
        {
            var val = keyValuePairs.SafeGetValue(key);

            if (val is not null)
            {
                return val.Equals(default(TValue)); 
            }
        }  

        return false;    
    }


    /// <summary>
    /// Gets a value from the dictionary regardless of null collection object
    /// </summary>
    /// <typeparam name="TKey">Key data type</typeparam>
    /// <typeparam name="TValue">Value data type</typeparam>
    /// <param name="keyValuePairs">IDictionary object</param>
    /// <param name="key">Key value</param>
    /// <returns>The correct value if found, but a default TValue if not found</returns>
    public static TValue? SafeGetValue<TKey, TValue>(this IDictionary<TKey, TValue>? keyValuePairs, TKey key)
    {
        try
        {
            return keyValuePairs.IsNotNullOrEmpty() ? keyValuePairs[key] : default;
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
    public static IEnumerable<TKey> AllKeys<TKey, TValue>(this IDictionary<TKey, TValue>? keyValuePairs) => keyValuePairs.SafeSelect(x => x.Key);

    /// <summary>
    /// Grabs a list of the values
    /// </summary>
    /// <typeparam name="TKey">Key data type</typeparam>
    /// <typeparam name="TValue">Value data type</typeparam>
    /// <param name="keyValuePairs">Dictionary object</param>
    /// <returns>A list of the values</returns>
    public static IEnumerable<TValue> AllValues<TKey, TValue>(this IDictionary<TKey, TValue>? keyValuePairs) => keyValuePairs.SafeSelect(x => x.Value);
    #endregion
}