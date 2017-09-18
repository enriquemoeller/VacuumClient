using System;
using IntelligentVacuum.Environments;
using IntelligentVacuum.Agent;
using IntelligentVacuum.Client;

namespace IntelligentVacuum
{
    class Program
    {
        static void Main(string[] args)
        {
            int iXAxis;
            int iYAxis;
            Console.WriteLine("Please enter the lenght of the X axis:");
            var xAxis = Console.ReadLine();
            int.TryParse(xAxis, out iXAxis);
            Console.WriteLine("Please enter the lenght of the Y axis:");
            var yAxis = Console.ReadLine();
            int.TryParse(yAxis, out iYAxis);
            var client = new Client.Client();
            client.init(iXAxis, iYAxis);
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
