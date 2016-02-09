namespace HotelBookingSystem
{
    using System;
    using System.Globalization;
    using System.Threading;
    using HotelBookingSystem.Core;

    public class HotelBookingSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = Activator.CreateInstance(typeof(Engine)) as Engine;
            engine.StartOperation();
        }
    }
}