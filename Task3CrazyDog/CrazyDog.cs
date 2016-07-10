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
        Random rnd = new Random();
        public CrazyDog(int screenHeight, int screenWidth)
        {
            try
            {
                MoveDog(screenWidth, screenHeight);
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
        void MoveDog(int graneX, int graneY)
        {
            if (File.Exists("Sharik.log")) File.Delete("Sharik.log");
            int posX;
            int posY;
            while (true)
            {
                posX = rnd.Next(graneX +2);
                posY = rnd.Next(graneY +2);
                if (posX == graneX || posY == graneY || posX == graneX && posY == graneY)
                {
                    File.AppendAllText("Sharik.log","WALL AT POSITION: " + posX.ToString() + "x" + posY.ToString()+"\n");
                    throw new SharikOfWallException("Ouch!!! There is the WALL!!! " + "WALL AT POSITION: " + posX.ToString() + "x" + posY.ToString());
                }
                else
                {
                    Console.WriteLine("Sharik is here: X - " + posX + " Y - " + posY);
                    File.AppendAllText("Sharik.log", "SHARIK WAS at POSITION: " + posX.ToString() + "x" + posY.ToString() + "\n");
                }
            }
            
        }
    }
}
