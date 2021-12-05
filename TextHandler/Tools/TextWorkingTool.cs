using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandler.Tools
{
    public static class TextWorkingTool
    {
        public static IEnumerable<Sentence> SentencesWithOrderByNumberOfWords(Text text)
        {
            return text.Value.OrderByDescending(s => s.Value.Count(e => e is Word));
        }

        public static IEnumerable<Word> FindWordsWithGivenLengthInQuestionSentences(Text text, int length)
        {
            return text.Value
                .Where(s => (s.Value.Last() as PunctuationMark)?.Value == '?')
                .Select(s => s.Value.Where(e => (e as Word)?.Value.Count() == length).Select(w => w as Word).Distinct())
                .Aggregate((currentSentence, nextSentence) => currentSentence.Union(nextSentence));
        }

        public static Text RemoveWordsWithGivenLengthThatStartsInConsonantLetter(Text text, int length)
        {
            var consonants = "bcdfghjklmnpqrstvwxz".ToList();

            var sentences = text.Value
                .Select(s => s.Value.Where(e =>
                    e is PunctuationMark or PunctuationSymbol || 
                    !(((Word) e).Value.Count() == length && 
                     consonants.Contains(char.ToLower(((Letter) ((Word) e).Value.First()).Value)))));

            Text newText = new Text();

            foreach (var sentenceElements in sentences)
            {
                var sentenceElementsList = sentenceElements.ToList();
                Sentence sentence;

                try
                {
                    sentence = new Sentence(sentenceElementsList);
                    newText.Append(sentence);
                }
                catch (ArgumentException)
                {
                    switch (sentenceElementsList.First())
                    {
                        case PunctuationMark or PunctuationSymbol:
                            sentenceElementsList.RemoveAt(0);
                            break;
                        case Word word:
                        {
                            char firstCharacter = ((Letter) word.Value.First()).Value;

                            if (char.IsLower(firstCharacter))
                            {
                                var firstWordBuffer = word.Value.Skip(1);
                                firstWordBuffer = firstWordBuffer.Prepend(new Letter(char.ToUpper(firstCharacter)));
                                sentenceElementsList.RemoveAt(0);
                                sentenceElementsList = sentenceElementsList.Prepend(new Word(firstWordBuffer)).ToList();
                            }

                            break;
                        }
                    }

                    sentence = new Sentence(sentenceElementsList);
                    newText.Append(sentence);
                }
            }

            return newText;
        }
    }
}