using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColouringMap
{
    internal class Dmax
    {
        public void createCnf(int[,] arr) {
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);
            String line = "";
            String cnf = "";
            for (int i = 0; i < rowLength; i++)
            {
                //Color rules
                int num = i * 4;
                int redIndex = num + 1;
                int greenIndex = num + 2;
                int blueIndex = num + 3;
                int orangeIndex = num + 4;

                //Only one color - musi byc nadany jeden kolor
                line = line + (redIndex) + " " + +(greenIndex) + " " + (blueIndex) + " " + orangeIndex + " 0" + System.Environment.NewLine;
                //Color differenes - nie moze byc nadany rownoczesnie wiecej niz jeden koilor
                line = line + "-" + (redIndex) + " -" + (greenIndex) + " 0" + System.Environment.NewLine;
                line = line + "-" + (redIndex) + " -" + (blueIndex) + " 0" + System.Environment.NewLine;
                line = line + "-" + (redIndex) + " -" + (orangeIndex) + " 0" + System.Environment.NewLine;
                line = line + "-" + (greenIndex) + " -" + (blueIndex) + " 0" + System.Environment.NewLine;
                line = line + "-" + (greenIndex) + " -" + (orangeIndex) + " 0" + System.Environment.NewLine;
                line = line + "-" + (blueIndex) + " -" + (orangeIndex) + " 0" + System.Environment.NewLine;


                for (int j = i + 1; j < colLength; j++)
                {
                    //Rules neighbours
                    //Console.Write(string.Format("{0} ", arr[i, j]));
                    //Neighbour
                    if (arr[i, j] == 1) {
                        int neighbour = j * 4;
                        int redIndexNeigbour = neighbour + 1;
                        int greenIndexNeigbour = neighbour + 2;
                        int blueIndexNeigbour = neighbour + 3;
                        int orangeIndexNeigbour = neighbour + 4;
                        //Jezeli sa sasiadami nie moga miec takiego samego koloru
                        line = line + "-" + (redIndex) + " -" + (redIndexNeigbour) + " 0" + System.Environment.NewLine;
                        line = line + "-" + (greenIndex) + " -" + (greenIndexNeigbour) + " 0" + System.Environment.NewLine;
                        line = line + "-" + (blueIndex) + " -" + (blueIndexNeigbour) + " 0" + System.Environment.NewLine;
                        line = line + "-" + (orangeIndex) + " -" + (orangeIndexNeigbour) + " 0" + System.Environment.NewLine;
                    }
                }
                //Console.Write(Environment.NewLine);
                //Console.Write(string.Format("{0} ", line));
                //Console.Write(Environment.NewLine);
                cnf = cnf + line;
                line = "";
            }
            //Console.Write(Environment.NewLine);
            //Console.Write(cnf);
            int count = cnf.Split(System.Environment.NewLine).Length - 1;

            //Add header
            //Console.Write("arrr len " + arr.GetLength(0));

            cnf = "p cnf " + (arr.GetLength(0) * 4) +" " + (count-1) + System.Environment.NewLine + cnf;
            //Console.Write(Environment.NewLine);
            //Console.Write(count);

            FileStream fs = File.Create("C:/Users/Stanislaw/source/repos/ColouringMap/cnf.cnf");
            try
            {
                byte[] cnfByte = new UTF8Encoding(true).GetBytes(cnf);
                fs.Write(cnfByte);
                fs.Close();
            }
            catch (Exception e) {
                Console.Write("Exception");
            }
        }
    }
}
