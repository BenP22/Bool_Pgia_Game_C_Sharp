namespace Ex05_GameLogic
{
    public class Round
    {
        private bool m_UserWon = false;
        private WordGenerator m_Word;
        private int m_NumberOfHits;
        private int m_CorrectLettersInWrongPosition;

        public Round(string i_WordStr)
        {
            m_Word = new WordGenerator(i_WordStr);
        }

        public string WordStr
        {
            get { return m_Word.WordStr; }
        }

        public int GetNumberOfHits
        {
            get { return m_NumberOfHits; }
        }

        public int GetCorrectLettersInWrongPosition
        {
            get { return m_CorrectLettersInWrongPosition; }
        }

        public bool GetIsWinningRound
        {
            get { return m_UserWon; }
        }

        public void Play(WordGenerator i_RandomGeneratedWord)
        {
            m_Word.CheckGuess(i_RandomGeneratedWord, out m_NumberOfHits, out m_CorrectLettersInWrongPosition);
            m_UserWon = m_NumberOfHits == WordGenerator.LengthOfWord;
        }
    }
}
