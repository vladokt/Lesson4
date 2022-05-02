namespace Lesson4
{
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter the number of items (at least 2): ");

                string str = Console.ReadLine();
                str = str.Trim();

                int itemsnumber;
                string pattern = @"^\d+$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(str) && int.TryParse(str,out itemsnumber) && itemsnumber > 1)
                {
                    Console.WriteLine("Number is Ok!");

                    int[] items = new int[itemsnumber];

                    for (int i = 0; i < items.Length; i++)
                    {
                        do
                        {
                            Console.Write($"Enter item {i + 1}: ");
                        }
                        while (!int.TryParse(Console.ReadLine(), out items[i]));
                    }

                    int maxitem = items.Max();
                    int nextitem = items.Min();
                    
                    for (int i = 1; i < items.Length; i++)
                    {
                        if (items[i] < maxitem && items[i] > nextitem)
                        {
                            nextitem = items[i];
                        }
                    }

                    if (maxitem == nextitem)
                    {
                        Console.WriteLine("All items are equal.");
                    }
                    else
                    {
                        Console.WriteLine($"Max item is {maxitem}, nextone item is {nextitem}.");
                    }
                }
                else
                {
                    Console.WriteLine("Next time enter correct number of items please!");
                }

                Console.WriteLine("Another one (y/n)?");
            }
            while (Console.ReadLine() == "y");

            Console.WriteLine("Bye!");
        }
    }
}