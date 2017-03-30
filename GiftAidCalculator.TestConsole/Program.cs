using System;

namespace GiftAidCalculator.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
            var taxRepo = new TaxRepository();
            var events = new Events();
            var giftAidCalculation = new GiftAidCalculation(taxRepo, events);

			// Calc Gift Aid Based on Previous
			Console.WriteLine("Please Enter donation amount:");
            var donationAmount = decimal.Parse(Console.ReadLine());
			Console.WriteLine($"Gift Aid Amount is : {giftAidCalculation.CalculateGiftAidAmount(donationAmount)}");
			Console.WriteLine("Press any key to exit.");
			Console.Read();
		}

		
	}
}
