using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Task3CrazyDog
{
    class Program
    {
         
        static void Main(string[] args)
        {
           //Size of the screen
            Rectangle screenSize = Screen.PrimaryScreen.Bounds;
            CrazyDog dog = new CrazyDog(screenSize.Height, screenSize.Width);
        }
    }
}
