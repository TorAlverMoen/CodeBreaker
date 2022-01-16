using System;
using System.Drawing;
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

        int[] PlayerGuess = { 0, 0, 0 };
        int[] CorrectCombination = { 0, 0, 0 };

        int CorrectPlacement = 0;
        int CorrectColour = 0;

        int Turns = 0;
        int InternalTurns = 0;

        int Difficulty = 0; // 0 -> 5 turns, 1 -> 10 turns, 2 -> 20 turns

        bool WinCondition = false;

        private void CodeBreaker_Load(object sender, EventArgs e)
        {
            displayVersionNumber.Text = "v" + String.Format(Application.ProductVersion);
            NewGame();
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

        void NewGame()
        {
            for (int i = 0; i < 3; i++)
            {
                PlayerGuess[i] = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                ChangeButtonState(i, true);
            }

            DisableColourLabels();
            GenerateCorrectCombination();
            ResetButtonColours();

            CorrectPlacement = 0;
            CorrectColour = 0;
            displayCorrectPlacement.Text = CorrectPlacement.ToString();
            displayCorrectColour.Text = CorrectColour.ToString();

            InternalTurns = 1;

            switch (Difficulty)
            {
                case 0:
                    Turns = 5;
                    displayDifficulty.Text = "Difficult";
                    break;
                case 1:
                    Turns = 10;
                    displayDifficulty.Text = "Moderate";
                    break;
                case 2:
                    Turns = 20;
                    displayDifficulty.Text = "Easy";
                    break;
            }

            displayTurns.Text = Turns.ToString();

            WinCondition = false;
        }

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

        void ChangeDifficulty()
        {
            String tempDifficulty = "";

            Difficulty++;

            if (Difficulty > 2)
            {
                Difficulty = 0;
            }

            switch (Difficulty)
            {
                case 0:
                    tempDifficulty = "Difficult";
                    break;
                case 1:
                    tempDifficulty = "Moderate";
                    break;
                case 2:
                    tempDifficulty = "Easy";
                    break;
            }

            MessageBox.Show("The difficulty is changed to " + tempDifficulty +
                "\n\nYou must start a new game for change to take effect!",
                "Change difficulty", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void GameLoop(int ButtonIndex)
        {
            displayTurns.Text = Turns.ToString();

            if (InternalTurns == 1)
            {
                DisableColourLabels();
                ResetButtonColours();
            }

            switch (InternalTurns)
            {
                case 1:
                    displayColour1.BackColor = CombinationColour[ButtonIndex];
                    PlayerGuess[0] = ButtonIndex;
                    ChangeButtonState(ButtonIndex, false);
                    break;
                case 2:
                    displayColour2.BackColor = CombinationColour[ButtonIndex];
                    PlayerGuess[1] = ButtonIndex;
                    ChangeButtonState(ButtonIndex, false);
                    break;
                case 3:
                    displayColour3.BackColor = CombinationColour[ButtonIndex];
                    PlayerGuess[2] = ButtonIndex;
                    ChangeButtonState(ButtonIndex, false);
                    break;
                default:
                    MessageBox.Show("InternalTurns is an illegal number: " + InternalTurns.ToString(), "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            InternalTurns++;

            // End of turn
            if (InternalTurns > 3)
            {
                InternalTurns = 1;
                /*MessageBox.Show(CorrectCombination[0] + " " + CorrectCombination[1] + " " + CorrectCombination[2] + " - " +
                    PlayerGuess[0] + " " + PlayerGuess[1] + " " + PlayerGuess[2]);*/

                ResetButtonColours();

                for (int i = 0; i < 5; i++)
                {
                    ChangeButtonState(i, true);
                }

                Turns--;
                displayTurns.Text = Turns.ToString();

                // How many correct colours are in the correct place?
                CorrectPlacement = 0;

                for (int i = 0; i < 3; i++)
                {
                    if (PlayerGuess[i] == CorrectCombination[i])
                    {
                        CorrectPlacement++;
                    }
                }

                displayCorrectPlacement.Text = CorrectPlacement.ToString();

                // How many correct colour are in the wrong place
                CorrectColour = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i != j)
                        {
                            if (PlayerGuess[i] == CorrectCombination[j])
                            {
                                CorrectColour++;
                            }
                        }
                    }
                }

                displayCorrectColour.Text = CorrectColour.ToString();

                // Was the correct combination found?
                if ((Turns > 0) && (CorrectPlacement == 3))
                {
                    MessageBox.Show("You found the correct combination!", "Success!");
                    WinCondition = true;
                }

                // Was the correct combination not found?
                if ((Turns == 0) && (CorrectPlacement != 3))
                {
                    MessageBox.Show("You did not find the correct combination!", "Failure!");
                    WinCondition = false;
                }

                for (int i = 0; i < 5; i++)
                {
                    ChangeButtonState(i, true);
                }

                if (WinCondition)
                {
                    NewGame();
                }
            }
        }

        private void btnColour0_Click(object sender, EventArgs e)
        {
            GameLoop(0);
        }

        private void btnColour1_Click(object sender, EventArgs e)
        {
            GameLoop(1);
        }

        private void btnColour2_Click(object sender, EventArgs e)
        {
            GameLoop(2);
        }

        private void btnColour3_Click(object sender, EventArgs e)
        {
            GameLoop(3);
        }

        private void btnColour4_Click(object sender, EventArgs e)
        {
            GameLoop(4);
        }

        private void btnDifficulty_Click(object sender, EventArgs e)
        {
            ChangeDifficulty();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Code Breaker\n\nThis a test puzzle for a hobbyist game project.\n\n" +
                "Made by Tor Alver Moen\n\nVersion: " + String.Format(Application.ProductVersion), "About",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
