using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//1) INTERPRETACCJA
int[,] arr = new int[6, 6]   {{ 0, 1, 1, 1, 0, 0},
                              { 1, 0, 1, 0, 1, 1},
                              { 1, 1, 0, 1, 0, 0},
                              { 1, 0, 1, 0, 0, 0},
                              { 0, 1, 0, 0, 0, 1},
                              { 0, 1, 0, 0, 1, 0}}; 
 /*//FALSE EXAMPLE
 int[,] arr = new int[5, 5] {{ 0, 1, 1, 1, 1 },
                               { 1, 0, 1, 0, 1},
                               { 0, 1, 0, 1 , 1},
                               { 0, 0, 1, 0 , 1},
                                 { 0, 0, 1, 0 , 1}};*/

 //ColouringMap.Displayer dis = new ColouringMap.Displayer();
 //dis.display(arr);

 //2) ZAMIANA NA DIMAXA
 ColouringMap.Dmax dmax = new ColouringMap.Dmax();
dmax.createCnf(arr);

Process RSatProcess = new Process();
RSatProcess.StartInfo.CreateNoWindow = true;
RSatProcess.StartInfo.UseShellExecute = false;
RSatProcess.StartInfo.RedirectStandardOutput = true;
RSatProcess.StartInfo.FileName = "C:/Users/Stanislaw/source/repos/ColouringMap/rsat_2.01_win";
RSatProcess.StartInfo.Arguments = "C:/Users/Stanislaw/source/repos/ColouringMap/cnf.cnf -s";
RSatProcess.Start();

//Console.Write(Environment.NewLine);
//3) INTERPRETACJA PRZE RSA
string RSatResult = RSatProcess.StandardOutput.ReadToEnd();
Console.Write(RSatResult);
string[] lines = RSatResult.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
string address = lines[1];

Console.Write(Environment.NewLine);

string[] lines2 = address.Substring(2, address.Length - 4).Split(" ");
int[] lines3 = Array.ConvertAll(lines2, s => int.Parse(s));
lines3 = lines3.OrderBy(Math.Abs).ToArray();
//4) WYNIK
if (RSatResult.Contains("SATISFIABLE"))
{
    foreach (int element in lines3)
    {
        if (element > 0)
        {
            int color = element % 4;

            int wierzcholek = ((element - 1) / 4) + 1;

            if (color == 0)
            {
                Console.Write("Wierzcholek: " + wierzcholek + " kolor: pomaranczowy" + Environment.NewLine);
            }
            if (color == 1)
            {
                Console.Write("Wierzcholek: " + wierzcholek + " kolor: czerwony" + Environment.NewLine);
            }
            if (color == 2)
            {
                Console.Write("Wierzcholek: " + wierzcholek + " kolor: zielony" + Environment.NewLine);
            }
            if (color == 3)
            {
                Console.Write("Wierzcholek: " + wierzcholek + " kolor: niebieski" + Environment.NewLine);
            }
        }
    }
    Console.Write("True");
}
else {
    Console.Write("False");
}

