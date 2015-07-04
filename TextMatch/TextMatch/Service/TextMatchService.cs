using System;
using System.Collections.Generic;
using TextMatch.Extension;

namespace TextMatch.Service
{
    public class TextMatchService : ITextMatchService
    {
        /// <inheritdoc />
        public string ProcessInputs(string text, string subtext)
        {
            //object to store matches!
            var positionMatches = new List<int>();
            //convert the text string into an array of char[]
            var textArray = text.ConvertToCharArray();
            //get a list of words in the subtext..we will match on each one.
            var wordsInSubText = FindWordsInSubTextArray(subtext.ConvertToCharArray());
            //find the matches for each word..
            foreach (var word in wordsInSubText)
            { 
                positionMatches.AddRange(FindStartPositionMatches(textArray, word));
            }
            //if we have any matches return there position as a string if not return "There is no output".
            return positionMatches.Count > 0
                ? positionMatches.ConvertToCommaDelimitedString()
                : "There is no output";
        }

        /// <summary>
        ///     Finds start postion matches between a list of char as the text being searched and another list of char as the text
        ///     being matched on.
        /// </summary>
        /// <param name="textArray">Text to search for start position matches</param>
        /// <param name="wordToMatch">Text used to match for start positions</param>
        /// <returns></returns>
        private IEnumerable<int> FindStartPositionMatches(IList<char> textArray, IList<char> wordToMatch)
        {
            //object to store match positions
            var positionMatches = new List<int>();
            //loop through the text finding matches    
            for (int i = 0; i < textArray.Count; i++)
            {
                //if the text array char doesnt match the start of teh word we are looking for continue.
                if (Char.ToLower(textArray[i]) != Char.ToLower(wordToMatch[0]))
                {
                    continue;
                }
                //we have our first match in the array, lets see if we can make a word
                //first make sure we have enough characters left in teh array to make the word
                //we are looking for if we dont continue.
                if (i + wordToMatch.Count > textArray.Count)
                {
                    continue;
                }
                //store our current match position for later
                int currentMatchPosition = i + 1;
                //set up a counter which we will use to verify we have a word later
                int counter = 0;
                //loop though the words to match array 
                for (int j = 0; j < wordToMatch.Count; j++)
                {
                    //if the position in the text array char matches the position in the wordToMatch char array
                    //it means we are still matching on a word
                    if (Char.ToLower(textArray[i + j]) == Char.ToLower(wordToMatch[j]))
                    {
                        //so we update the counter to indicate we have matched
                        counter = counter + 1;
                    }
                }
                //we check to see if the whole word was matched
                if (counter == wordToMatch.Count)
                {
                    //if it was add the match position to our list
                    positionMatches.Add(currentMatchPosition);
                }
            }
            //return all of the matched positions
            return positionMatches;
        }

        /// <summary>
        ///     Finds words in an array of char based on whitespace being the deliminator. This method is not the best
        ///     I was running out of time!
        /// </summary>
        /// <param name="input">The input to find words in</param>
        /// <returns></returns>
        private IEnumerable<List<char>> FindWordsInSubTextArray(IEnumerable<char> input)
        {
            //used to store the words, I would like to use an arary but I dont know how many words I'm going to get
            //and dont want to use array resize because i'm not aware of its impact on performance.
            var words = new List<List<char>>();
            //used to store any words we match
            var word = new List<char>();
            //loop though teh characters in the input string setting up words
            foreach (char character in input)
            {
                //if the characters isnt whitespace then add it to our word list
                if (!Char.IsWhiteSpace(character))
                {
                    word.Add(character);
                }
                //we have a word so add it to teh list and then clear the counter list
                else
                {
                    words.Add(word);
                    word = new List<char>();
                }
            }
            //make sure we get the last word
            if (word.Count > 0)
            {
                words.Add(word);
            }
            //return the words
            return words;
        }
    }
}