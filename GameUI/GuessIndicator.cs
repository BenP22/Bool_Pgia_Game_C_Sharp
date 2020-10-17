using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Ex05_GameLogic;

namespace GameUI
{
    internal class GuessIndicator
    {
        private int m_Top = 0;
        private int m_Left = 0;
        private int m_Right = 0;
        private const int k_FrameDistance = 10;
        protected readonly List<Button> r_Buttons = new List<Button>();
        private readonly int r_ButtonSize = (int)(0.4 * UserGuessButton.ButtonSize);
        private readonly int r_BlankSpaceBetweenButtons = (int)(0.1 * UserGuessButton.ButtonSize);
        private static readonly Color sr_HitColor = Color.Black;
        private static readonly Color sr_WrongPositionGuessColor = Color.Yellow;      
      
        internal GuessIndicator(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            createIndicators();
        }

        private void createIndicators()
        {
            int currentTop = m_Top;
            int currentLeft = m_Left + k_FrameDistance;
            int numberOfIndicators = WordGenerator.LengthOfWord;
            for (int i = 0; i < numberOfIndicators; i++)
            {
                Button newButton = new Button();
                if (i == numberOfIndicators / 2)
                {
                    currentTop = m_Top + r_ButtonSize + r_BlankSpaceBetweenButtons;
                    currentLeft = m_Left + k_FrameDistance;
                }
                newButton.Top = currentTop;
                newButton.Left = currentLeft;
                newButton.Height = r_ButtonSize;
                newButton.Width = r_ButtonSize;
                newButton.BackColor = Color.LightGray;
                newButton.Enabled = false;
                currentLeft += r_ButtonSize + r_BlankSpaceBetweenButtons;
                r_Buttons.Add(newButton);
            }
            m_Right = currentLeft + k_FrameDistance;
        }

        internal List<Button> Buttons
        {
            get { return r_Buttons; }
        }

        internal int Right
        {
            get { return m_Right; }
        }

        internal void ColorIndicators(int i_NumberOfHits, int i_NumberOfWrongPosition)
        {
            int currentIndicator = 0;
            for (int i = 0; i < i_NumberOfHits; i++)
            {
                r_Buttons[currentIndicator].BackColor = sr_HitColor;
                currentIndicator++;
            }
            for (int i = 0; i < i_NumberOfWrongPosition; i++)
            {
                r_Buttons[currentIndicator].BackColor = sr_WrongPositionGuessColor;
                currentIndicator++;
            }
        }
    }
}
