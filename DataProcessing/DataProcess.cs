using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using QuantModel.Class;

namespace QuantModel.DataProcessing
{
    public class DataProcess
    {
        private const int Open = 1;
        enum Data
        {
            DataTime,
            Open,
            High,
            Low,
            Close,
            Volume,
            OpenInterest
        }
        private FileStream Fs { get; }
        private StreamReader Sr { get; }

        public DataProcess(string FileName)
        {
            Fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            Sr = new StreamReader(Fs);
        }

        public Dumb<double> GetOpen()
        {
            return GetSource(Open);
        }

        public Dumb<double> GetClose()
        {
            return GetSource((int) Data.Close);
        }

        public Dumb<double> GetSource(int Type)
        {
            string Line;
            var Source = new Dumb<Double>();
            Source.FollowUp();
            List<string> List1 = new List<string>();
            while ((Line = Sr.ReadLine()) != null)
            {
                string[] Temp = Line.Split(',');
                Source.Add(Double.Parse(Temp[Type]));
            }
            return Source;
        }
    }
}