using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3CrazyDog
{
    class SharikOfWallException : Exception
    {
        string historyOfMoving;
        public string HistoryOfMoving { get { return historyOfMoving; } }
        public SharikOfWallException(string message) : base(message)
        {
           StringBuilder stBuild = new StringBuilder();
           string [] st = File.ReadAllLines("Sharik.log");
           foreach (string s in st)
           {
               stBuild.AppendLine(s);
           }
            historyOfMoving = stBuild.ToString();
        }
    }
}
