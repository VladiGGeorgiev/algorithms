using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    public class StringWaysConstructor
    {
        private Dictionary<string, int> wordsMemo = new Dictionary<string, int>();

        public int FindWaysToConstruct(string word, string[] syllables)
        {
            if (string.IsNullOrEmpty(word)) return 1;
            if (wordsMemo.ContainsKey(word))
            {
                return wordsMemo.GetValueOrDefault(word);
            }

            int numberOfWays = 0;
            foreach (var syllable in syllables)
            {
                if (word.StartsWith(syllable))
                {
                    int waysNumber = FindWaysToConstruct(word.Remove(0, syllable.Length), syllables);
                    numberOfWays += waysNumber;
                }
            }

            wordsMemo.Add(word, numberOfWays);
            return numberOfWays;
        }
    }
}
