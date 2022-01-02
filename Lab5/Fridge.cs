namespace Lab5
{
    /// <summary>
    /// A class for fridges
    /// </summary>
    public class Fridge : Device
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public Fridge(string storeName, string storeAddress, string storeNumber, string type, string manufacturer, string model, double volume, string energyClass, string mountingType,
            string color, bool hasCooler, double price, double height, double width, double depth) : base(storeName, storeAddress, storeNumber, type, manufacturer, model, volume, energyClass, mountingType, color, hasCooler, price)
        {
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
        }
    }
}
