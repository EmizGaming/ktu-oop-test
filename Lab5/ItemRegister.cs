using System.Collections.Generic;

namespace Lab5
{
    class ItemRegister
    {

        private ItemContainer AllItems;
        /// <summary>
        /// Creates a list for all items in a register.
        /// </summary>
        public ItemRegister()
        {
            AllItems = new ItemContainer();
        }
        public ItemRegister(ItemContainer Items)
        {
            AllItems = Items;
        }
        /// <summary>
        /// Adds an item to a register
        /// </summary>
        /// <param name="item">Item data</param>
        public void Add(Device item)
        {
            AllItems.Add(item);
        }
        /// <summary>
        /// Counts all the items.
        /// </summary>
        /// <returns>Returns the count of all the items</returns>
        public int ItemCount()
        {
            return this.AllItems.Count;
        }
        /// <summary>
        /// Filters fridges by colors
        /// </summary>
        /// <returns>Returns a list of filtered elements</returns>
        public List<string> FilterFridgesByColor()
        {
            List<string> Filtered = new List<string>();
            for (int i = 0; i < AllItems.Count; i++)
            {
                if (AllItems.Get(i).Type == "Fridge" && !Filtered.Contains(AllItems.Get(i).Color))
                {
                    Filtered.Add(AllItems.Get(i).Color);
                }
            }
            return Filtered;
        }
        /// <summary>
        /// Filters kettles by colors
        /// </summary>
        /// <returns>Returns a list of filtered elements</returns>
        public List<string> FilterKettlesByColor()
        {
            List<string> Filtered = new List<string>();
            for (int i = 0; i < AllItems.Count; i++)
            {
                if (AllItems.Get(i).Type == "Kettle" && !Filtered.Contains(AllItems.Get(i).Color))
                {
                    Filtered.Add(AllItems.Get(i).Color);
                }
            }
            return Filtered;
        }
        /// <summary>
        /// Finds the minimum price of fridges
        /// </summary>
        /// <returns>Returns a price</returns>
        public double MinimumFridgePrice()
        {
            double minimum = AllItems.Get(0).Price;
            for (int i = 1; i < ItemCount(); i++)
            {
                if (AllItems.Get(i) < minimum && AllItems.Get(i).Type == "Fridge")
                {
                    minimum = AllItems.Get(i).Price;
                }
            }
            return minimum;
        }
        /// <summary>
        /// Finds the minimum price of kettles
        /// </summary>
        /// <returns>Returns a price</returns>
        public double MinimumKettlePrice()
        {
            double minimum = AllItems.Get(0).Price;
            for (int i = 1; i < ItemCount(); i++)
            {
                if (AllItems.Get(i) < minimum && AllItems.Get(i).Type == "Kettle")
                {
                    minimum = AllItems.Get(i).Price;
                }
            }
            return minimum;
        }
        /// <summary>
        /// Finds the minimum price of ovens
        /// </summary>
        /// <returns>Returns a price</returns>
        public double MinimumOvenPrice()
        {
            double minimum = AllItems.Get(0).Price;
            for (int i = 1; i < ItemCount(); i++)
            {
                if (AllItems.Get(i) < minimum && AllItems.Get(i).Type == "Oven")
                {
                    minimum = AllItems.Get(i).Price;
                }
            }
            return minimum;
        }
        /// <summary>
        /// Filters all items by price and energy class
        /// </summary>
        /// <returns>returns a list of elements by parameters</returns>
        public ItemContainer SortByParameters1()
        {
            ItemContainer Filtered = new ItemContainer();
            double minFridge = MinimumFridgePrice();
            double minOven = MinimumOvenPrice();
            double minKettle = MinimumKettlePrice();
            for (int i = 0; i < AllItems.Count; i++)
            {
                Device item = AllItems.Get(i);
                if (item.Type == "Fridge" && item.EnergyClass == "A+" && item.Price == minFridge)
                {
                    Filtered.Add(item);
                }
                if (item.Type == "Oven" && item.EnergyClass == "A+" && item.Price == minOven)
                {
                    Filtered.Add(item);
                }
                if (item.Type == "Kettle" && item.EnergyClass == "A+" && item.Price == minKettle)
                {
                    Filtered.Add(item);
                }
            }
            return Filtered;
        }
        /// <summary>
        /// Filters fridges by width
        /// </summary>
        /// <returns>Returns all elements which meets the requirements</returns>
        public ItemContainer SortByParameters2()
        {
            ItemContainer Filtered = new ItemContainer();
            for (int i = 0; i < AllItems.Count; i++)
            {
                Fridge item = AllItems.Get(i) as Fridge;
                if (item != null && item.Width >= 52 && item.Width <= 62 && item.Type == "Fridge")
                {
                    Filtered.Add(item);
                }
            }
            Filtered.Sort();
            return Filtered;
        }
        /// <summary>
        /// Finds all the items that can be bought in all the stores
        /// </summary>
        /// <returns>Returns a list of filtered items</returns>
        public ItemContainer SortByParameters3()
        {
            ItemContainer Filtered = new ItemContainer();
            var stores = GroupDevicesByStore();
            foreach (var store1 in stores)
            {
                for (int i = 0; i < store1.Value.Count; i++)
                {
                    bool good = true;
                    foreach (var store2 in stores)
                    {
                        if (!store2.Value.Contains(store1.Value.Get(i)))
                        {
                            good = false;
                            break;
                        }
                    }
                    if(good && !Filtered.Contains(store1.Value.Get(i)))
                    {
                        Filtered.Add(store1.Value.Get(i));
                    }
                }
            }
            return Filtered;
        }
        /// <summary>
        /// Checks if the item is the same
        /// </summary>
        /// <returns>Returns an item if met by requirements</returns>
        private Dictionary<string, ItemContainer> GroupDevicesByStore()
        {
            Dictionary<string, ItemContainer> result = new Dictionary<string, ItemContainer>();
            for (int i = 0; i < AllItems.Count; i++)
            {
                Device device = AllItems.Get(i);
                if (result.ContainsKey(device.StoreName))
                {
                    result[device.StoreName].Add(device);
                }
                else
                {
                    result[device.StoreName] = new ItemContainer();
                    result[device.StoreName].Add(device);
                }
            }
            return result;
        }

    }
}
