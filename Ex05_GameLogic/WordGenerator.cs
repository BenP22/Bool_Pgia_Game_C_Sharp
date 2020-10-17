using System;
using System.Text;

namespace Ex05_GameLogic
{
    public class WordGenerator
    {
        private const int k_LengthOfWord = 4;
        private const char k_MinLetterInWord = 'A';
        private const char k_MaxLetterInWord = 'H';
        private static Random s_RandomGenerator = new Random();
        private string m_WordStr = string.Empty;

        public WordGenerator()
        {
            char currentRandomChar = (char)s_RandomGenerator.Next(k_MinLetterInWord, k_MaxLetterInWord + 1);
            for (int i = 0; i < k_LengthOfWord; i++)
            {
                while (m_WordStr.Contains(currentRandomChar.ToString()))
                {
                    currentRandomChar = (char)s_RandomGenerator.Next(k_MinLetterInWord, k_MaxLetterInWord + 1);
                }

                m_WordStr = string.Concat(m_WordStr, currentRandomChar);
            }
        }

        public WordGenerator(string i_WordStr)
        {
            m_WordStr = i_WordStr;
        }

        public static int LengthOfWord
        {
            get { return k_LengthOfWord; }
        }

        public static char MinLetterInWord
        {
            get { return k_MinLetterInWord; }
        }

        public static char MaxLetterInWord
        {
            get { return k_MaxLetterInWord; }
        }

        public string WordStr
        {
            get { return m_WordStr; }
        }

        public void CheckGuess(WordGenerator i_CompareToWord, out int o_NumOfHits, out int o_CorrectLettersInWrongPosition)
        {
            int charIndex = 0;
            o_NumOfHits = 0;
            o_CorrectLettersInWrongPosition = 0;
            foreach (char c in m_WordStr)
            {
                if (i_CompareToWord.m_WordStr.Contains(c.ToString()))
                {
                    if (charIndex == i_CompareToWord.m_WordStr.IndexOf(c))
                    {
                        o_NumOfHits++;
                    }
                    else
                    {
                        o_CorrectLettersInWrongPosition++;
                    }
                }
                charIndex++;
            }
        }
    }
}
