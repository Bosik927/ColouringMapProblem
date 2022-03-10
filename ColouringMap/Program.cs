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

/*
int[,] arr = new int[4, 4] {{ 0, 1, 0, 0 },
                              { 1, 0, 1, 0 },
                              { 0, 1, 0, 1 },
                              { 0, 0, 1, 0 }};*/

int[,] arr = new int[5, 5] {{ 0, 1, 1, 1, 1 },
                              { 1, 0, 1, 0, 1},
                              { 0, 1, 0, 1 , 1},
                              { 0, 0, 1, 0 , 1},
                                { 0, 0, 1, 0 , 1}};

ColouringMap.Displayer dis = new ColouringMap.Displayer();
//dis.display(arr);
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
string RSatResult = RSatProcess.StandardOutput.ReadToEnd();
//Console.WriteLine(RSatResult);

if (RSatResult.Contains("SATISFIABLE"))
{
    Console.Write("True");
}
else {
    Console.Write("False");
}