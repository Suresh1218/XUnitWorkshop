using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class StringManipulatorService : IStringManipulatorService
    {
        // Method to reverse a string
        public string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty.");

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        // Method to check if a string is a palindrome
        public bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty.");

            string reversedString = ReverseString(input);
            return input.Equals(reversedString, StringComparison.OrdinalIgnoreCase);
        }

        // Method to count the occurrences of a character in a string
        public int CountOccurrences(string input, char character)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty.");

            int count = 0;
            foreach (char c in input)
            {
                if (c == character)
                    count++;
            }
            return count;
        }

        // Method to remove duplicate characters from a string
        public string RemoveDuplicates(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty.");

            string result = "";
            foreach (char c in input)
            {
                if (result.IndexOf(c) == -1)
                    result += c;
            }
            return result;
        }
    }

    public interface IStringManipulatorService
    {
        public string ReverseString(string input);
        public bool IsPalindrome(string input);
        public int CountOccurrences(string input, char character);
        public string RemoveDuplicates(string input);
    }
}
