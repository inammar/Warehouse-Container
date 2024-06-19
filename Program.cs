using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Container.Step2
{
    class Box
    {
        private string material;
        private double length, width, height;
        private int weight, quantity, number;

        public Box()
        {
            number = 0;
            material = "";
            length = 0.0;
            width = 0.0;
            height = 0.0;
            weight = 0;
            quantity = 0;
        }
        public Box(int nr, string mat, double il, double pl, double au, int kg, int k)
        {
            number = nr;
            material = mat;
            length = il;
            width = pl;
            height = au;
            weight = kg;
            quantity = k;
        }
        public override string ToString()
        {
            string row;
            row = string.Format(" {0, 2:d} {1, -8}  {2, 7:f} {3, 7:f} {4, 7:f}     {5, 2:d}             {6, 2:d}",
            number, material, length, width, height, weight, quantity);
            return row;
        }
        public int GetWeight() { return weight; }
        public double GetHeight() { return height; }
        public int GetQuantity() { return quantity; }
        public string GetMaterial() { return material; }

        public static bool operator <=(Box boxes1, Box boxes2)
        {
            int t = String.Compare(boxes1.material, boxes2.material,
                                   StringComparison.CurrentCulture);
            return (t < 0 || (t == 0 && (boxes1.weight < boxes2.weight ||
                (boxes1.weight == boxes2.weight && boxes1.quantity < boxes2.quantity))));
        }
        public static bool operator >=(Box boxes1, Box boxes2)
        {
            int t = String.Compare(boxes1.material, boxes2.material,
                                   StringComparison.CurrentCulture);
            return (t > 0 || (t == 0 && (boxes1.weight > boxes2.weight ||
                (boxes1.weight == boxes2.weight && boxes1.quantity < boxes2.quantity))));
        }
    }
    class Warehouse
    {
        const int CMaxi = 100;
        private Box[] Boxes;
        private int n;
        public Warehouse()
        {
            n = 0;
            Boxes = new Box[CMaxi];
        }

        public Box Get(int i) { return Boxes[i]; }

        public int Get() { return n; }

        public void Place(Box ob) { Boxes[n++] = ob; }

        public void Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Box min = Boxes[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (Boxes[j] <= min)
                    {
                        min = Boxes[j];
                        im = j;
                    }
                Boxes[im] = Boxes[i];
                Boxes[i] = min;
            }
        }
    }
    class Program
    {
        const string CFd = "C:\\Users\\source\\repos\\Data.txt";
        //-------------------------------------------------
        static void Read(ref Warehouse warehouse, string fv)
        {
            string mat;
            double lg, pl, au;
            int kg, k, n, nr;
            string line;
            using (StreamReader reader = new StreamReader(fv))
            {
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    nr = int.Parse(parts[0]);
                    mat = parts[1];
                    lg = double.Parse(parts[2]);
                    pl = double.Parse(parts[3]);
                    au = double.Parse(parts[4]);
                    kg = int.Parse(parts[5]);
                    k = int.Parse(parts[6]);
                    Box ob = new Box(nr, mat, lg, pl, au, kg, k);
                    warehouse.Place(ob);
                }
            }
        }
        //------------------------------------------------------------------
        static void Print(Warehouse warehouse)
        {
            string top = " Info about the boxes \r\n"
            + " ------------------------------------------------------------------------- \r\n"
            + " No  Material   Lenght   Width  Height  Max.weight   Max.quantity of boxes \r\n"
            + "                                                      (one on the other) \r\n"
            + " ------------------------------------------------------------------------- ";
            Console.WriteLine(top);
            for (int i = 0; i < warehouse.Get(); i++)
                Console.WriteLine("{0,-25}", warehouse.Get(i).ToString());
            Console.WriteLine(" ----------------------------------------------------------------------- \n\n");
        }

        /**selects the heaviest box
        */
        static int HeaviestBoxNo(Warehouse warehouse)
        {
            int k = 0; //k - number of the box with the heaviest weight
            for (int i = 1; i < warehouse.Get(); i++)
            {
                if (warehouse.Get(i).GetWeight() > warehouse.Get(k).GetWeight())
                    k = i;
            }
            return k;
        }
        //------------------------------------------------------------------------
        /**selects the lightest box
         */
        static int LightestBoxNo(Warehouse warehouse)
        {
            int k = 0; //number of the box with the min weight
            for (int i = 1; i < warehouse.Get(); i++)
            {
                if (warehouse.Get(i).GetWeight() < warehouse.Get(k).GetWeight())
                    k = i;
            }
            return k;
        }
        //______________________________________________________________________
        //finds what is the quantity of boxes of certain material
        static int MaterialQuantity(Warehouse warehouse, string material)
        {
            int count = 0;

            for (int i = 0; i < warehouse.Get(); i++)
            {
                if (warehouse.Get(i).GetMaterial() == material) count++;
            }
            return count;
        }
        //---------------------------------------------------------------------------
        //forms new array with the particular type of material
        static void Form(Warehouse warehouse, ref Warehouse warehouseN, string material)
        {
            for (int i = 0; i < warehouse.Get(); i++)
            {
                if (warehouse.Get(i).GetMaterial() == material)
                    warehouseN.Place(warehouse.Get(i));
            }
        }
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            Warehouse warehouseN = new Warehouse();
            string material = "Plastic";
            Read(ref warehouse, CFd);
            Print(warehouse);

            //The heaviest box
            int k = HeaviestBoxNo(warehouse);
            Console.WriteLine("The heaviest box \n");
            Console.WriteLine(warehouse.Get(k).ToString());


            //The lightest box
            int l = LightestBoxNo(warehouse);
            Console.WriteLine("The lightest box \n");
            Console.WriteLine(warehouse.Get(l).ToString());
            Console.WriteLine();

            //Height of the heaviest box
            //int k = HeaviestBoxNo(warehouse, ref warehouseN);
            Console.WriteLine("Height of the heaviest box: {0, 7:f}", warehouse.Get(k).GetHeight());
            Console.WriteLine();

            //Max quantity of the heaviest boxes on the top of each other 
            Console.WriteLine("Max quantity of the heaviest boxes:  {0, 2:d}", warehouse.Get(k).GetQuantity());
            Console.WriteLine();

            //Required height of the shelves
            Console.WriteLine("Required height of the shelves:  {0, 7:f}", warehouse.Get(k).GetHeight() * warehouse.Get(k).GetQuantity());
            Console.WriteLine();

            //Warehouse warehouseN = new Warehouse();
            Form(warehouse, ref warehouseN, material);
            Console.WriteLine();
            Print(warehouseN);

            //Quantity of plastic boxes
            int packQuantity = MaterialQuantity(warehouse, material);
            if (packQuantity > 0)
            {
                Console.WriteLine("Quantity of plastic boxes: {0,2:d}", packQuantity);

                warehouseN.Sort();
                Console.WriteLine();
                Console.WriteLine("Sorted List acc. to the material type");
                Console.WriteLine();
                Print(warehouseN);
            }
            else Console.WriteLine("There are no plastic boxes\n");

            Console.ReadLine();
            Console.WriteLine("Program end!");
        }
    }
}
