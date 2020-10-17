using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameUI
{
    internal class GuessColorForm : Form
    {
        private const int k_FrameDistance = 10;
        private const int k_BlankSpaceBetweenButtons = 5;
        private Color m_ChosenColor = Color.LightGray;

        internal GuessColorForm()
        {
            formInfo();
        }

        protected override void OnLoad(EventArgs e)
        {
            createForm();
            base.OnLoad(e);
        }

        private void formInfo()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Text = "Pick A Color:";
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void createForm()
        {
            Array allColors = Enum.GetNames(typeof(eColorType));
            int numberOfColors = allColors.Length;
            int colorCounter = 0;
            int currentTopOfButton = k_FrameDistance;
            int currentLeftOfButton = k_FrameDistance;
            foreach (string buttonColor in allColors)
            {
                UserGuessButton newButton = new UserGuessButton(currentTopOfButton, currentLeftOfButton);
                newButton.Color = Color.FromName(buttonColor);
                newButton.Click += newButton_Click;
                Controls.Add(newButton);
                currentLeftOfButton = newButton.Right + k_BlankSpaceBetweenButtons;
                if (colorCounter == (numberOfColors / 2) - 1)
                {
                    currentLeftOfButton = k_FrameDistance;
                    currentTopOfButton = newButton.Bottom + k_BlankSpaceBetweenButtons;
                }
                colorCounter++;
            }
            int colorsHeight = currentTopOfButton + UserGuessButton.ButtonSize + k_FrameDistance;
            int colorsWidth = currentLeftOfButton + k_FrameDistance - k_BlankSpaceBetweenButtons;
            ClientSize = new Size(colorsWidth, colorsHeight);
        }

        internal Color ChosenColor
        {
            get { return m_ChosenColor; }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            m_ChosenColor = ((UserGuessButton)sender).Color;
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
