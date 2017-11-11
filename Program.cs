using System;
using System.IO;
using System.Xml.Xsl.Runtime;
using QuantModel.Class;
using QuantModel.DataProcessing;

namespace QuantModel
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var DataPorcessing = new DataProcess("/Users/renhaoran/RiderProjects/MasterResearch/QuantModel/DataProcessing/Data.txt");
            //var Close = DataPorcessing.GetClose();
            var Close = new Dumb<double>();
            var macd = Close.MACD(12, 26, 9);
            var l = Close.GetNexts();
            Close.AddRange(1, 2, 3, 4, 5, 6);
            Close.PrintTree();
            Console.WriteLine("hello world");
        }
    }
}