using System.Windows.Forms;

namespace GameUI
{
    internal class GameManager
    {
        private StartGameForm m_StartGameForm;
        private GameBoardForm m_GameBoardForm;

        internal GameManager()
        {
            m_StartGameForm = new StartGameForm();
        }

        internal void Run()
        {
            DialogResult createFormGame = m_StartGameForm.ShowDialog();
            if (createFormGame != DialogResult.Cancel)
            {
                m_GameBoardForm = new GameBoardForm(m_StartGameForm.GetNumberOfChances);
                m_GameBoardForm.ShowDialog();
            }
        }
    }
}