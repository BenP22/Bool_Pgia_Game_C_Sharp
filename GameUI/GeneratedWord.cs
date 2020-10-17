namespace GameUI
{
    internal class GeneratedWord : UserGuessButtons
    {
        private string m_GeneratedColoredWord;
        internal GeneratedWord(int i_Top, int i_Left, string i_GeneratedWord) : base(i_Top, i_Left)
        {
            m_GeneratedColoredWord = i_GeneratedWord;
            createButtons();
        }

        private void createButtons()
        {
            int charIndex = 0;
            foreach (UserGuessButton button in r_Buttons)
            {
                button.ColorByChar(m_GeneratedColoredWord[charIndex]);
                button.Enabled = false;
                button.Hidden = true;
                charIndex++;
            }
        }

        internal void ShowGeneratedWord()
        {
            foreach (UserGuessButton button in r_Buttons)
            {
                button.Hidden = false;
            }
        }
    }
}
