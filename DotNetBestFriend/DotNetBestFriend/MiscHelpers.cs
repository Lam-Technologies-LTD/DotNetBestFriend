namespace DotNetBestFriend;

public static class MiscHelpers
{
    /// <summary>
    /// Turns the file into an array of bytes
    /// </summary>
    /// <param name="input">The stream with the file opened</param>
    /// <param name="throwOnError">Throws an exception if something goes wrong</param>
    /// <returns>An array of bytes</returns>
    /// <exception cref="ArgumentNullException">If the stream is null and throwOnError is set to True</exception>
    /// <exception cref="ArgumentOutOfRangeException">If the stream's file length is 0 and throwOnError is set to True</exception>
    /// <exception cref="Exception">The bytes are empty and throwOnError is set to True</exception>
    public static byte[]? ConvertFileStreamToBytes(this Stream input, bool throwOnError = false)
    {
        var retVal = default(byte[]?);

        try 
        {
            if (input is null)
            {
                if (throwOnError)
                {
                    throw new ArgumentNullException("Stream cannot be null!");
                }

                return retVal;
            }

            if (input.Length == default)
            {
                if (throwOnError)
                {
                    throw new ArgumentOutOfRangeException("Stream cannot be empty!");
                }

                return retVal;
            }

            using (var binaryReader = new BinaryReader(input))
            {
                retVal = binaryReader.ReadBytes((int)input.Length);
                binaryReader.Close();
            }

            if (retVal.IsNullOrEmpty() && throwOnError)
            {
                throw new Exception("The binary file could not output any bytes from the stream!");
            }
        }
        catch (Exception)
        {
            if (throwOnError)
            {
                throw;
            }
        }

        return retVal;
    }

    /// <summary>
    /// Safely converts a byte array to base 64 string regardless of null state
    /// </summary>
    /// <param name="attachment">Byte array</param>
    /// <returns>Base 64 string if successful. Empty string if null or empty</returns>
    public static string ConvertToBase64(this byte[]? attachment) => attachment.IsNotNullOrEmpty() ? Convert.ToBase64String(attachment) : string.Empty;

    /// <summary>
    /// Breaks a file down straight into base 64
    /// </summary>
    /// <param name="input">The stream with the file opened</param>
    /// <param name="throwOnError">Throws an exception if something goes wrong</param>
    /// <returns>Base 64 string if successful. Empty string if null or empty</returns>
    public static string ConvertToBase64(this Stream input, bool throwOnError = false) => ConvertToBase64(ConvertFileStreamToBytes(input, throwOnError));
}