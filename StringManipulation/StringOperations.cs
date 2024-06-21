using Humanizer;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace StringManipulation
{
    public class StringOperations
    {
        private readonly ILogger<StringOperations> _logger;

        public StringOperations(ILogger<StringOperations> logger)
        {
            _logger = logger;
        }

        public string ConcatenateStrings(string str1, string str2)
        {
            return str1 + " " + str2;
        }

        public string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public int GetStringLength(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return str.Length;
        }

        public string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }

        public string TruncateString(string input, int maxLength)
        {
            if (maxLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxLength));
            }

            if (string.IsNullOrEmpty(input) || maxLength >= input.Length)
            {
                return input;
            }

            return input.Substring(0, maxLength);
        }

        public bool IsPalindrome(string input)
        {
            string reversed = ReverseString(input);
            return input.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }

        public int CountOccurrences(string input, char character)
        {
            int count = input.Count(c => c == character);
            _logger.LogInformation($"Number of occurrences of '{character}' is: {count}");
            return count;
        }

        public string Pluralize(string input)
        {
            return input.Pluralize();
        }

        public string QuantintyInWords(string input, int quantity)
        {
            return input.ToQuantity(quantity, ShowQuantityAs.Words);
        }

        public int FromRomanToNumber(string input)
        {
            return input.FromRoman();
        }

        public string ReadFile(IFileReaderConector fileReader, string fileName)
        {
            return fileReader.ReadString(fileName);
        }
    }
}
