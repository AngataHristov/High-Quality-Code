
namespace MinesweeperHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        private static string command = string.Empty;
        private static char[,] gameField = CreateGameField();
        private static char[,] mines = InsertMines();
        private static int counter = 0;
        private static bool IsExplode = false;
        private static List<Player> players = new List<Player>(6);
        private static int row = 0;
        private static int column = 0;
        private static bool flag = true;
        private const int maxSize = 35;
        private static bool flag2 = false;

        private static void Main()
        {
            do
            {
                if (flag)
                {
                    Console.WriteLine(
                        "Lets play “Mini4KI”. Try your luck to find all cells wuthout mines."
                        + " Command 'top' showes the scores, 'restart' starts new game, 'exit' quits the game!");
                    MakeBorders(gameField);
                    flag = false;
                }

                Console.Write("Enter row[0...4] and column[0...9], separated by space: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowScores(players);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        mines = InsertMines();
                        MakeBorders(gameField);
                        IsExplode = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                SwichTurns(gameField, mines, row, column);
                                counter++;
                            }

                            if (maxSize == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                MakeBorders(gameField);
                            }
                        }
                        else
                        {
                            IsExplode = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid input\n");
                        break;
                }

                if (IsExplode)
                {
                    MakeBorders(mines);

                    Console.Write("\nHrrrrrr! You have died with {0} scores. " + "Enter nickName: ", counter);

                    string nickName = Console.ReadLine();
                    Player player = new Player(nickName, counter);

                    if (players.Count < 5)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Score < player.Score)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Score.CompareTo(firstPlayer.Score));
                    ShowScores(players);

                    gameField = CreateGameField();
                    mines = InsertMines();
                    counter = 0;
                    IsExplode = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nCongratulations! You have found all 35 cells.");

                    MakeBorders(mines);

                    Console.WriteLine("Enter your name: ");

                    string name = Console.ReadLine();

                    Player player = new Player(name, counter);

                    players.Add(player);
                    ShowScores(players);

                    gameField = CreateGameField();
                    mines = InsertMines();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowScores(List<Player> players)
        {
            Console.WriteLine("\nScores:");

            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} successfull steps, before bomb exploded", i + 1, players[i].Name, players[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty scorelist!\n");
            }
        }

        private static void SwichTurns(char[,] field, char[,] mines, int row, int column)
        {
            char allMines = CountMines(mines, row, column);

            mines[row, column] = allMines;
            field[row, column] = allMines;
        }

        private static void MakeBorders(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);

                for (int col = 0; col < columns; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] InsertMines()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    gameField[row, col] = '-';
                }
            }

            List<int> listOfNumbers = new List<int>();

            while (listOfNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);

                if (!listOfNumbers.Contains(randomNumber))
                {
                    listOfNumbers.Add(randomNumber);
                }
            }

            foreach (int number in listOfNumbers)
            {
                int column = number / columns;
                int row = number % columns;

                if (row == 0 && number != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        private static char CountMines(char[,] gameField, int rows, int columns)
        {
            int counter = 0;
            int fieldRows = gameField.GetLength(0);
            int fieldColumns = gameField.GetLength(1);

            if (rows - 1 >= 0)
            {
                if (gameField[rows - 1, columns] == '*')
                {
                    counter++;
                }
            }

            if (rows + 1 < fieldRows)
            {
                if (gameField[rows + 1, columns] == '*')
                {
                    counter++;
                }
            }

            if (columns - 1 >= 0)
            {
                if (gameField[rows, columns - 1] == '*')
                {
                    counter++;
                }
            }

            if (columns + 1 < fieldColumns)
            {
                if (gameField[rows, columns + 1] == '*')
                {
                    counter++;
                }
            }

            if ((rows - 1 >= 0) && (columns - 1 >= 0))
            {
                if (gameField[rows - 1, columns - 1] == '*')
                {
                    counter++;
                }
            }

            if ((rows - 1 >= 0) && (columns + 1 < fieldColumns))
            {
                if (gameField[rows - 1, columns + 1] == '*')
                {
                    counter++;
                }
            }

            if ((rows + 1 < fieldRows) && (columns - 1 >= 0))
            {
                if (gameField[rows + 1, columns - 1] == '*')
                {
                    counter++;
                }
            }

            if ((rows + 1 < fieldRows) && (columns + 1 < fieldColumns))
            {
                if (gameField[rows + 1, columns + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}
