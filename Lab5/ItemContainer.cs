namespace Lab5
{
      /// <summary>
      /// A class in which data is stored.
      /// </summary>
    class ItemContainer
    {
        private Device[] items;
        /// <summary>
        /// Counts items in a container
        /// </summary>
        public int Count { get; private set; }
        private int Capacity;
        /// <summary>
        /// Creates a container for data
        /// </summary>
        /// <param name="capacity">Defines a capacity for the container</param>
        public ItemContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.items = new Device[capacity];
        }
        /// <summary>
        /// Duplicates container
        /// </summary>
        /// <param name="container">Containers identification</param>
        public ItemContainer(ItemContainer container) : this()
        {
            EnsureCapacity(container.Count);
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        /// <summary>
        /// Ensures that the capacity of a container is not exceeded.
        /// </summary>
        /// <param name="minimumCapacity">Minimum capacity of a container</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Device[] temp = new Device[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.items[i];
                }
                this.Capacity = minimumCapacity;
                this.items = temp;
            }
        }
        private string storeName;
        private string storeAddress;
        private string storeNumber;
        /// <summary>
        /// Adds info about the store
        /// </summary>
        /// <param name="storeName">Stores name</param>
        /// <param name="storeAddress">Stores address</param>
        /// <param name="storeNumber">Stores number</param>
        public void AddInfo(string storeName, string storeAddress, string storeNumber)
        {
            this.storeName = storeName.TrimEnd();
            this.storeAddress = storeAddress.TrimEnd();
            this.storeNumber = storeNumber.TrimEnd();
        }
        /// <summary>
        /// Returns the contacts of a store
        /// </summary>
        /// <returns>Returns the contacts</returns>
        public string[] GetContacts()
        {
            string[] Contacts = { storeName, storeAddress, storeNumber };
            return Contacts;
        }
        /// <summary>
        /// Adds an item to a container
        /// </summary>
        /// <param name="item">Information about an item</param>
        public void Add(Device item)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.items[this.Count++] = item;
        }
        /// <summary>
        /// Gets information from a container by index
        /// </summary>
        /// <param name="index">Index number</param>
        /// <returns>Returns the information from a container</returns>
        public Device Get(int index)
        {
            return this.items[index];
        }
        /// <summary>
        /// Checks if an item exists
        /// </summary>
        /// <param name="item">Item parameters</param>
        /// <returns>A true or false</returns>
        public bool Contains(Device item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Puts a new item into a container at a specific index.
        /// </summary>
        /// <param name="item">Information about an item</param>
        /// <param name="index">Index number</param>
        public void Put(Device item, int index)
        {
            items[index] = item;
        }
        /// <summary>
        /// Inserts an item into a container by moving other items.
        /// </summary>
        /// <param name="item">Items information</param>
        /// <param name="index">Index number</param>
        public void Insert(Device item, int index)
        {
            this.Count++;
            for (int i = this.Count - 1; i >= index; i--)
            {
                Device temp = this.items[i];
                this.items[i + 1] = temp;
            }
            this.items[index] = item;
        }
        /// <summary>
        /// Removes an item from the container by finding it.
        /// </summary>
        /// <param name="item">Information about an item</param>
        public void Remove(Device item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.items[j] = this.items[j + 1];
                    }
                }
                Count--;
            }
        }
        /// <summary>
        /// Removes an item from the container by index.
        /// </summary>
        /// <param name="index">Index number</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        /// <summary>
        /// Sorts a container by specific parameters.
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < Count; i++)
            {
                int index = -1;
                for (int j = i+1; j < Count; j++)
                {
                    if(items[i].Price < items[j].Price && items[i].Price == items[j].Price || string.Compare(items[i].Manufacturer,items[j].Manufacturer) > 0)
                    {
                        index = j;
                    }
                }
                if(index != -1)
                {
                    Device temp = items[i];
                    items[i] = items[index];
                    items[index] = temp;
                }
            }
        }
        /// <summary>
        /// Finds identical items by parameters in different containers.
        /// </summary>
        /// <param name="other">Another container</param>
        /// <returns>Filtered container.</returns>
        public ItemContainer Intersect(ItemContainer other)
        {
            ItemContainer result = new ItemContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Device current = this.items[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
