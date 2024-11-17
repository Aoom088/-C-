using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulationBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"A class that implements a box.");
            Box box1 = new Box(0.5, 0.1, 0.2);
            Box cubeox1 = new Box(1);
            Box oldbox = box1;
            Console.WriteLine($"area box1(0.5, 0.1, 0.2) = {box1.area()}");
            Console.WriteLine($"area cubeox1(1) = {cubeox1.area()}");
            Console.WriteLine($"area oldbox = box1 = {oldbox.area()}");
            Console.Write($"Enter...");
            Console.ReadKey();
        }
    }

    class Box
    {

        public double width, height, length, side;
        public Box oldBox;

        public Box(double width, double height, double length)
        {
            this.width = width;
            this.height = height;
            this.length = length;
        }
        public Box(double side)
        {
            this.width = side;
            this.height = side;
            this.length = side;
        }
        public Box(Box oldBox)
        {
            this.oldBox = oldBox;
        }
        public double area()
        {
            return 2 * faceArea() + 2 * topArea() + 2 * sideArea();
        }

        double faceArea()
        {
            return this.width * this.height;
        }
        double topArea()
        {
            return this.width * this.length;
        }
        double sideArea()
        {
            return this.height * this.length;
        }
    }
}

