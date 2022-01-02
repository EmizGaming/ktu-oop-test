namespace Lab5
{
    /// <summary>
    /// A class for Kettles
    /// </summary>
    public class Kettle : Device
    {
        public double Power { get; set; }
        public Kettle(string storeName, string storeAddress, string storeNumber, string type, string manufacturer, string model, double volume, string energyClass,
            string mountingType, string color, bool hasCooler, double price, double power) : base(storeName, storeAddress, storeNumber, type, manufacturer, model, volume, energyClass, mountingType, color, hasCooler, price)
        {
            this.Power = power;
        }
    }
}
