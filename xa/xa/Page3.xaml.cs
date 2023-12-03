using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using xa;
using System.Windows.Input;


namespace xa
{
    public partial class Page3 : ContentPage
    {
        private TicTacToeGame ticTacToeGame;
        public Page3()
        {
            InitializeComponent();
            ticTacToeGame = new TicTacToeGame();
            BindingContext = ticTacToeGame;
        }
    }

    public class TicTacToeGame : BindableObject
    {
        private ObservableCollection<string> board;
        private int currentPlayer;
        private ICommand cellClickCommand;

        public TicTacToeGame()
        {
            InitializeGame();
            cellClickCommand = new Command<string>(MakeMove, CanMakeMove);
        }

        public ObservableCollection<string> Board
        {
            get { return board; }
            set
            {
                board = value;
                OnPropertyChanged();
            }
        }

        public string Result { get; private set; }

        public ICommand CellClickCommand
        {
            get { return cellClickCommand; }
        }

        private void InitializeGame()
        {
            Board = new ObservableCollection<string>(new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " });
            currentPlayer = 1;
            Result = string.Empty;
        }
        
        private bool CanMakeMove(string position)
        {
            int index;
            if (int.TryParse(position, out index) && index >= 0 && index < Board.Count && Board[index] == " ")
                return true;
            return false;
        }

        public void MakeMove(string position)
        {
            int index = int.Parse(position);

            if (Board[index] == " ")
            {
                Board[index] = (currentPlayer == 1) ? "X" : "O";

                if (CheckForWin() || CheckForTie())
                {
                    Result = $"Player {currentPlayer} wins!";
                }
                else
                {
                    currentPlayer = 3 - currentPlayer; // Switch player
                    Result = string.Empty;
                }
            }
            else
            {
                // Додайте відлагодження, якщо потрібно
                System.Diagnostics.Debug.WriteLine($"Invalid move for position {position}");
            }
        }



        private bool CheckForWin()
        {
            // Check rows, columns, and diagonals for a win
            for (int i = 0; i < 3; i++)
            {
                if (Board[i * 3] != " " && Board[i * 3] == Board[i * 3 + 1] && Board[i * 3 + 1] == Board[i * 3 + 2])
                    return true; // Check rows

                if (Board[i] != " " && Board[i] == Board[i + 3] && Board[i + 3] == Board[i + 6])
                    return true; // Check columns
            }

            if (Board[0] != " " && Board[0] == Board[4] && Board[4] == Board[8])
                return true; // Check main diagonal

            if (Board[2] != " " && Board[2] == Board[4] && Board[4] == Board[6])
                return true; // Check other diagonal

            return false;
        }
        private bool CheckForTie()
        {
            foreach (var cell in Board)
            {
                if (cell == " ")
                    return false; // There's still an empty cell, the game is not tied
            }
            Result = "It's a tie!";
            return true;
        }
    }
}