namespace TankManufacturer
{
    using System;
    using FactoryMethod.Factoris;
    using TankManufacturer.Units;

    class Program
    {
        static void Main()
        {
            TankFactory tankFactory = new GermanTankFactory();
            // TankFactory tankFactory = new RussianTankFactory();
            // TankFactory tankFactory = new AmericanTankFactory();

            var tank = tankFactory.CreateTank();
            Console.WriteLine(tank);
        }
    }
}
