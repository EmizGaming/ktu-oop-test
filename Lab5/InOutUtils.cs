using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab5
{
    class InOutUtils
    {
        /// <summary>
        /// Reads all the devices from a file
        /// </summary>
        /// <param name="fileName">a filename</param>
        /// <returns>Returns a container with all items in a file</returns>
        public static ItemContainer ReadItems(string fileName)
        {
            ItemContainer Items = new ItemContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            Items.AddInfo(Lines[0], Lines[1], Lines[2]);
            for (int i = 3; i < Lines.Length; i++)
            {
                string storeName = Lines[0];
                string storeAddress = Lines[1];
                string storeNumber = Lines[2];
                string[] Values = Lines[i].Split(';');
                string type = Values[0];
                string manufacturer = Values[1];
                string model = Values[2];
                double volume = Convert.ToDouble(Values[3]);
                string energyClass = Values[4];
                string mountingType = Values[5];
                string color = Values[6];
                bool hasCooler = Convert.ToBoolean(Values[7]);
                double price = Convert.ToDouble(Values[8]);
                switch (type)
                {
                    case "Fridge":
                        double height = Convert.ToDouble(Values[9]);
                        double width = Convert.ToDouble(Values[10]);
                        double depth = Convert.ToDouble(Values[11]);
                        Fridge fridge = new Fridge(storeName, storeAddress, storeNumber, type, manufacturer, model, volume, energyClass, mountingType, color, hasCooler, price, height, width, depth);
                        Items.Add(fridge);
                        break;
                    case "Kettle":
                        double power = Convert.ToDouble(Values[9]);
                        Kettle kettle = new Kettle(storeName, storeAddress, storeNumber, type, manufacturer, model, volume, energyClass, mountingType, color, hasCooler, price, power);
                        Items.Add(kettle);
                        break;
                    case "Oven":
                        double ovenPower = Convert.ToDouble(Values[9]);
                        double programCount = Convert.ToDouble(Values[10]);
                        Oven oven = new Oven(storeName, storeAddress, storeNumber, type, manufacturer, model, volume, energyClass, mountingType, color, hasCooler, price, ovenPower, programCount);
                        Items.Add(oven);
                        break;
                    default:
                        break;
                }
            }
            return Items;
        }
        /// <summary>
        /// Appends two containers
        /// </summary>
        /// <param name="Items1">Container 1</param>
        /// <param name="Items2">Container 2</param>
        private static void AppendContainer(ItemContainer Items1, ItemContainer Items2)
        {
            for (int i = 0; i < Items2.Count; i++)
            {
                Items1.Add(Items2.Get(i));
            }
        }
        /// <summary>
        /// Creates a container from file(s)
        /// </summary>
        /// <param name="filenames">A filename</param>
        /// <returns>A container containing all items</returns>
        public static ItemContainer CreateContainer(params string[] filenames)
        {
            ItemContainer mainContainer = new ItemContainer();
            foreach (string filename in filenames)
            {
                if (filename.EndsWith(".txt"))
                {
                    AppendContainer(mainContainer, ReadItems(filename));
                }
            }
            return mainContainer;
        }
        /// <summary>
        /// Prints items from a list
        /// </summary>
        /// <param name="colors">A list of items</param>
        public static void PrintColors(List<string> colors)
        {
            Console.WriteLine(new string('-', 15));
            Console.WriteLine("| {0, -11} |",
            "Spalva");
            Console.WriteLine(new string('-', 15));
            for (int i = 0; i < colors.Count; i++)
            {
                Console.WriteLine("| {0, -11} |", colors[i]);
            }
            Console.WriteLine(new string('-', 15));
        }
        /// <summary>
        /// Prints the cheapests devices information
        /// </summary>
        /// <param name="Items">A container of Items</param>
        public static void PrintCheapest(ItemContainer Items)
        {
            Console.WriteLine();
            for (int i = 0; i < Items.Count; i++)
            {
                Fridge item = Items.Get(i) as Fridge;
                if (item != null && item.Type == "Fridge")
                {
                    Console.WriteLine("Informacija apie pigiausią šaldytuvą : ");
                    Console.WriteLine(new string('-', 165));
                    Console.WriteLine("| {0, -11} | {1, -10} | {2, -7} | {3, 10} | {4, 10} | {5, 10} | {6, 10} | {7, 10} | {8, 10} | {9, 10} | {10, 10} | {11, 10} |",
                    "Parduotuve", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Šaldytuvas", "Kaina", "Aukštis", "Plotis", "Gylis");
                    Console.WriteLine(new string('-', 165));
                    Console.WriteLine("| {0, -11} | {1, -10} | {2, -7} | {3, 10} | {4, 15} | {5, 15} | {6, 10} | {7, 10} | {8, 10} | {9, 10} | {10, 10} | {11, 10} |",
                    item.StoreName, item.Manufacturer, item.Model, item.Volume, item.EnergyClass, item.MountingType, item.Color, item.hasCooler, item.Price, item.Height, item.Width, item.Depth);
                    Console.WriteLine(new string('-', 165));
                }
                Oven item1 = Items.Get(i) as Oven;
                if (item1 != null && item1.Type == "Oven")
                {
                    Console.WriteLine("Informacija apie pigiausią krosnelę : ");
                    Console.WriteLine(new string('-', 157));
                    Console.WriteLine("| {0, -11} | {1, -10} | {2, -7} | {3, 10} | {4, 10} | {5, 10} | {6, 10} | {7, 10} | {8, 10} | {9, 10} | {10, 10} |",
                    "Parduotuve", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Šaldytuvas", "Kaina", "Galia", "Programų kiekis");
                    Console.WriteLine(new string('-', 157));
                    Console.WriteLine("| {0, -11} | {1, -10} | {2, -7} | {3, 10} | {4, 15} | {5, 15} | {6, 10} | {7, 10} | {8, 10} | {9, 10} | {10, 15} |",
                    item1.StoreName, item1.Manufacturer, item1.Model, item1.Volume, item1.EnergyClass, item1.MountingType, item1.Color, item1.hasCooler, item1.Price, item1.OvenPower, item1.ProgramCount);
                    Console.WriteLine(new string('-', 157));
                }
                Kettle item2 = Items.Get(i) as Kettle;
                if (item2 != null && item2.Type == "Kettle")
                {
                    Console.WriteLine("Informacija apie pigiausią virdulį : ");
                    Console.WriteLine(new string('-', 139));
                    Console.WriteLine("| {0, -11} | {1, -10} | {2, -7} | {3, 10} | {4, 10} | {5, 10} | {6, 10} | {7, 10} | {8, 10} | {9, 10} |",
                    "Parduotuve", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Šaldytuvas", "Kaina", "Galia");
                    Console.WriteLine(new string('-', 139));
                    Console.WriteLine("| {0, -11} | {1, -10} | {2, -7} | {3, 10} | {4, 15} | {5, 15} | {6, 10} | {7, 10} | {8, 10} | {9, 10} |",
                    item2.StoreName, item2.Manufacturer, item2.Model, item2.Volume, item2.EnergyClass, item2.MountingType, item2.Color, item2.hasCooler, item2.Price, item2.Power);
                    Console.WriteLine(new string('-', 139));
                }
            }
        }
        /// <summary>
        /// Exports filtered items to a file
        /// </summary>
        /// <param name="fileName">A filename</param>
        /// <param name="Items">All items in a container</param>
        public static void PrintSorted1(string fileName, ItemContainer Items)
        {
            string[] lines = new string[Items.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}",
            "Gamintojas", "Modelis", "Talpa", "Energijos Klasė", "Montavimo tipas", "Spalva", "Šaldytuvas", "Kaina", "Aukštis", "Plotis", "Gylis");
            for (int i = 0; i < Items.Count; i++)
            {
                Fridge item = Items.Get(i) as Fridge;
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}",
                item.Manufacturer, item.Model, item.Volume, item.EnergyClass,
                item.MountingType, item.Color, item.hasCooler, item.Price, item.Height, item.Width, item.Depth);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        /// <summary>
        /// Exports filtered items to a file
        /// </summary>
        /// <param name="fileName">A filename</param>
        /// <param name="Items">All items in a container</param>
        public static void PrintSorted2(string fileName, ItemContainer Items)
        {
            string[] lines = new string[Items.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}",
            "Tipas", "Gamintojas", "Modelis", "Talpa", "Energijos Klasė", "Montavimo tipas", "Spalva", "Šaldytuvas", "Kaina", "Aukštis", "Plotis", "Gylis");
            for (int i = 0; i < Items.Count; i++)
            {
                switch (Items.Get(i).Type)
                {
                    case "Fridge":
                        Fridge item = Items.Get(i) as Fridge;
                        lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}",
                        item.Type, item.Manufacturer, item.Model, item.Volume, item.EnergyClass,
                        item.MountingType, item.Color, item.hasCooler, item.Price, item.Height, item.Width, item.Depth);
                        break;
                    case "Kettle":
                        Kettle item1 = Items.Get(i) as Kettle;
                        lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}",
                        item1.Type, item1.Manufacturer, item1.Model, item1.Volume, item1.EnergyClass,
                        item1.MountingType, item1.Color, item1.hasCooler, item1.Price, item1.Power);
                        break;
                    case "Oven":
                        Oven item2 = Items.Get(i) as Oven;
                        lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}",
                        item2.Type, item2.Manufacturer, item2.Model, item2.Volume, item2.EnergyClass,
                        item2.MountingType, item2.Color, item2.hasCooler, item2.Price, item2.OvenPower, item2.ProgramCount);
                        break;
                }
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
