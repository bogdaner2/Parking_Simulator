using System;

namespace ParkingSimulator
{
    internal class Settings
    {
        private static readonly Lazy<Settings> Lazy = new Lazy<Settings>(() => new Settings());
        public static Settings Instance => Lazy.Value;
        private Settings() { }
    }
}
