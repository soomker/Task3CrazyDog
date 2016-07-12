using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3CrazyDog
{
    class CrazyDog
    {
        const string fileLogName = "Sharik.log";
        private int currScreenHeight;
        private int currScreenWidth;
        Random rnd = new Random();
        public CrazyDog(int screenHeight, int screenWidth)
        {
            currScreenHeight = screenHeight;
            currScreenWidth = screenWidth; 
        }

        public void StartMoving()
        {
            try
            {
                MoveDog(currScreenHeight, currScreenWidth);
            }
            catch (SharikOfWallException ex)
            {
                ConsoleKeyInfo key;
                Console.WriteLine(ex.Message);
                Console.WriteLine("To Show the history of moving press ENTER");
                if ((key = Console.ReadKey()).Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("HISTORY OF MOVING \n " + ex.HistoryOfMoving);
                }
                Console.ReadLine();
            }
        }

       private void MoveDog(int graneX, int graneY)
        {
            if (File.Exists(fileLogName)) File.Delete(fileLogName);
            int posX;
            int posY;
            while (true)
            {
                posX = rnd.Next(graneX +2);
                posY = rnd.Next(graneY +2);
                if (posX == graneX || posY == graneY || posX == 0 || posY == 0)
                {
                    File.AppendAllText(fileLogName, "WALL AT POSITION: " + posX.ToString() + "x" + posY.ToString()+"\n");
                    throw new SharikOfWallException("Ouch!!! There is the WALL!!! " + "WALL AT POSITION: " + posX.ToString() + "x" + posY.ToString(), GetHistory());
                }
                else
                {
                    Console.WriteLine("Sharik is here: X - " + posX + " Y - " + posY);
                    File.AppendAllText(fileLogName, "SHARIK WAS at POSITION: " + posX.ToString() + "x" + posY.ToString() + "\n");
                }
            }
            
        }
        private string GetHistory()
        {
            StringBuilder stBuild = new StringBuilder();
            string[] st = File.ReadAllLines(fileLogName);
            foreach (string s in st)
            {
                stBuild.AppendLine(s);
            }
            return stBuild.ToString();
        }
    }
}
