namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int currentPlayer = 1;
        private bool gameFinished = false;
        private Button[,] gameBoard;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button new_game_btn;

        public Form1()
        {
            InitializeComponent();

            gameBoard = new Button[3, 3];
            button1 = new Button();
            gameBoard[0, 0] = button1;
            button2 = new Button();
            gameBoard[0, 1] = button2;
            button3 = new Button();
            gameBoard[0, 2] = button3;
            button4 = new Button();
            gameBoard[1, 0] = button4;
            button5 = new Button();
            gameBoard[1, 1] = button5;
            button6 = new Button();
            gameBoard[1, 2] = button6;
            button7 = new Button();
            gameBoard[2, 0] = button7;
            button8 = new Button();
            gameBoard[2, 1] = button8;
            button9 = new Button();
            gameBoard[2, 2] = button9;

            new_game_btn = new Button();

            // Ajouter les boutons à la fenêtre
            button1.Location = new Point(50, 50);
            button1.Size = new Size(50, 50);
            button1.Click += new EventHandler(button_Click);
            Controls.Add(button1);

            button2.Location = new Point(100, 50);
            button2.Size = new Size(50, 50);
            button2.Click += new EventHandler(button_Click);
            Controls.Add(button2);

            button3.Location = new Point(150, 50);
            button3.Size = new Size(50, 50);
            button3.Click += new EventHandler(button_Click);
            Controls.Add(button3);

            button4.Location = new Point(50, 100);
            button4.Size = new Size(50, 50);
            button4.Click += new EventHandler(button_Click);
            Controls.Add(button4);

            button5.Location = new Point(100, 100);
            button5.Size = new Size(50, 50);
            button5.Click += new EventHandler(button_Click);
            Controls.Add(button5);

            button6.Location = new Point(150, 100);
            button6.Size = new Size(50, 50);
            button6.Click += new EventHandler(button_Click);
            Controls.Add(button6);

            button7.Location = new Point(50, 150);
            button7.Size = new Size(50, 50);
            button7.Click += new EventHandler(button_Click);
            Controls.Add(button7);

            button8.Location = new Point(100, 150);
            button8.Size = new Size(50, 50);
            button8.Click += new EventHandler(button_Click);
            Controls.Add(button8);

            button9.Location = new Point(150, 150);
            button9.Size = new Size(50, 50);
            button9.Click += new EventHandler(button_Click);
            Controls.Add(button9);

            new_game_btn.Location = new Point(50, 200);
            new_game_btn.Size = new Size(150, 50);
            new_game_btn.Text = "New Game";
            new_game_btn.Click += new EventHandler(newGameButton_Click);
            Controls.Add(new_game_btn);
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            if (! gameFinished)
                return;
            // Afficher un message de confirmation
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir recommencer la partie ?", "Nouvelle partie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Réinitialiser les boutons du tableau de jeu
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        gameBoard[row, col].Text = "";
                    }
                }

                // Réinitialiser les variables de jeu
                currentPlayer = 1;
                gameFinished = false;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (gameFinished)
                return;

            Button button = (Button)sender;

            if (button.Text != "")
                return;

            if (currentPlayer == 1)
            {
                button.Text = "X";
                currentPlayer = 2;
            }
            else
            {
                button.Text = "O";
                currentPlayer = 1;
            }

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            // Check rows for winner
            for (int row = 0; row < 3; row++)
            {
                if (gameBoard[row, 0].Text != "" &&
                    gameBoard[row, 0].Text == gameBoard[row, 1].Text &&
                    gameBoard[row, 1].Text == gameBoard[row, 2].Text)
                {
                    gameFinished = true;
                    MessageBox.Show("Player " + gameBoard[row, 0].Text + " wins!");
                    return;
                }
            }

            // Check columns for winner
            for (int col = 0; col < 3; col++)
            {
                if (gameBoard[0, col].Text != "" &&
                    gameBoard[0, col].Text == gameBoard[1, col].Text &&
                    gameBoard[1, col].Text == gameBoard[2, col].Text)
                {
                    gameFinished = true;
                    MessageBox.Show("Player " + gameBoard[0, col].Text + " wins!");
                    return;
                }
            }

            // Check diagonals for winner
            if (gameBoard[0, 0].Text != "" &&
                gameBoard[0, 0].Text == gameBoard[1, 1].Text &&
                gameBoard[1, 1].Text == gameBoard[2, 2].Text)
            {
                gameFinished = true;
                MessageBox.Show("Player " + gameBoard[0, 0].Text + " wins!");
                return;
            }

            if (gameBoard[0, 2].Text != "" &&
                gameBoard[0, 2].Text == gameBoard[1, 1].Text &&
                gameBoard[1, 1].Text == gameBoard[2, 0].Text)
            {
                gameFinished = true;
                MessageBox.Show("Player " + gameBoard[0, 2].Text + " wins!");
                return;
            }

            // Check for tie
            if (IsBoardFull())
            {
                gameFinished = true;
                MessageBox.Show("Tie game!");
            }
        }

        private bool IsBoardFull()
        {
            // Parcours toutes les cases du tableau de boutons
            foreach (Button button in gameBoard)
            {
                // Si une case est vide, alors le plateau n'est pas plein
                if (button.Text == "")
                {
                    return false;
                }
            }

            // Toutes les cases sont occupées, le plateau est plein
            return true;
        }

    }
}