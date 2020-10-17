using Ex05_GameLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameUI
{
    internal delegate void CheckGuessEventHandler(object sender, EventArgs e);

    internal class RoundUI
    {
        internal event CheckGuessEventHandler CheckGuessClicked;
        private int m_Top = 0;
        private int m_Left = 0;
        private int m_Right = 0;
        private UserGuessButtons m_UserGuessButtons;
        private GuessIndicator m_Indicators;
        private Button m_CheckGuessButton = new Button();
        private readonly List<Button> r_RoundButtons = new List<Button>();  
        private Round m_RoundLogic;
        private bool m_IsActive = false;
        
        internal RoundUI(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            createAllButtons();
            m_Right = m_Indicators.Right;
        }

        private void createAllButtons()
        {
            m_UserGuessButtons = new UserGuessButtons(m_Top, m_Left);
            m_UserGuessButtons.ButtonClicked += userGuessButtons_ButtonClicked;
            createCheckGuessButton();
            m_Indicators = new GuessIndicator(m_Top, m_CheckGuessButton.Right);
            r_RoundButtons.AddRange(m_UserGuessButtons.Buttons);
            r_RoundButtons.Add(m_CheckGuessButton);
            r_RoundButtons.AddRange(m_Indicators.Buttons);
        }

        private void createCheckGuessButton()
        {
            m_CheckGuessButton.Width = UserGuessButton.ButtonSize;
            m_CheckGuessButton.Height = UserGuessButton.ButtonSize / 2;
            m_CheckGuessButton.Top = m_Top + (UserGuessButton.ButtonSize / 4);
            m_CheckGuessButton.Left = m_UserGuessButtons.Right + 5;
            m_CheckGuessButton.BackColor = Color.LightGray;
            m_CheckGuessButton.Text = "-->>";
            m_CheckGuessButton.Enabled = false;
            m_CheckGuessButton.Click += checkGuessButtonButton_Click;
        }

        internal Round RoundLogic
        {
            set
            {
                m_RoundLogic = value;
                m_Indicators.ColorIndicators(value.GetNumberOfHits, value.GetCorrectLettersInWrongPosition);
            }
        }

        internal List<Button> Buttons
        {
            get { return r_RoundButtons; }
        }

        internal bool IsActive
        {
            get { return m_IsActive; }
            set
            {
                m_IsActive = value;
                m_UserGuessButtons.ButtonsStatus(value);
                if (value == false)
                {
                    m_CheckGuessButton.Enabled = value;
                }
            }
        }

        internal int Right
        {
            get { return m_Right; }
        }

        internal string GetStringValue()
        {
            StringBuilder stringValue = new StringBuilder();
            foreach (UserGuessButton button in m_UserGuessButtons.Buttons)
            {
                stringValue.Append(button.CharValue);
            }
            return stringValue.ToString();
        }

        internal bool AllButtonsAreColored()
        {
            return m_UserGuessButtons.AllButtonsAreColored();
        }

        internal bool HasNoDuplicates()
        {
            return m_UserGuessButtons.HasNoDuplicates();
        }

        private void userGuessButtons_ButtonClicked(object sender, EventArgs e)
        {
            if (AllButtonsAreColored())
            {
                m_CheckGuessButton.Enabled = true;
            }
        }

        private void checkGuessButtonButton_Click(object sender, EventArgs e)
        {
            OnCheckGuess(e);
        }

        protected virtual void OnCheckGuess(EventArgs e)
        {
            if (CheckGuessClicked != null)
            {
                CheckGuessClicked.Invoke(this, e);
            }
        }
    }
}