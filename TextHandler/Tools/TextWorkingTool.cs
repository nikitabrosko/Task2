using System;
using System.Collections.Generic;
using System.Linq;
using TextHandler.TextObjectModel;
using TextHandler.TextObjectModel.Letters;
using TextHandler.TextObjectModel.Punctuations.PunctuationMarks;
using TextHandler.TextObjectModel.Punctuations.PunctuationSymbols;
using TextHandler.TextObjectModel.Sentences;
using TextHandler.TextObjectModel.Texts;
using TextHandler.TextObjectModel.Words;

namespace TextHandler.Tools
{
    public static class TextWorkingTool
    {
        public static IEnumerable<ISentence> SentencesWithOrderByNumberOfWords(IText text)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return text.Value
                .Select(te => te as ISentence)
                .OrderByDescending(s => s?.Value.Count(se => se is IWord));
        }

        public static IEnumerable<IWord> FindWordsInQuestionSentences(IText text, int wordLength)
        {
            CheckArgumentsForExceptions(text, wordLength);

            return text.Value
                .Select(te => te as ISentence)
                .Where(s => (s?.Value.Last() as IPunctuationMark)?.Value == '?')
                .Select(s => s?.Value
                    .Where(e => (e as IWord)?.Value.Count() == wordLength)
                    .Select(w => w as IWord)
                    .Distinct())
                .Aggregate((currentSentence, nextSentence) => currentSentence.Union(nextSentence));
        }

        public static IText RemoveWordsThatStartsWithConsonantLetter(IText text, int wordLength)
        {
            CheckArgumentsForExceptions(text, wordLength);

            var consonants = "bcdfghjklmnpqrstvwxz".ToList();

            var sentences = text.Value
                .Select(te => te as ISentence)
                .Select(s => s?.Value
                    .Where(e =>
                    e is IPunctuationMark or IPunctuationSymbol || 
                    !(((IWord) e).Value.Count() == wordLength && 
                     consonants.Contains(char.ToLower(((ILetter) ((IWord) e).Value.First()).Value)))));

            var newText = new Text();

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
                        case IPunctuationMark or IPunctuationSymbol:
                            sentenceElementsList.RemoveAt(0);
                            break;
                        case IWord word:
                        {
                            char firstCharacter = ((ILetter)word.Value.First()).Value;

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

        public static IText ReplaceWordsWithSubstring(IText mainText, int sentenceIndex, IEnumerable<ISentenceElement> substringText, int wordLength)
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

            if (mainTextTemp[sentenceIndex] is not ISentence)
            {
                throw new ArgumentException($"value with index {sentenceIndex} is not a Sentence");
            }

            var previousSentence = (mainTextTemp[sentenceIndex] as ISentence).Value.ToList();

            var words = previousSentence.Where(e => e is IWord)
                .Where(w => ((IWord) w).Value.Count() == wordLength);
            
            var newSentenceCount = previousSentence.Count;

            var newSentence = new List<ISentenceElement>();
            newSentence.AddRange(previousSentence);

            for (var i = 0; i < newSentenceCount; i++)
            {
                if (words.Contains(previousSentence[i]))
                {
                    var indexOfRemovingElement = newSentence.FindIndex(0, x => x == previousSentence[i]);
                    newSentence.Remove(previousSentence[i]);

                    newSentence.InsertRange(indexOfRemovingElement, substringText);
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

        private static void CheckArgumentsForExceptions(IText text, int wordLength)
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