using System;

namespace Abducted
{
    class Program
    {
          static void Main(string[] args)
          {
            Game gm = new Game();
            gm.Greet();

            while (true)
            {
                gm.Display();
                gm.Ask();
                if (gm.DidLose())
                {
                    gm.Display();
                    Console.WriteLine("Oops! Game Over. Your friend has been abducted by the Aliens. Sorry!");
                    break;
                }
                else if (gm.DidWin())
                {
                    gm.Display();
                    Console.WriteLine("Yay, you saved your friend from being abducted!  Great job!");
                    break;
                }
            }
        }
    }
}
