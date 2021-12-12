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

namespace TextHandlerConsole
{
    public class Program
    {
        private static void Main()
        {
            try
            {
                var pathOfInputFile = GetValueFromConfig("inputFilePath");

                IText textObject;

                using (var streamReader = new StreamReader(pathOfInputFile))
                {
                    var parserToObjectModel = new ParserToObjectModel(streamReader);
                    textObject = parserToObjectModel.ReadFile();
                    Console.WriteLine("Read from input file succeed!");
                }

                var pathOfOutputFile = GetValueFromConfig("outputFilePath");

                using (var streamWriter = new StreamWriter(pathOfOutputFile))
                {
                    var parserFromObjectModel = new ParserFromObjectModel(streamWriter);
                    parserFromObjectModel.WriteInFile(textObject);
                    Console.WriteLine("Print in output file succeed!");
                }

                var pathOfTextWorkingToolFile = GetValueFromConfig("textWorkingToolFilePath");

                using (var streamWriter = new StreamWriter(pathOfTextWorkingToolFile))
                {
                    PrintSentencesWithOrderByNumberOfWordsInFile(textObject, streamWriter);
                    streamWriter.WriteLine(Environment.NewLine);
                    Console.WriteLine("Print first method in TextWorkingTool file succeed!");

                    PrintFindWordsInQuestionSentencesInFile(textObject, 5, streamWriter);
                    streamWriter.WriteLine(Environment.NewLine);
                    Console.WriteLine("Print second method in TextWorkingTool file succeed!");

                    PrintRemoveWordsThatStartsWithConsonantLetterInFile(textObject, 5, streamWriter);
                    streamWriter.WriteLine(Environment.NewLine);
                    Console.WriteLine("Print third method in TextWorkingTool file succeed!");

                    var pathToSubstringFile = GetValueFromConfig("substringFilePath");

                    var substring = GetSubstringFromFile(pathToSubstringFile);
                    PrintReplaceWordsWithSubstringInFile(textObject, 0, substring, 5, streamWriter);
                    Console.WriteLine("Print fourth method in TextWorkingTool file succeed!");
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
        }

        private static IEnumerable<ISentenceElement> GetSubstringFromFile(string path)
        {
            var parserToObjectModel = new ParserToObjectModel(new StreamReader(path));
            var textObject = parserToObjectModel.ReadFile();

            if (textObject.Value.Count() != 1)
            {
                throw new ArgumentException("incorrect path! File contains more or less sentences, than 1");
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
