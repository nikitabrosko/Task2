using System;
using System.Collections.Generic;
using System.Linq;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Characters.Letters;
using TextHandler.TextObjectModel.Characters.Punctuation;

namespace TextHandler.Tools
{
    public static class TextWorkingTool
    {
        public static IEnumerable<Sentence> SentencesWithOrderByNumberOfWords(Text text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return text.Value.OrderByDescending(s => s.Value.Count(e => e is Word));
        }

        public static IEnumerable<Word> FindWordsInQuestionSentences(Text text, int wordLength)
        {
            CheckArgumentsForExceptions(text, wordLength);

            return text.Value
                .Where(s => (s.Value.Last() as PunctuationMark)?.Value == '?')
                .Select(s => s.Value.Where(e => (e as Word)?.Value.Count() == wordLength).Select(w => w as Word).Distinct())
                .Aggregate((currentSentence, nextSentence) => currentSentence.Union(nextSentence));
        }

        public static Text RemoveWordsThatStartsWithConsonantLetter(Text text, int wordLength)
        {
            CheckArgumentsForExceptions(text, wordLength);

            var consonants = "bcdfghjklmnpqrstvwxz".ToList();

            var sentences = text.Value
                .Select(s => s.Value.Where(e =>
                    e is PunctuationMark or PunctuationSymbol || 
                    !(((Word) e).Value.Count() == wordLength && 
                     consonants.Contains(char.ToLower(((Letter) ((Word) e).Value.First()).Value)))));

            Text newText = new Text();

            foreach (var sentenceElements in sentences)
            {
                CreateNewText(sentenceElements);
            }

            return newText;

            void CreateNewText(IEnumerable<ISentenceElement> sentenceElements)
            {
                var sentenceElementsList = sentenceElements.ToList();

                try
                {
                    if (sentenceElementsList.Count != 0)
                    {
                        var sentence = new Sentence(sentenceElementsList);
                        newText.Append(sentence);
                    }
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
                            char firstCharacter = ((Letter)word.Value.First()).Value;

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

                    CreateNewText(sentenceElementsList);
                }
            }
        }

        public static Text ReplaceWordsWithSubstring(Text mainText, int sentenceIndex, IEnumerable<ISentenceElement> substringText, int wordLength)
        {
            CheckArgumentsForExceptions(mainText, wordLength);

            if (substringText is null)
            {
                throw new ArgumentNullException(nameof(substringText));
            }

            var mainTextTemp = mainText.Value.ToList();

            if (sentenceIndex >= mainTextTemp.Count || sentenceIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sentenceIndex));
            }

            var previousSentence = mainTextTemp[sentenceIndex];

            var words = previousSentence.Value.Where(e => e is Word)
                .Where(w => ((Word) w).Value.Count() == wordLength);

            var newSentence = previousSentence.Value.ToList();
            
            var newSentenceCount = newSentence.Count;

            for (var i = 0; i < newSentenceCount; i++)
            {
                if (words.Contains(newSentence[i]))
                {
                    newSentence.RemoveAt(i);

                    foreach (var substringElement in substringText.Reverse())
                    {
                        newSentence.Insert(i, substringElement);
                    }
                }
            }

            mainTextTemp.RemoveAt(sentenceIndex);
            mainTextTemp.Insert(sentenceIndex, new Sentence(newSentence));

            var newText = new Text();

            foreach (var sentence in mainTextTemp)
            {
                newText.Append(sentence);
            }

            return newText;
        }

        private static void CheckArgumentsForExceptions(Text text, int wordLength)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (wordLength <= 0)
            {
                throw new ArgumentException("word length can not be less or equal 0", nameof(wordLength));
            }
        }
    }
}