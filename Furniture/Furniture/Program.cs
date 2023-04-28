using System.Xml.Schema;

namespace Furniture_Shop
{
    class Furniture
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual void Accept()
        {
            Console.Write("Enter height: ");
            Height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter width: ");
            Width = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter color: ");
            Color = Console.ReadLine();

            Console.Write("Enter quantity: ");
            Quantity = Convert.ToInt16(Console.ReadLine());

            Console.Write("Enter price: ");
            Price = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void Display()
        {
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine($"Width: {Width}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Price: {Price}");
        }

    }

    class BookShelf : Furniture
    {
        public int NoOfShelves { get; set; }

        public override void Accept()
        {
            base.Accept();

            Console.Write("Enter number of shelves: ");
            NoOfShelves = Convert.ToInt16(Console.ReadLine());
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine($"Number of shelves: {NoOfShelves}");
        }
    }

    class DiningTable : Furniture
    {
        public int NoOfLegs { get; set; }

        public override void Accept()
        {
            base.Accept();

            Console.Write("Enter number of legs: ");
            NoOfLegs = Convert.ToInt16(Console.ReadLine());
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine($"Number of legs: {NoOfLegs}");
        }
    }

    internal class Program
    {
        static void Addtostock(Furniture[] stock)
        {
            Console.WriteLine("Please select the type of furniture:");
            Console.WriteLine("1. Bookshelf");
            Console.WriteLine("2. Dining table");



            for (int i = 0; i < stock.Length; i++)
            {
                Console.Write("Enter 'Bookshelves'  or 'Diningtable' ");
                string choice = Console.ReadLine();

                Furniture Furnitures;

                if (choice.ToLower() == "bookshelves")
                {
                    Furnitures = new BookShelf();
                }
                else if (choice.ToLower() == "diningtable")
                {
                    Furnitures = new DiningTable();
                }
                else
                {
                    Console.WriteLine("Wrong option");
                    break;
                }

                Furnitures.Accept();

                stock[i] = Furnitures;


                Console.WriteLine($"{i + 1} Details accepted");
            }



        }


        static double TotalStockvalue(Furniture[] stock)
        {
            double totalStockValue = 0;

            for (int i = 0; i < stock.Length; i++)
            {
                totalStockValue += stock[i].Price * stock[i].Quantity;
            }

            return totalStockValue;
        }
        static void ShowStockDetails(Furniture[] stock)
        {

            foreach (Furniture f in stock)
            {

                f.Display();
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Furniture[] stock = new Furniture[2];
            Addtostock(stock);

            Console.WriteLine($"Total stock value is : {TotalStockvalue(stock)}");

            ShowStockDetails(stock);
        }
    }
}