using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace CodeBreaker
{
    public partial class CodeBreaker : Form
    {
        public CodeBreaker()
        {
            InitializeComponent();
        }

        // The colours the player can choose from
        Color[] CombinationColour = { Color.DarkRed, Color.DarkOrange, Color.DarkCyan, Color.DarkGreen, Color.DarkBlue, Color.DarkViolet };

        int[] PlayerGuess = { 0, 0, 0, 0 };
        int[] CorrectCombination = { 0, 0, 0, 0 };

        int CorrectPlacement = 0;
        int CorrectColour = 0;

        int Turns = 0;
        int InternalTurns = 0;

        int Difficulty = 0;     // 0 (easy) -> 5 turns, 1 (moderate) -> 10 turns, 2 (difficult) -> 20 turns

        bool EndOfGame = false;
        bool IsNewGameStarted = false;

        private void CodeBreaker_Load(object sender, EventArgs e)
        {
            displayVersionNumber.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //displayVersionNumber.Text = "v" + String.Format(Application.ProductVersion);
            NewGame();
        }

        void GenerateCorrectCombination()
        {
            Random randomColour = new Random();

            // Generate first colour
            CorrectCombination[0] = randomColour.Next(0, 6);

            // Genereate the second colour (random colour except the first)
            do
            {
                CorrectCombination[1] = randomColour.Next(0, 6);
            } while (CorrectCombination[1] == CorrectCombination[0]);

            // Generate the third colour (random colour except the first two)
            do
            {
                CorrectCombination[2] = randomColour.Next(0, 6);
            } while ((CorrectCombination[2] == CorrectCombination[1]) || (CorrectCombination[2] == CorrectCombination[0]));

            // Generate the fourth colour (random colour except the first three)
            do
            {
                CorrectCombination[3] = randomColour.Next(0, 6);
            } while ((CorrectCombination[3] == CorrectCombination[2]) || (CorrectCombination[3] == CorrectCombination[1]) || (CorrectCombination[3] == CorrectCombination[0]));
        }

        void NewGame()
        {
            // Reset player guess array
            for (int i = 0; i < 4; i++)
            {
                PlayerGuess[i] = 0;
            }

            // Enable all buttons
            for (int i = 0; i < 4; i++)
            {
                ChangeButtonState(i, true);
            }

            // Reset colour labels and reset button colours
            DisableColourLabels();
            ResetButtonColours();

            GenerateCorrectCombination();

            // Display current number of correct and correctly placed colours
            CorrectPlacement = 0;
            CorrectColour = 0;
            displayCorrectPlacement.Text = CorrectPlacement.ToString();
            displayCorrectColour.Text = CorrectColour.ToString();

            InternalTurns = 1;

            switch (Difficulty)
            {
                case 0:
                    Turns = 5;
                    displayDifficulty.Text = "difficult";
                    break;
                case 1:
                    Turns = 10;
                    displayDifficulty.Text = "moderate";
                    break;
                case 2:
                    Turns = 20;
                    displayDifficulty.Text = "easy";
                    break;
            }

            // Display the remaining number of turns
            displayTurns.Text = Turns.ToString();

            // Status variables for current game
            EndOfGame = false;
            IsNewGameStarted = true;
        }

        void DisableColourLabels()
        {
            displayColour1.BackColor = Color.DarkGray;
            displayColour2.BackColor = Color.DarkGray;
            displayColour3.BackColor = Color.DarkGray;
            displayColour4.BackColor = Color.DarkGray;
        }

        void ResetButtonColours()
        {
            btnColour0.BackColor = CombinationColour[0];
            btnColour1.BackColor = CombinationColour[1];
            btnColour2.BackColor = CombinationColour[2];
            btnColour3.BackColor = CombinationColour[3];
            btnColour4.BackColor = CombinationColour[4];
            btnColour5.BackColor = CombinationColour[5];
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

            // Change the difficulty (update automatically if a new game was just started)
            if (IsNewGameStarted)
            {
                MessageBox.Show("The difficulty is changed to " + tempDifficulty, "Change difficulty",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewGame();
            }
            else
            {
                MessageBox.Show("The difficulty is changed to " + tempDifficulty +
                    "\n\nYou must start a new game for change to take effect!",
                    "Change difficulty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Enable or disable a button based on index
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
                case 5:
                    btnColour4.Enabled = NewState;
                    if (NewState)
                    {
                        btnColour4.BackColor = CombinationColour[5];
                    }
                    else
                    {
                        btnColour4.BackColor = Color.FromArgb(64, 64, 64);
                    }
                    break;
            }
        }

        // This is called every time the player chooses a colour
        void GameLoop(int ButtonIndex)
        {
            displayTurns.Text = Turns.ToString();

            if (IsNewGameStarted)
            {
                IsNewGameStarted = false;
            }

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
                case 4:
                    displayColour4.BackColor = CombinationColour[ButtonIndex];
                    PlayerGuess[3] = ButtonIndex;
                    ChangeButtonState(ButtonIndex, false);
                    break;
                default:
                    MessageBox.Show("InternalTurns is an illegal number: " + InternalTurns.ToString(), "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            InternalTurns++;

            // End of turn
            if (InternalTurns > 4)
            {
                InternalTurns = 1;

                /* Used for debugging: This will display the correct combination and the current player choice
                 * MessageBox.Show(CorrectCombination[0] + " " + CorrectCombination[1] + " " + CorrectCombination[2] + " - " +
                    PlayerGuess[0] + " " + PlayerGuess[1] + " " + PlayerGuess[2]);*/

                ResetButtonColours();

                for (int i = 0; i < 6; i++)
                {
                    ChangeButtonState(i, true);
                }

                Turns--;
                displayTurns.Text = Turns.ToString();

                // How many correct colours are in the correct place?
                CorrectPlacement = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (PlayerGuess[i] == CorrectCombination[i])
                    {
                        CorrectPlacement++;
                    }
                }

                displayCorrectPlacement.Text = CorrectPlacement.ToString();

                // How many correct colours are in the wrong place
                CorrectColour = 0;

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
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
                if ((Turns >= 0) && (CorrectPlacement == 4))
                {
                    MessageBox.Show("You found the correct combination!", "Success!");
                    EndOfGame = true;
                }

                // Was the correct combination not found?
                if ((Turns == 0) && (CorrectPlacement != 4))
                {
                    MessageBox.Show("You did not find the correct combination!", "Failure!");
                    EndOfGame = true;
                }

                // Enable all buttons
                for (int i = 0; i < 6; i++)
                {
                    ChangeButtonState(i, true);
                }

                // If the current game is finished, start a new one
                if (EndOfGame)
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
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();
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
