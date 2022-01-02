using System.Collections.Generic;

namespace Lab5
{
    /// <summary>
    /// A base class for Devices
    /// </summary>
    public abstract class Device
    {
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StoreNumber { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Volume { get; set; }
        public string EnergyClass { get; set; }
        public string MountingType { get; set; }
        public string Color { get; set; }
        public bool hasCooler { get; set; }
        public double Price { get; set; }
        public Device(string storeName, string storeAddress, string storeNumber, string type, string manufacturer, string model, double volume, string energyClass, string mountingType, string color, bool hasCooler, double price)
        {
            StoreName = storeName;
            StoreAddress = storeAddress;
            StoreNumber = storeNumber;
            Type = type;
            Manufacturer = manufacturer;
            Model = model;
            Volume = volume;
            EnergyClass = energyClass;
            MountingType = mountingType;
            Color = color;
            this.hasCooler = hasCooler;
            Price = price;
        }
        /// <summary>
        /// Checks if objects are identical
        /// </summary>
        /// <param name="obj">Another object</param>
        /// <returns>A true or false</returns>
        public override bool Equals(object obj)
        {
            return obj is Device device &&
                   Type == device.Type &&
                   Manufacturer == device.Manufacturer &&
                   Model == device.Model &&
                   Volume == device.Volume &&
                   EnergyClass == device.EnergyClass &&
                   MountingType == device.MountingType &&
                   Color == device.Color &&
                   hasCooler == device.hasCooler &&
                   Price == device.Price;
        }

        public override int GetHashCode()
        {
            int hashCode = -1871050636;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Manufacturer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            hashCode = hashCode * -1521134295 + Volume.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EnergyClass);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MountingType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Color);
            hashCode = hashCode * -1521134295 + hasCooler.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }


        /// <summary>
        /// Overrides operator <.
        /// </summary>
        /// <param name="item">Information about an item</param>
        /// <param name="minimum">Information about the minimum amount</param>
        /// <returns></returns>
        public static bool operator <(Device item, double minimum)
        {
            return (item.Price < minimum);
        }
        /// <summary>
        /// Overrides operator >.
        /// </summary>
        /// <param name="item">Information about an item</param>
        /// <param name="minimum">Information about the minimum amount</param>
        /// <returns></returns>
        public static bool operator >(Device item, double minimum)
        {
            return (item.Price > minimum);
        }
    }
}
