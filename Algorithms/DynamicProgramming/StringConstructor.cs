using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    public class StringConstructor
    {
        public bool CanConstruct(string word, string[] syllables)
        {
            if (word.Length == 0) return true;

            foreach (var syllable in syllables)
            {
                if (word.StartsWith(syllable))
                {
                    var canConstruct = CanConstruct(word.Remove(0, syllable.Length), syllables);
                    if (canConstruct)
                    {
                        return true;
                    }
                }

                //if (word.EndsWith(syllable))
                //{
                //    var canConstruct = CanConstruct(word.Substring(0, word.Length - syllable.Length), syllables);
                //    if (canConstruct)
                //    {
                //        return true;
                //    }
                //}
            }

            return false;
        }

        private Dictionary<string, bool> wordsMemo = new Dictionary<string, bool>();

        public bool CanConstructWithMemoization(string word, string[] syllables)
        {
            if (word.Length == 0) return true;
            if (wordsMemo.ContainsKey(word))
            {
                return wordsMemo.GetValueOrDefault(word);
            }

            foreach (var syllable in syllables)
            {
                if (word.StartsWith(syllable))
                {
                    var canConstruct = CanConstructWithMemoization(word.Remove(0, syllable.Length), syllables);
                    if (canConstruct)
                    {
                        wordsMemo.Add(word, true);
                        return true;
                    }
                }
            }

            wordsMemo.Add(word, false);
            return false;
        }
    }
}
