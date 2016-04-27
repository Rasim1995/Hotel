using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelClassLibrary;

namespace Debug
{
	public class Program
	{
		static void Main(string[] args)
		{
			
			
			try
			{
				
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.ReadKey();
		}

		static void PrintDictionary(Dictionary<string, object> dic)
		{
			
			foreach(KeyValuePair<string, object> item in dic)
			{
				Console.WriteLine(item.Key + ": " + item.Value);
			}
		}

        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
	}
}
