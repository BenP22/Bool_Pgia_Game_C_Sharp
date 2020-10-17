using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Ex05_GameLogic;

namespace GameUI
{
    internal class GameBoardForm : Form
    {
        private readonly GameLogic r_GameLogic;
        private GeneratedWord m_RandomizedWord;
        private const int k_FrameDistance = 10;
        private const int k_TopOfFirstRound = 80;
        private const int k_RoundsDistance = 10;
        private readonly List<RoundUI> r_Rounds = new List<RoundUI>();
        private int m_ActiveRound = 0;

        internal GameBoardForm(int i_NumberOfRounds)
        {
            r_GameLogic = new GameLogic(i_NumberOfRounds);
            createForm();
        }

        private void createForm()
        {
            createRandomizedWord();
            createRounds(r_GameLogic.GetNumberOfUserGuesses);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Text = "Bool Pgia";
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void createRandomizedWord()
        {
            m_RandomizedWord = new GeneratedWord(k_FrameDistance, k_FrameDistance, r_GameLogic.GetRandomGeneratedWord);
            addButtonsToControls(m_RandomizedWord.Buttons);
        }

        private void createRounds(int i_NumberOfRounds)
        {
            int currentLeft = k_FrameDistance;
            int currentTop = k_TopOfFirstRound;
            for (int i = 0; i < i_NumberOfRounds; i++)
            {
                RoundUI newRound = new RoundUI(currentTop, currentLeft);
                r_Rounds.Add(newRound);
                addButtonsToControls(newRound.Buttons);
                newRound.CheckGuessClicked += checkGuessButton_Click;
                currentTop += UserGuessButton.ButtonSize + k_RoundsDistance;
            }
            r_Rounds[0].IsActive = true;
            ClientSize = new Size(r_Rounds[0].Right, currentTop);
        }

        private void addButtonsToControls(List<Button> i_Buttons)
        {
            foreach (Button button in i_Buttons)
            {
                Controls.Add(button);
            }
        }
       
        private void checkGuessButton_Click(object sender, EventArgs e)
        {
            RoundUI round = sender as RoundUI;
            if (round.AllButtonsAreColored())
            {
                if (round.HasNoDuplicates())
                {
                    round.RoundLogic = r_GameLogic.Play(round.GetStringValue());
                    r_Rounds[m_ActiveRound].IsActive = false;
                    activateNextRound();
                }
                else
                {
                    MessageBox.Show("No color duplicates are allowed, select unique colors and try again.");
                }
            }            
        }

        private void activateNextRound()
        {
            if (r_GameLogic.GameStatus == eGameStatus.Running)
            {
                m_ActiveRound++;
                r_Rounds[m_ActiveRound].IsActive = true;
            }
            else if (r_GameLogic.GameStatus == eGameStatus.Win)
            {
                MessageBox.Show("You won! =D Please press OK to continue.");
                m_RandomizedWord.ShowGeneratedWord();
            }
            else if (r_GameLogic.GameStatus == eGameStatus.Lose)
            {
                MessageBox.Show("You lost :( Please press OK to see the right answer.");
                m_RandomizedWord.ShowGeneratedWord();
            }
        }
    }
}