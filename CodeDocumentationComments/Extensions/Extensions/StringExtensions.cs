using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// File extension class
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts an inputed string to coresponding hash representation
    /// </summary>
    /// <param name="input">inputed string</param>
    /// <returns>hash representation</returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();

        //Convert the input string to byte array and compute the hash
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            //format each one as a hexadecimal string
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// Converts an inputed string to coresponding Boolean
    /// </summary>
    /// <remarks>Returns True if it meets the predefined Value</remarks>
    /// <remarks>Returns False if it doesn't meet the predefined Value</remarks>
    /// <param name="input">String for converting</param>
    /// <returns>True or False</returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Converts the inputed string to coresponding 16-bit integer representation
    /// </summary>
    /// <param name="input">String for converting</param>
    /// <returns>16-bit integer or exeption</returns>
    /// <exception cref="ArgumentException">If the string cannot be converted, sends this Exception</exception>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Converts the inputed string to coresponding 32-bit integer representation
    /// </summary>
    /// <param name="input">String for converting</param>
    /// <returns>32-bit integer or exeption</returns>
    /// <exception cref="ArgumentException">If the string cannot be converted, sends this Exception</exception>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Converts the inputed string to coresponding 64-bit integer representation
    /// </summary>
    /// <param name="input">String for converting</param>
    /// <returns>64-bit integer or exeption</returns>
    /// <exception cref="ArgumentException">If the string cannot be converted, sends this Exception</exception>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Converts the inputed string to coresponding DateTime representation
    /// </summary>
    /// <remarks>If the string can be parsed, It returns a valid DateTime</remarks>
    /// <param name="input">String for processing</param>
    /// <returns>DateTime or exeption</returns>
    /// <exception cref="ArgumentException">If the string cannot be converted, sends this Exception</exception>
    /// <exception cref="NotSupportedException">If the converted DateTime is not supported, sends this Exception</exception>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// Capitalizes the first letter of predefined string
    /// </summary>
    /// <remarks>If the predefined string is empty or null, the result will be the same</remarks>
    /// <param name="input">String for processing</param>
    /// <returns>The inputed string with first letter capitalized</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// Extracts string between two strings
    /// </summary>
    /// <remarks>If the 'start' and 'end' strings are not found, returns empty</remarks>
    /// <param name="input">String for processing</param>
    /// <param name="startString">String to start extracting from</param>
    /// <param name="endString">String to stop extracting to</param>
    /// <param name="startFrom">Set the starting position for processing</param>
    /// <returns>Extracted string</returns>
    public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition =
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// Converts cyrellic to latin letters
    /// </summary>
    /// <param name="input">String for processing</param>
    /// <returns>The predefined string with converted cyrellic to latin letters</returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// Converts latin to cyrellic letters
    /// </summary>
    /// <param name="input">String for processing</param>
    /// <returns>The predefined string with converted latin to cyrellic letters</returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// Converts a given username to one, containing only valid symbols
    /// </summary>
    /// <remarks>Username is converted to latin leters</remarks>
    /// <param name="input">String for processing</param>
    /// <returns>Converted username</returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// Converts a given file name to valid, latin name
    /// </summary>
    /// <remarks>File name is converted to latin leters</remarks>
    /// <param name="input">String for processing</param>
    /// <returns>Converted file name</returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// Extracts the first characters from predefined string
    /// </summary>
    /// <param name="input">String for processing</param>
    /// <param name="charsCount">Number of chars to get</param>
    /// <returns>Requested amount of characters</returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// Extracts the file extension from given filename
    /// </summary>
    /// <remarks>If the file is empty or Null or the file's
    ///  name is unpropperly labeled, returns Empty string</remarks>
    /// <param name="fileName">filename</param>
    /// <returns>file extension as string</returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);

        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// Convert a given file extension to content type
    /// </summary>
    /// <remarks>Default content type: 'application/octet-stream'</remarks>
    /// <param name="fileExtension"> file extension for processing</param>
    /// <returns>File extension converted to content type, as string</returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };

        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Converts an inputed string to coresponding Byte Array representation
    /// </summary>
    /// <param name="input">String for processing</param>
    /// <returns>Corresponding Byte Array</returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}
