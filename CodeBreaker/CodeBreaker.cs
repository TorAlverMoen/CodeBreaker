using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeBreaker
{
    public partial class CodeBreaker : Form
    {
        public CodeBreaker()
        {
            InitializeComponent();
        }

        Color[] CombinationColour = { Color.DarkRed, Color.DarkOrange, Color.DarkCyan, Color.DarkGreen, Color.DarkBlue };
        int CombinationColourIndex = 0;

        int[] PlayerGuess = { 0, 0, 0 };
        int[] CorrectCombination = { 0, 0, 0 };

        int CorrectPlacement = 0;
        int CorrectColour = 0;

        int Turns = 0;
        int InternalTurns = 0;

        bool WinCondition = false;

        private void CodeBreaker_Load(object sender, EventArgs e)
        {
            // TODO: Display version number
            //NewGame();
        }

        void GenerateCorrectCombination()
        {
            Random randomColour = new Random();

            CorrectCombination[0] = randomColour.Next(0, 5);

            do
            {
                CorrectCombination[1] = randomColour.Next(0, 5);
            } while (CorrectCombination[1] == CorrectCombination[0]);

            do
            {
                CorrectCombination[2] = randomColour.Next(0, 5);
            } while ((CorrectCombination[2] == CorrectCombination[1]) || (CorrectCombination[2] == CorrectCombination[0]));
        }

        // TODO: New game

        void DisableColourLabels()
        {
            displayColour1.BackColor = Color.DarkGray;
            displayColour2.BackColor = Color.DarkGray;
            displayColour3.BackColor = Color.DarkGray;
        }

        void ResetButtonColours()
        {
            btnColour0.BackColor = CombinationColour[0];
            btnColour1.BackColor = CombinationColour[1];
            btnColour2.BackColor = CombinationColour[2];
            btnColour3.BackColor = CombinationColour[3];
            btnColour4.BackColor = CombinationColour[4];
        }

        void ChangeButtonState(int Index, bool NewState)
        {
            switch (Index)
            {
                case 0:
                    btnColour0.Enabled = NewState;
                    if (NewState)
                    {
                        btnColour0.BackColor = CombinationColour[0];
                    }
                    else
                    {
                        btnColour0.BackColor = Color.FromArgb(64, 64, 64);
                    }
                    break;
                case 1:
                    btnColour1.Enabled = NewState;
                    if (NewState)
                    {
                        btnColour1.BackColor = CombinationColour[1];
                    }
                    else
                    {
                        btnColour1.BackColor = Color.FromArgb(64, 64, 64);
                    }
                    break;
                case 2:
                    btnColour2.Enabled = NewState;
                    if (NewState)
                    {
                        btnColour2.BackColor = CombinationColour[2];
                    }
                    else
                    {
                        btnColour2.BackColor = Color.FromArgb(64, 64, 64);
                    }
                    break;
                case 3:
                    btnColour3.Enabled = NewState;
                    if (NewState)
                    {
                        btnColour3.BackColor = CombinationColour[3];
                    }
                    else
                    {
                        btnColour3.BackColor = Color.FromArgb(64, 64, 64);
                    }
                    break;
                case 4:
                    btnColour4.Enabled = NewState;
                    if (NewState)
                    {
                        btnColour4.BackColor = CombinationColour[4];
                    }
                    else
                    {
                        btnColour4.BackColor = Color.FromArgb(64, 64, 64);
                    }
                    break;
            }
        }

        // TODO: Game loop

        private void btnColour0_Click(object sender, EventArgs e)
        {

        }

        private void btnColour1_Click(object sender, EventArgs e)
        {

        }

        private void btnColour2_Click(object sender, EventArgs e)
        {

        }

        private void btnColour3_Click(object sender, EventArgs e)
        {

        }

        private void btnColour4_Click(object sender, EventArgs e)
        {

        }

        private void btnDifficulty_Click(object sender, EventArgs e)
        {

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
