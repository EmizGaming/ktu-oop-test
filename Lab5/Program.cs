using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemContainer container = InOutUtils.CreateContainer("Input_2_1.txt", "Input_2_2.txt", "Input_2_3.txt"); // Creates a container
            ItemRegister register = new ItemRegister(container); // Creates a register
            Console.WriteLine("Šaldytuvų spalvos : ");
            InOutUtils.PrintColors(register.FilterFridgesByColor()); //Filters and prints fridges by color
            Console.WriteLine("Virdulių spalvos : ");
            InOutUtils.PrintColors(register.FilterKettlesByColor()); //Filters and prints kettles by color
            Console.WriteLine("Pigiausi daiktai : ");
            InOutUtils.PrintCheapest(register.SortByParameters1()); //Finds and prints cheapests devices
            InOutUtils.PrintSorted1("Tilps.csv",register.SortByParameters2()); //Filters fridges by dimentions and exports to a file
            InOutUtils.PrintSorted2("Abi.csv", register.SortByParameters3()); //Finds fridges that can be bought in all stores and exports to a file
            Console.ReadKey();
        }
    }
}
