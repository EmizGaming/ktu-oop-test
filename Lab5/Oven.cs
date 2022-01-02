namespace Lab5
{
    /// <summary>
    /// A class of Ovens
    /// </summary>
    public class Oven : Device
    {
        public double OvenPower { get; set; }
        public double ProgramCount { get; set; }
        public Oven(string storeName, string storeAddress, string storeNumber, string type, string manufacturer, string model, double volume, string energyClass,
            string mountingType, string color, bool hasCooler, double price, double ovenPower, double programCount) : base(storeName, storeAddress, storeNumber, type, manufacturer, model, volume, energyClass, mountingType, color, hasCooler, price)
        {
            this.OvenPower = ovenPower;
            this.ProgramCount = programCount;
        }
    }
}
