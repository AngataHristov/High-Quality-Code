
namespace Minesweeper.Models
{
    using System;

    using Interfaces;

    public class Player : IPlayer
    {
        private string name;
        private int scores;

        public Player(string name, int scores)
        {
            this.Name = name;
            this.Scores = scores;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int Scores
        {
            get
            {
                return this.scores;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Scores cannot be negative");
                }
                this.scores = value;
            }
        }

    }
}
