using System;

public class Program
{
	// Fields
	// Constructor
	// Methods
	public static void Main()
	{
		Console.WriteLine("Starting Coin Flipper:");
		
		Console.WriteLine("Enter the number of coins to flip: ");
		
		string UserNumber = Console.ReadLine();
		int Num = 0;
		
		try
		{
			Num = Int32.Parse(UserNumber);
		}
		catch( InvalidOperationException e )
		{
			Console.WriteLine("A less specific catch: " + e.Message);
		}
		catch( ArgumentException e)
		{
			Console.WriteLine(e.Message);
		}
		catch
		{
			Console.WriteLine("The least specific catch");
		}
		
		
		
		var rand = new Random();
		
		for (int i = 0; i < Num; i++)
		{
			int coin = rand.Next(2);

			if (coin == 0)
			{
				Console.WriteLine("Heads");	
			}
			else
			{
				Console.WriteLine("Tails");
			}
		}
	}
}