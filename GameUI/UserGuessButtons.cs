using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using Ex05_GameLogic;

namespace GameUI
{
    internal delegate void ButtonClickEventHandler(object sender, EventArgs e);

    internal class UserGuessButtons
    {
        internal event ButtonClickEventHandler ButtonClicked;
        private int m_Top = 0;
        private int m_Left = 0;
        private int m_Right = 0;
        protected readonly List<Button> r_Buttons = new List<Button>(WordGenerator.LengthOfWord);
        private const int k_ButtonDistance = 5;
        private static readonly GuessColorForm sr_GuessColorForm = new GuessColorForm();
        
        internal UserGuessButtons(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            createButtons();
        }

        private void createButtons()
        {
            int currentLeft = m_Left;
            for (int i = 0; i < WordGenerator.LengthOfWord; i++)
            {
                UserGuessButton newButton = new UserGuessButton();
                newButton.Top = m_Top;
                newButton.Left = currentLeft;
                newButton.Enabled = false;
                newButton.Click += newButton_Click;
                r_Buttons.Add(newButton);
                currentLeft += newButton.Width + k_ButtonDistance;
            }
            m_Right = currentLeft + k_ButtonDistance;
        }

        internal List<Button> Buttons
        {
            get { return r_Buttons; }
        }

        internal int Right
        {
            get { return m_Right; }
        }

        internal void ButtonsStatus(bool i_Status)
        {
            foreach (UserGuessButton button in r_Buttons)
            {
                button.Enabled = i_Status;
            }
        }

        internal bool AllButtonsAreColored()
        {
            bool allColored = true;
            foreach (UserGuessButton button in r_Buttons)
            {
                if (!button.IsColored)
                {
                    allColored = false;
                    break;
                }
            }
            return allColored;
        }

        internal bool HasNoDuplicates()
        {
            bool hasNoDuplicates = false;
            StringBuilder stringValue = new StringBuilder();
            foreach (UserGuessButton button in r_Buttons)
            {
                stringValue.Append(button.CharValue);
            }
            hasNoDuplicates = !(GameLogic.HasDuplicates(stringValue.ToString()));
            return hasNoDuplicates;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            DialogResult result = sr_GuessColorForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ((UserGuessButton)sender).Color = sr_GuessColorForm.ChosenColor;
                OnNewButtonClick(null);
            }
        }

        protected virtual void OnNewButtonClick(EventArgs e)
        {
            if (ButtonClicked != null)
            {
                ButtonClicked.Invoke(this, null);
            }
        }

    }
}
