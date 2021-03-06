﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppgift_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int datorNumber = rnd.Next(1, 100);
            int attemptCounter = 0;
			Console.WriteLine("gissa vilket tal datorn har valt det är mellan 1 och 100.");
            bool guesTrue = false;
			while (!guesTrue)
			{
				string inputString = Console.ReadLine();
				if (!int.TryParse(inputString, out int inputInt))
				{
					Console.WriteLine("invalid input");
				}
				else
				{
					attemptCounter++;
					if (inputInt == datorNumber)
					{
						guesTrue = true;
						Console.WriteLine("Du gissade rätt!");
						Console.WriteLine("Du gjorde det på: " + attemptCounter + " försök");
					}
					else
					{
						if (inputInt < datorNumber)
						{
							Console.WriteLine("Ditt tal är för litet");
						}
						else if (inputInt > datorNumber)
						{
							Console.WriteLine("Ditt tal är för stort");
						}
						Console.WriteLine("Försök igen");
					}
				}
			}
			Console.ReadLine();
        }
    }
}
