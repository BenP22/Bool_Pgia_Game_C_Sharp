using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameUI
{
    internal class UserGuessButton : Button
    {
        private const short k_ButtonSize = 40;
        private char m_CharValue = '\0';
        private bool m_IsColored = false;
        private bool m_Hidden = false;

        internal UserGuessButton()
        {
            createButton();
        }

        internal UserGuessButton(int i_Top, int i_Left) : this()
        {
            Top = i_Top;
            Left = i_Left;
        }

        private void createButton()
        {
            Height = k_ButtonSize;
            Width = k_ButtonSize;
            BackColor = Color.LightGray;
        }

        internal Color Color
        {
            get { return BackColor; }
            set
            {
            eColorType colorValue = (eColorType)Enum.Parse(typeof(eColorType), value.Name);
            BackColor = value;
            m_CharValue = (char)colorValue;
            m_IsColored = true;               
            }
        }

        internal char CharValue
        {
            get { return m_CharValue; }
        }

        internal static int ButtonSize
        {
            get { return k_ButtonSize; }
        }

        internal bool Hidden
        {
            get { return m_Hidden; }
            set
            {
                if (value == true)
                {
                    BackColor = Color.Black;
                }
                else
                {
                    ColorByChar(m_CharValue);
                }
                m_Hidden = value;
            }
        }

        internal bool IsColored
        {
            get { return m_IsColored; }
        }

        internal void ColorByChar(char i_Char)
        {   
        eColorType colorValue = (eColorType)i_Char;
        BackColor = Color.FromName(colorValue.ToString());
        m_CharValue = i_Char;
        m_IsColored = true;          
        }
    }
}
