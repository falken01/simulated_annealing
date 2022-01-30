using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 1;
            double temp = 100;
            double alpha = 0.9;
            try
            {
                Console.WriteLine("Podaj ilosc iteracji: ");
                iterations = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj temperature: ");
                temp = double.Parse(Console.ReadLine());
                Console.WriteLine("Podaj zmiane temperatury ( ulamek z zakresu od 0,8 do 0,99) : ");
                alpha = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Wprowadzono nieprawidłowe wartości {0}", e);
                return;
                
            }
            SimulatedAnnealing sa = new SimulatedAnnealing(iterations, temp, alpha);
            var solution = sa.get_solution();
            Console.WriteLine("Wybrane parametry: ");
            Console.WriteLine("Ilosc iteracji: {0}", iterations);
            Console.WriteLine("Temperatura: {0}", temp);
            Console.WriteLine("Zmiana temperatury: {0}", alpha);
            Console.WriteLine("Minimum globalne Easoma to: {0}", solution.solution[1]);
            Console.WriteLine("W punktach x1 =  {0}, x2 = {1}", solution.solution[1], solution.solution[2]);
            Console.WriteLine("Znalezione w czasie: {0}", solution.duration);
        }
    }
}
