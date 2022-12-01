using System;
using System.Windows.Forms;

namespace CodeBreaker
{
    public partial class HowToPlay : Form
    {
        public HowToPlay()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            howto_heading.Text = "How to play:";
            howto_text.Text = "The player tries to guess the pattern, in both order and colour,\n" +
                "within the turns allowed by the difficulty level.\n\n" +
                "When the player finishes one turn, the computer provides feedback\n" +
                "by telling the player how many of the colours are correct but\n" +
                "in the wrong position and how many colours are correct\n" +
                "and in the correct position.\n\n" +
                "If the player guesses the correct colours in the correct order\n" +
                "the player wins, if not the game advances to the next turn or\n" +
                "ends if there are no more turns.";
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
