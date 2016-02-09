

namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    using Core;
    using Core.Engines;
    using Core.IO;
    using Interfaces;
    using Models;

    public class MinesweeperMain
    {
        public static void Main()
        {

            IDataBase db = new DataBase();

            ICommandManager commandManager = new CommandManager();

            IInputReader reader = new ConsoleReader();

            IOutputWriter writer = new ConsoleWriter
            {
                AutoFlush = true
            };

            IEngine engine = new MinesweeperEngine(db, commandManager, reader, writer);

            engine.Run();
        }
    }
}