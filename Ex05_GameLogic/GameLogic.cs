using System.Collections.Generic;

namespace Ex05_GameLogic
{
    public class GameLogic
    {
        private const int k_MinNumberOfGuesses = 4;
        private const int k_MaxNumberOfGuesses = 10;
        private List<Round> m_RoundsPlayed = new List<Round>();
        private WordGenerator m_RandomGeneratedWord = new WordGenerator();
        private eGameStatus m_CurrentGameStatus = eGameStatus.Running;
        private int m_NumberOfUserGuesses;

        public GameLogic(int i_NumberOfUserGuesses)
        {
            m_NumberOfUserGuesses = i_NumberOfUserGuesses;
        }

        public static int GetMinNumberOfGuesses
        {
            get { return k_MinNumberOfGuesses; }
        }

        public static int GetMaxNumberOfGuesses
        {
            get { return k_MaxNumberOfGuesses; }
        }

        public static bool IsValidNumberOfGuesses(int i_NumberOfUSerGuesses)
        {
            return (k_MinNumberOfGuesses <= i_NumberOfUSerGuesses) && (i_NumberOfUSerGuesses <= k_MaxNumberOfGuesses);
        }

        public eGameStatus GameStatus
        {
            get { return m_CurrentGameStatus; }
        }

        public string GetRandomGeneratedWord
        {
            get { return m_RandomGeneratedWord.WordStr; }
        }

        public int GetNumberOfUserGuesses
        {
            get { return m_NumberOfUserGuesses; }
        }

        public int GetNumberOfRoundsPlayed()
        {
            return m_RoundsPlayed.Count;
        }

        public string GetRoundWordStr(int i_Round)
        {
            return m_RoundsPlayed[i_Round].WordStr;
        }

        public int GetNumberOfHits(int i_Round)
        {
            return m_RoundsPlayed[i_Round].GetNumberOfHits;
        }

        public int GetNumberOfCorrectLettersInWrongPosition(int i_Round)
        {
            return m_RoundsPlayed[i_Round].GetCorrectLettersInWrongPosition;
        }

        public static bool HasDuplicates(string i_WordStr)
        {
            bool duplicatesExistence = false;
            int numberOfDuplicates;
            for (int i = 0; i < i_WordStr.Length; i++)
            {
                numberOfDuplicates = 1;
                for (int j = i + 1; j < i_WordStr.Length; j++)
                {
                    if (i_WordStr[i].Equals(i_WordStr[j]))
                    {
                        numberOfDuplicates++;
                    }
                }
                if (numberOfDuplicates > 1)
                {
                    duplicatesExistence = true;
                }
            }
            return duplicatesExistence;
        }

        public static bool IsValidWord(string i_WordStr)
        {
            bool isValidWord = true;
            foreach (char c in i_WordStr)
            {
                if (!(c >= WordGenerator.MinLetterInWord && c <= WordGenerator.MaxLetterInWord))
                {
                    isValidWord = false;
                    break;
                }
            }

            return isValidWord;
        }

        public Round Play(string i_UserInput)
        {
            Round currentRound = new Round(i_UserInput);
            currentRound.Play(m_RandomGeneratedWord);
            m_RoundsPlayed.Add(currentRound);
            if (currentRound.GetIsWinningRound)
            {
                m_CurrentGameStatus = eGameStatus.Win;
            }
            if (m_RoundsPlayed.Count >= m_NumberOfUserGuesses)
            {
                m_CurrentGameStatus = eGameStatus.Lose;
            }
            return currentRound;
        }

        public void Quit()
        {
            m_CurrentGameStatus = eGameStatus.Quit;
        }
    }
}
