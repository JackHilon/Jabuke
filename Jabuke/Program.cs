using System;
using System.Collections.Generic;

namespace Jabuke
{
    class Program
    {
        static void Main(string[] args)
        {

            // Jabuke problem
            // https://open.kattis.com/problems/jabuke
            // number of trees inside triangle area using coordinates


            List<int> myTriangle = EnterTriangle();

            var area = TriangleArea(myTriangle[0], myTriangle[1], myTriangle[2],
                                     myTriangle[3], myTriangle[4], myTriangle[5]);

            var treesCount = EnterNumberOfTrees();

            var sum = NumOfTreesInside(treesCount, myTriangle, area);

            PrintResult(area, sum);
        }// -- end main --

        private static int NumOfTreesInside(int treesCount, List<int> myTriangle, double area)
        {
            int[] point = new int[2];
            int sum = 0;
            for (int i = 0; i < treesCount; i++)
            {
                point = EnterCoordinates();
                if (PointCheck(point, myTriangle, area) == true)
                    sum = sum + 1;
            }
            return sum;
        }

        private static List<int> EnterTriangle()
        {
            List<int> triangle = new List<int>();
            int[] vertex = new int[2];
            for (int i = 0; i < 3; i++)
            {
                vertex = EnterCoordinates();
                triangle.Add(vertex[0]);
                triangle.Add(vertex[1]);
            }
            return triangle;
        }

        private static void PrintResult(double area, int num)
        {
            Console.WriteLine(String.Format("{0:0.0}", area));
            Console.WriteLine(num);
        }

        private static bool PointCheck(int[] point, List<int> t, double tArea)
        {
            var a1 = TriangleArea(point[0], point[1], t[2], t[3], t[4], t[5]);
            var a2 = TriangleArea(t[0], t[1], point[0], point[1], t[4], t[5]);
            var a3 = TriangleArea(t[0], t[1], t[2], t[3], point[0], point[1]);
            if (a1 + a2 + a3 == tArea)
                return true; // point is inside triangle.
            else
                return false;
        }

        private static double TriangleArea(int xa, int ya, int xb, int yb, int xc, int yc)
        {
            var first = xa * (yb - yc);
            var second = xb * (yc - ya);
            var third = xc * (ya - yb);

            var result =(double) (Math.Abs((double) (first + second + third))) / 2;
            return result;
        }
        private static int[] EnterCoordinates()
        {
            string[] strArr = new string[2] { " ", " "};
            int[] res = new int[2] { 0, 0 };
            try
            {
                strArr = Console.ReadLine().Split(' ', 2);
                if (strArr.Length != 2)
                    throw new FormatException();
                res[0] = int.Parse(strArr[0]);
                res[1] = int.Parse(strArr[1]);
                if(Conditions(res[0], res[1]) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return EnterCoordinates();
            }
            return res;
        }
        private static bool Conditions(int a, int b)
        {
            if (a < 0 || a > 1000 || b < 0 || b > 1000)
                return false;
            else
                return true;
        }
        private static int EnterNumberOfTrees()
        {
            int res = 0;
            string str = " ";
            str = Console.ReadLine();
            try
            {
                res = int.Parse(str);
                if (res<= 0 || res >100)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return EnterNumberOfTrees();
            }
            return res;
        }
    }
}
