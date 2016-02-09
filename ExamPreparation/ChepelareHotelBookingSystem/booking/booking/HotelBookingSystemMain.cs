namespace HotelBookingSystem
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using Core.IO;
    using Data;
    using Interfaces;

    public class HotelBookingSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IHotelBookingSystemData database = new HotelBookingSystemData();

            IInputReader reader = new ConsoleReader();

            IOutputWriter writer = new ConsoleWriter
            {
                AutoFlush = true
            };

            IEngine engine = new HotelSystemEngine(database, reader, writer);

            engine.StartOperation();
        }
    }
}