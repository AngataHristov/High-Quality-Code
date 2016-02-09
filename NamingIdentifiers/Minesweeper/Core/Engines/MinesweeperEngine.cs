
using System;

namespace Minesweeper.Core.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Interfaces;
    using Models;

    public class MinesweeperEngine : IEngine
    {
        private string input = string.Empty;
        private IGameField gameField = FieldsFactory.Create();
        private IGameField mines = InsertMines();
        private int counter = 0;
        private bool grum = false;
        private List<Player> players = new List<Player>(6);
        private const int row = 0;
        private const int column = 0;
        private bool flag = true;
        private const int maks = 35;
        private bool flag2 = false;


        private bool isStarted;
        private readonly IDataBase db;
        private readonly ICommandManager commandManager;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public MinesweeperEngine(IDataBase db, ICommandManager commandManager, IInputReader reader, IOutputWriter writer)
        {
            this.db = db;
            this.commandManager = commandManager;
            this.commandManager.Engine = this;
            this.reader = reader;
            this.writer = writer;
        }

        public ICommandManager CommandManager
        {
            get { return this.commandManager; }
        }

        public IInputReader Reader
        {
            get { return this.reader; }
        }

        public IOutputWriter Writer
        {
            get { return this.writer; }
        }

        public IDataBase DB
        {
            get { return this.db; }
        }

        public void Run()
        {
            this.isStarted = true;

            IExecutable command = null;

            while (this.isStarted)
            {
                if (flag)
                {
                    this.Writer.WriteLine(
                        "Lets play “Mini4KI”. Try your luck to find all cells wuthout mines."
                        + " Command 'top' showes the scores, 'restart' starts new game, 'exit' quits the game!");

                    MakeBorders(gameField);

                    this.flag = false;
                }

                this.Writer.Write("Enter row[0...4] and column[0...9], separated by space: ");

                this.input = Console.ReadLine().Trim();

                string line = this.Reader.ReadNextLine().Trim();

                // string[] inputArgs = line.Split(' ');
                //
                // command = this.commandManager.ManageCommand(line);
                //
                // try
                // {
                //     command.OnExecuting += (sender, args) =>
                //     {
                //         this.isStarted = !args.Stopped;
                //     };
                //
                //     command.Execute();
                // }
                // catch (Exception e)
                // {
                //     this.Writer.WriteLine(e.Message);
                // }

                if (this.input.Length >= 3)
                {
                    int row = 0;
                    int column = 0;

                    if (int.TryParse(this.input[0].ToString(), out row) && int.TryParse(this.input[2].ToString(), out column)
                        && row <= this.gameField.Board.GetLength(0) && column <= this.gameField.Board.GetLength(1))
                    {
                        this.input = "turn";
                    }
                }

                switch (this.input)
                {
                    case "top":
                        ShowScores(this.players);
                        break;
                    case "restart":
                        this.gameField = FieldsFactory.Create();
                        this.mines = InsertMines();
                        MakeBorders(this.gameField);
                        this.grum = false;
                        this.flag = false;
                        break;
                    case "exit":
                        this.Writer.WriteLine("Bye, bye, bye!");

                        break;
                    case "turn":
                        if (this.mines.Board[row, column] != '*')
                        {
                            if (this.mines.Board[row, column] == '-')
                            {
                                ChancheTurns(this.gameField, this.mines, row, column);
                                this.counter++;
                            }

                            if (maks == this.counter)
                            {
                                this.flag2 = true;
                            }
                            else
                            {
                                MakeBorders(gameField);
                            }
                        }
                        else
                        {
                            grum = true;
                        }

                        break;
                    default:
                        this.Writer.WriteLine("\nError! Invalid input\n");
                        break;
                }

                if (grum)
                {
                    MakeBorders(mines);

                    this.Writer.Write(string.Format("\nHrrrrrr! You have died with {0} scores. " + "Enter nickName: ", counter));

                    string nickName = this.Reader.ReadNextLine();

                    Player player = new Player(nickName, counter);

                    if (players.Count < 5)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Scores < player.Scores)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));

                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Scores.CompareTo(firstPlayer.Scores));
                    ShowScores(players);

                    gameField = FieldsFactory.Create();
                    mines = InsertMines();
                    counter = 0;
                    grum = false;
                    flag = true;
                }

                if (flag2)
                {
                    this.Writer.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    MakeBorders(mines);
                    this.Writer.WriteLine("Enter your name: ");

                    string name = this.Reader.ReadNextLine();

                    Player player = new Player(name, counter);
                    players.Add(player);
                    ShowScores(players);
                    gameField = FieldsFactory.Create();
                    mines = InsertMines();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }

                this.Writer.WriteLine("Made in Bulgaria - Uauahahahahaha!");
                this.Writer.WriteLine("AREEEEEEeeeeeee.");

                Console.Read();
            }
        }

        private void ChancheTurns(IGameField field, IGameField mines, int row, int column)
        {
            char numberOfMines = CountMines(mines, row, column);

            mines.Board[row, column] = numberOfMines;
            field.Board[row, column] = numberOfMines;
        }

        private void MakeBorders(IGameField gameField)
        {
            int rows = gameField.Board.GetLength(0);
            int columns = gameField.Board.GetLength(1);

            this.Writer.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            this.Writer.WriteLine("   ---------------------");

            for (int row = 0; row < rows; row++)
            {
                this.Writer.Write(string.Format("{0} | ", row));

                for (int col = 0; col < columns; col++)
                {
                    this.Writer.Write(string.Format("{0} ", gameField.Board[row, col]));
                }

                this.Writer.Write("|");

                Console.WriteLine();
            }

            this.Writer.WriteLine("   ---------------------\n");
        }

        public IGameField Create()
        {
            IGameField gameField = new GameField();

            for (int row = 0; row < gameField.Board.GetLength(0); row++)
            {
                for (int col = 0; col < gameField.Board.GetLength(1); col++)
                {
                    gameField.Board[row, col] = '?';
                }
            }

            return gameField;
        }

        private static IGameField InsertMines()
        {
            int rows = 5;
            int cols = 10;

            IGameField gameField = FieldsFactory.Create();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    gameField.Board[row, col] = '-';
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
                int column = number / cols;
                int row = number % cols;

                if (row == 0 && number != 0)
                {
                    column--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField.Board[column, row - 1] = '*';
            }

            return gameField;
        }

        private char CountMines(IGameField field, int row, int column)
        {
            int counter = 0;
            int rows = field.Board.GetLength(0);
            int columns = field.Board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field.Board[row - 1, column] == '*')
                {
                    counter++;
                }
            }

            if (row + 1 < rows)
            {
                if (field.Board[row + 1, column] == '*')
                {
                    counter++;
                }
            }

            if (column - 1 >= 0)
            {
                if (field.Board[row, column - 1] == '*')
                {
                    counter++;
                }
            }

            if (column + 1 < columns)
            {
                if (field.Board[row, column + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (field.Board[row - 1, column - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (field.Board[row - 1, column + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (field.Board[row + 1, column - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (field.Board[row + 1, column + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }

        private void ShowScores(IEnumerable<IPlayer> players)
        {
            this.Writer.WriteLine("\nScores:");

            if (players.Any())
            {
                int counter = new int();

                foreach (IPlayer player in players)
                {
                    counter++;

                    this.Writer.WriteLine(string.Format("{0}. {1} --> {2} successfull steps, before bomb exploded", counter, player.Name, player.Scores));
                }

                this.Writer.WriteLine(string.Empty);
            }
            else
            {
                this.Writer.WriteLine("Empty scorelist!\n");
            }
        }
    }
}
