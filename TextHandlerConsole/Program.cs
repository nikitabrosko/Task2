using System;
using System.Collections.Generic;
using System.IO;
using TextHandler.Parsers;
using System.Configuration;
using TextHandler.Tools;
using System.Linq;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.Texts;
using TextHandlerConsole.Enums;

namespace TextHandlerConsole
{
    public class Program
    {
        private static void Main()
        {
            try
            {

                while (true)
                {
                    Console.WriteLine("Choose an option: " +
                                      "\n1 - Read input file" +
                                      "\n2 - Write in output file" +
                                      "\n3 - Go to the Tools");

                    var consoleOption = ChooseConsoleOption(Console.ReadKey().Key);
                    var pathToInputFile = GetValueFromConfig("inputFilePath");
                    IText textObject = new Text();
                    var pathToOutputFile = GetValueFromConfig("outputFilePath");

                    var pathToTextWorkingToolFile = GetValueFromConfig("textWorkingToolFilePath");

                    Switch(consoleOption, pathToInputFile, pathToOutputFile, textObject, pathToTextWorkingToolFile);

                    Console.WriteLine("Do you want to continue?\n1 - Yes\n2 - No");

                    if (Console.ReadKey().Key is ConsoleKey.D2)
                    {
                        break;
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Something went wrong with configuration files");
            }
            catch (Exception message)
            {
                Console.WriteLine(message);
            }

            static void Switch(ConsoleOption consoleOption, string pathToInputFile, 
                string pathToOutputFile, IText textObject, string pathToTextWorkingToolFile)
            {
                switch (consoleOption)
                {
                    case ConsoleOption.ReadInputFile:
                        textObject = HandleReadInputFile(pathToInputFile);
                        break;
                    case ConsoleOption.WriteInOutputFile:
                        HandleWriteInOutputFile(pathToOutputFile, textObject);
                        break;
                    case ConsoleOption.Tools:
                        Console.WriteLine("Choose a tool: " +
                                          "\n1 - Print in file all sentences with ordering by number of words" +
                                          "\n2 - Print all words with input word length in question sentences" +
                                          "\n3 - Print text with removing all words with input length that starts with consonant letter" +
                                          "\n4 - Print text replacing all words with input length to substring");
                        var toolOption = ChooseToolsOption(Console.ReadKey().Key);
                        HandleTools(toolOption, pathToTextWorkingToolFile, textObject);
                        break;
                }
            }
        }

        private static IText HandleReadInputFile(string pathToInputFile)
        {
            using var streamReader = new StreamReader(pathToInputFile);
            var parserToObjectModel = new ParserToObjectModel(streamReader);

            Console.WriteLine("Read from input file succeed!");

            return parserToObjectModel.ReadFile();
        }

        private static void HandleWriteInOutputFile(string pathToOutputFile, IText textObject)
        {
            using var streamWriter = new StreamWriter(pathToOutputFile);
            var parserFromObjectModel = new ParserFromObjectModel(streamWriter);

            parserFromObjectModel.WriteInFile(textObject);

            Console.WriteLine("Print in output file succeed!");
        }

        private static void HandleTools(ToolOption toolOption, string pathToTextWorkingToolFile, IText textObject)
        {
            try
            {
                using var streamWriter = new StreamWriter(pathToTextWorkingToolFile);
                var pathToInputFile = GetValueFromConfig("inputFilePath");
                textObject = HandleReadInputFile(pathToInputFile);

                switch (toolOption)
                {
                    case ToolOption.FirstOption:
                        PrintSentencesWithOrderByNumberOfWordsInFile(textObject, streamWriter);
                        streamWriter.WriteLine(Environment.NewLine);
                        Console.WriteLine("Print first method in TextWorkingTool file succeed!");
                        break;
                    case ToolOption.SecondOption:
                        Console.WriteLine("Write the word length: ");
                        var wordLengthForSecondOption = int.Parse(Console.ReadLine() ?? throw new FormatException());
                        PrintFindWordsInQuestionSentencesInFile(textObject, wordLengthForSecondOption, streamWriter);
                        streamWriter.WriteLine(Environment.NewLine);
                        Console.WriteLine("Print second method in TextWorkingTool file succeed!");
                        break;
                    case ToolOption.ThirdOption:
                        Console.WriteLine("Write the word length: ");
                        var wordLengthForThirdOption = int.Parse(Console.ReadLine() ?? throw new FormatException());
                        PrintRemoveWordsThatStartsWithConsonantLetterInFile(textObject, wordLengthForThirdOption, streamWriter);
                        streamWriter.WriteLine(Environment.NewLine);
                        Console.WriteLine("Print third method in TextWorkingTool file succeed!");
                        break;
                    case ToolOption.FourthOption:
                        var pathToSubstringFile = GetValueFromConfig("substringFilePath");
                        var substring = GetSubstringFromFile(pathToSubstringFile);
                        Console.WriteLine("Write the word length: ");
                        var wordLengthForFourthOption = int.Parse(Console.ReadLine() ?? throw new FormatException());
                        Console.WriteLine("Write the sentence index: ");
                        var sentenceIndex = int.Parse(Console.ReadLine() ?? throw new FormatException());
                        PrintReplaceWordsWithSubstringInFile(textObject, sentenceIndex, substring, wordLengthForFourthOption, streamWriter);
                        Console.WriteLine("Print fourth method in TextWorkingTool file succeed!");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Something went wrong with input format!");
                HandleTools(toolOption, pathToTextWorkingToolFile, textObject);
            }
        }

        private static ConsoleOption ChooseConsoleOption(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    return ConsoleOption.ReadInputFile;
                case ConsoleKey.D2:
                    return ConsoleOption.WriteInOutputFile;
                case ConsoleKey.D3:
                    return ConsoleOption.Tools;
                default:
                    Console.WriteLine("Wrong input key!");
                    break;
            }

            return default;
        }

        private static ToolOption ChooseToolsOption(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    return ToolOption.FirstOption;
                case ConsoleKey.D2:
                    return ToolOption.SecondOption;
                case ConsoleKey.D3:
                    return ToolOption.ThirdOption;
                case ConsoleKey.D4:
                    return ToolOption.FourthOption;
                default:
                    Console.WriteLine("Wrong input key!");
                    break;
            }

            return default;
        }

        private static IEnumerable<ISentenceElement> GetSubstringFromFile(string path)
        {
            var parserToObjectModel = new ParserToObjectModel(new StreamReader(path));
            var textObject = parserToObjectModel.ReadFile();

            if (textObject.Value.Count() != 1)
            {
                throw new ArgumentException("Incorrect path! File contains more or less sentences, than 1");
            }

            return textObject.Value.OfType<ISentence>().Single().Value;
        }

        private static void PrintReplaceWordsWithSubstringInFile(IText textObject, int sentenceIndex, 
            IEnumerable<ISentenceElement> substringText, int wordLength, TextWriter textWriter)
        {
            var newTextObject =
                TextWorkingTool.ReplaceWordsWithSubstring(textObject, sentenceIndex, substringText, wordLength);

            textWriter.WriteLine(newTextObject.GetStringRepresentation());
        }

        private static void PrintRemoveWordsThatStartsWithConsonantLetterInFile(IText textObject, int wordLength, TextWriter textWriter)
        {
            var newTextObject = TextWorkingTool.RemoveWordsThatStartsWithConsonantLetter(textObject, wordLength);

            textWriter.WriteLine(newTextObject.GetStringRepresentation());
        }

        private static void PrintSentencesWithOrderByNumberOfWordsInFile(IText textObject, TextWriter textWriter)
        {
            var sentences = TextWorkingTool.SentencesWithOrderByNumberOfWords(textObject);

            foreach (var sentence in sentences)
            {
                textWriter.WriteLine(sentence.GetStringRepresentation());
            }
        }

        private static void PrintFindWordsInQuestionSentencesInFile(IText textObject, int wordLength, TextWriter textWriter)
        {
            var words = TextWorkingTool.FindWordsInQuestionSentences(textObject, wordLength);

            foreach (var word in words)
            {
                textWriter.Write(word.GetStringRepresentation() + " ");
            }
        }

        private static string GetValueFromConfig(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var result = appSettings[key];

            if (result is null)
            {
                throw new ArgumentException("wrong key!");
            }

            return result;
        }
    }
}
