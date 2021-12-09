using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.Parsers;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;

namespace TextHandler.Concordance
{
    public class Concordance
    {
        private StreamWriter _streamWriter;

        public void GetConcordance(string pathFrom, string pathTo)
        {
            try
            {
                var parserToObjectModel = new ParserToObjectModel();
                var text = parserToObjectModel.ReadFile(pathFrom);

                PrintConcordanceInFile(pathTo, text);
            }
            finally
            {
                _streamWriter.Dispose();
            }
        }

        private void PrintConcordanceInFile(string pathTo, Text text)
        {
            _streamWriter = new StreamWriter(pathTo);

            var wordsInConcordance = ConcordanceResult(text).ToList();
            var firstLetters = GetFirstLetters(text).ToList();;

            for (int i = 0; i < wordsInConcordance.Count; i++)
            {
                _streamWriter.WriteLine(firstLetters[i]);

                foreach (var word in wordsInConcordance[i])
                {
                    _streamWriter.WriteLine();

                    foreach (var wordElement in word.Value)
                    {
                        _streamWriter.Write(char.ToLower(wordElement.Value));
                    }
                }

                _streamWriter.WriteLine(Environment.NewLine);
            }
        }

        private IEnumerable<char> GetFirstLetters(Text text)
        {
            return text.Value
                    .SelectMany(s => s.Value
                            .OfType<Word>()
                            .Select(w => char.ToUpper(w.Value.First().Value)))
                    .Distinct()
                    .OrderBy(c => c);
        }

        private IEnumerable<Word> GetWords(Text text)
        {
            return text.Value
                .SelectMany(s => s.Value
                    .OfType<Word>()
                    .Select(we => we))
                .OrderBy(w => w.Value.Count())
                .ThenBy(w => w.Value.First().Value)
                .Distinct(new WordEqualityComparer());
        }

        private IEnumerable<IEnumerable<Word>> ConcordanceResult(Text text)
        {
           return GetFirstLetters(text)
                .Select(c => GetWords(text)
                    .Where(w => char.ToUpper(w.Value.First().Value) == c));
        }
    }
}
