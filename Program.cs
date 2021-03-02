using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        public static void Main()
        {
            string filePath = @"E:\products.csv";
            StreamReader reader = null;
            int id;
            String item;
            double price;
            List<Products> listA = new List<Products>();
            if (File.Exists(filePath))
            {
                reader = new StreamReader(new FileStream(filePath, FileMode.Open));

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var values = line.Split(',');
                    id = Convert.ToInt32(values[0]);
                    item = values[1];
                    price = Convert.ToDouble(values[2]);
                    Products p = new Products();
                    p.id = id;
                    p.item = item;
                    p.cost = price;

                    listA.Add(p);
                    //foreach (var item in values)
                    //{
                    //    int ids = item
                    //    listA.Add(item);
                    //}

                }

            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
            //   Console.ReadLine();
            reader.Close();

            Create(listA);
            foreach (var i in listA)
            {
                Console.WriteLine(i.id + " " + i.item + " " + i.cost);
            }


        }

        public static void Create(List<Products> listA)
        {
            try
            {


                StreamWriter sw = new StreamWriter("E:\\products.txt");
                foreach (var i in listA)
                {
                    double cost = i.cost * 1.10;
                    sw.WriteLine(i.id + "," + i.item + "," + cost);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            Console.WriteLine("hello");
        }



    }
    class Products
    {
        public int id { get; set; }
        public String item { get; set; }
        public double cost { get; set; }


    }
}