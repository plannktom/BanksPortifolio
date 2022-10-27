using System;
using System.Globalization;
using BanksPortifolio.Entities;
using System.Collections.Generic;

namespace BanksPortifolio
{
    class Program
    { 
        static void Main(string[] args)
        {
            /*
            SAMPLE INPUT
            11/12/2020
            4
            2000000 PRIVATE 29/12/2025
            400000 PUBLIC 01/07/2020
            5000000 PUBLIC 02/01/2024
            3000000 PUBLIC 26/10/2023

            SAMPLE OUTPUT
            HIGHRISK
            EXPIRED
            MEDIUMRISK
            MEDIUMRISK
            */

            try
            {
                bool b;

                //Console.WriteLine("Please enter reference date MM-dd-yyyy.:");

                string referenceDate;

                do
                {
                    referenceDate = Console.ReadLine();

                    b = Functions.IsDateTime(referenceDate);

                    if (b == false)
                        Console.WriteLine("Reference date invalid, please enter again MM-dd-yyyy!");

                } while (b == false);

                //Console.WriteLine("Enter the number of trades.:");

                string numberOfTrades;

                do
                {
                    numberOfTrades = Console.ReadLine();

                    b = Functions.IsInteger(numberOfTrades);

                    if (b == false)
                        Console.WriteLine("Invalid number, please enter again the number of trades!");

                } while (b == false);

                //Console.WriteLine("Value | ClientSector | NextPaymentDate");
                List<Portfolio> portfolioList = new List<Portfolio>();

                for (int i = 1; i <= int.Parse(numberOfTrades); i++)
                {

                    string phrase = Console.ReadLine();
                    string[] words = phrase.Split(' ');

                    double value;
                    string clientSector;
                    string nextPaymentDate;

                    do
                    {
                        value = double.Parse(words[0], CultureInfo.InvariantCulture);

                        clientSector = words[1];

                        nextPaymentDate = words[2];

                        b = Functions.IsDateTime(nextPaymentDate);

                        if (b == false)
                            Console.WriteLine("Invalid date, please enter again!");

                    } while (b == false);

                    portfolioList.Add(new Portfolio(value, clientSector, DateTime.Parse(nextPaymentDate)));
                }

                Console.WriteLine("");
                foreach (Portfolio obj in portfolioList)
                {
                    Console.WriteLine(obj.ClassifiesCliente(false,//A trade shall be categorized as PEP if IsPoliticallyExposed is true
                                                            obj.Value,
                                                            obj.ClientSector,
                                                            obj.NextPaymentDate,
                                                            DateTime.Parse(referenceDate)
                                                            ));
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }


    }
}
