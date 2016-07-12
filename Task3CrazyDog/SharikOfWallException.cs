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
       
        public string HistoryOfMoving { get; private set; }
        public SharikOfWallException(string message, string history) : base(message)
        {
            HistoryOfMoving = history;
        }
    }
}
