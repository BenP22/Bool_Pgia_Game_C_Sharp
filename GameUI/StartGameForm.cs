using System;
using System.Windows.Forms;
using System.Drawing;
using Ex05_GameLogic;

namespace GameUI
{
    internal class StartGameForm : Form
    {
        private const int k_StartFormHeight = 100;
        private const int k_StartFormWidth = 250;
        private Button m_NumberOfChancesButton = new Button();
        private const int k_FrameDistance = 10;      
        private int m_NumberOfChances = GameLogic.GetMinNumberOfGuesses;
        private Button m_StartButton = new Button();

        internal StartGameForm()
        {
            formInfo();
        }

        private void formInfo()
        {
            ClientSize = new Size(k_StartFormWidth, k_StartFormHeight);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Text = "Bool Pgia";
            MaximizeBox = false;
            MinimizeBox = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            createForm();
            base.OnLoad(e);
        }

        private void createForm()
        {
            m_NumberOfChancesButton.Top = k_FrameDistance;
            m_NumberOfChancesButton.Left = k_FrameDistance;
            m_NumberOfChancesButton.Width = ClientSize.Width - (2 * k_FrameDistance);
            m_NumberOfChancesButton.Text = string.Format("Number of chances: {0}", m_NumberOfChances);
            m_NumberOfChancesButton.Click += numberOfChancesButton_Click;
            Controls.Add(m_NumberOfChancesButton);
            m_StartButton.Top = ClientSize.Height - k_FrameDistance - m_StartButton.Height;
            m_StartButton.Left = ClientSize.Width - (2 * k_FrameDistance) - m_StartButton.Width;
            m_StartButton.Width = ClientSize.Width / 3;
            m_StartButton.Text = "Start";
            m_StartButton.Click += startButton_Click;
            Controls.Add(m_StartButton);
        }

        internal int GetNumberOfChances
        {
            get { return m_NumberOfChances; }
        }

        private void numberOfChancesButton_Click(object sender, EventArgs e)
        {
            m_NumberOfChances++;
            if (m_NumberOfChances > GameLogic.GetMaxNumberOfGuesses)
            {
                m_NumberOfChances = GameLogic.GetMinNumberOfGuesses;
            }
            ((Button)sender).Text = string.Format("Number of chances: {0}", m_NumberOfChances);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
