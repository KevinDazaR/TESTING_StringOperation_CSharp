using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console; // Agrega esta línea
using StringManipulation;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder.AddConsole())
            .AddSingleton<IFileReaderConector, FileReaderConector>()
            .AddSingleton<StringOperations>()
            .BuildServiceProvider();

        var logger = serviceProvider.GetService<ILogger<StringOperations>>();
        var stringOperations = serviceProvider.GetService<StringOperations>();

        while (true)
        {
            Console.WriteLine("Select the action");
            Console.WriteLine("1. contact 2 strings");
            Console.WriteLine("2. reverse string");
            Console.WriteLine("3. string length");
            Console.WriteLine("4. remove white spaces");
            Console.WriteLine("5. truncate string");
            Console.WriteLine("6. check if the word is palindrome");
            Console.WriteLine("7. count character concurrency");
            Console.WriteLine("8. pluralize a word");
            Console.WriteLine("9. express a quantity in words");
            Console.WriteLine("10. convert from roman to number");
            Console.WriteLine("11. read text file");

            if (!int.TryParse(Console.ReadLine(), out int optionSelected))
            {
                Console.WriteLine("Invalid selection, please enter a number between 1 and 11.");
                continue;
            }

            switch (optionSelected)
            {
                case 1:
                    Console.WriteLine("write a string 1");
                    string input1 = Console.ReadLine();

                    Console.WriteLine("write a string 2");
                    string input2 = Console.ReadLine();

                    Console.WriteLine(stringOperations.ConcatenateStrings(input1, input2));
                    break;
                case 2:
                    Console.WriteLine("write a string");
                    string inputToReverse = Console.ReadLine();

                    Console.WriteLine(stringOperations.ReverseString(inputToReverse));
                    break;
                case 3:
                    Console.WriteLine("write a string");
                    string inputLength = Console.ReadLine();

                    Console.WriteLine(stringOperations.GetStringLength(inputLength));
                    break;
                case 4:
                    Console.WriteLine("write a string");
                    string inputWhiteSpaces = Console.ReadLine();

                    Console.WriteLine(stringOperations.RemoveWhitespace(inputWhiteSpaces));
                    break;
                case 5:
                    Console.WriteLine("write a string");
                    string inputTruncate = Console.ReadLine();

                    Console.WriteLine("set max length");
                    if (!int.TryParse(Console.ReadLine(), out int maxLength))
                    {
                        Console.WriteLine("Invalid length.");
                        break;
                    }

                    Console.WriteLine(stringOperations.TruncateString(inputTruncate, maxLength));
                    break;
                case 6:
                    Console.WriteLine("write a string");
                    string inputPalindrome = Console.ReadLine();

                    Console.WriteLine(stringOperations.IsPalindrome(inputPalindrome));
                    break;
                case 7:
                    Console.WriteLine("write a string");
                    string inputConcurrency = Console.ReadLine();

                    Console.WriteLine("write a character");
                    if (!char.TryParse(Console.ReadLine(), out char charToFind))
                    {
                        Console.WriteLine("Invalid character.");
                        break;
                    }

                    Console.WriteLine(stringOperations.CountOccurrences(inputConcurrency, charToFind));
                    break;
                case 8:
                    Console.WriteLine("write a string");
                    string inputToPluralize = Console.ReadLine();

                    Console.WriteLine(stringOperations.Pluralize(inputToPluralize));
                    break;
                case 9:
                    Console.WriteLine("write a word");
                    string word = Console.ReadLine();

                    Console.WriteLine("write quantity");
                    if (!int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        Console.WriteLine("Invalid quantity.");
                        break;
                    }

                    Console.WriteLine(stringOperations.QuantintyInWords(word, quantity));
                    break;
                case 10:
                    Console.WriteLine("write a roman number");
                    string romanNumber = Console.ReadLine();
                    Console.WriteLine(stringOperations.FromRomanToNumber(romanNumber));
                    break;
                case 11:
                    var fileReader = serviceProvider.GetService<IFileReaderConector>();
                    Console.WriteLine(stringOperations.ReadFile(fileReader, "information.txt"));
                    break;
                default:
                    Console.WriteLine("Invalid selection, please enter a number between 1 and 11.");
                    break;
            }

            Console.WriteLine("///");
        }
    }
}
