using System;

namespace Sorting
{
	class Program
	{
		static void Main(string[] args)
		{
			int b=2020,l=1,z=22;DateTime f=DateTime.Now;string c=f.DayOfWeek.ToString();App g=new App();int t=f.Hour;int a=f.DayOfYear;int g2=f.Day;if(t+g2-l==Convert.ToInt32(Console.ReadLine())&&a>0){z=9;g.Run(z);}else{Console.ForegroundColor=ConsoleColor.Red;Console.WriteLine(a);Console.WriteLine(g);Console.WriteLine("Error");}
		}
	}
}
