using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SimulatedAnnealing
    {
        private int Iterations { get; set; }
        private double Temp { get; set; }
        private double Alpha { get; set; }
        private Random rand { get; set; }

        public SimulatedAnnealing(int iterations, double temp, double alpha) {
            this.Iterations = iterations;
            this.Temp = temp;
            this.Alpha = alpha;
            this.rand = new Random();
        }

        public double easom(double x1, double x2) {
            return -Math.Cos(x1) * Math.Cos(x2) * Math.Exp(-Math.Pow((x1 - Math.PI),2) - Math.Pow(x2 - Math.PI,2));            
        }

        public List<double> shift1(double x1, double x2)
        {
            double temp = this.Temp;
            double delta1 = temp * (this.rand.NextDouble() * (1 - (-1)) - 1);
            double delta2 = temp * (this.rand.NextDouble() * (1 - (-1)) - 1);
            double xnew = x1 + delta1;
            double xprev = x2 + delta2;
            double easom_value = this.easom(xnew, xprev);
            List<double> vals = new List<double>() { easom_value, xnew, xprev };
            return vals;
        }

        public double get_difference(double new_soultion, double current_solution)
        {
            return new_soultion - current_solution;
        }

        public List<double> get_random_solution()
        {
            double x1 = (this.rand.NextDouble() * (100 - (-100)) - 100);
            double x2 = (this.rand.NextDouble() * (100 - (-100)) - 100);
            double easom_value = this.easom(x1, x2);
            List<double> vals = new List<double>() { easom_value, x1, x2 };
            return vals;
        }
        public List<double> get_probability(List<double> point1, List<double> point2)
        {
            double temp = this.Temp;
            double prob = rand.NextDouble();
            double delta = this.get_difference(point1[0], point2[0]);
            if(prob < Math.Exp(-delta/temp))
            {
                return point1;
            } else
            {
                return point2;
            }
        }

        public ProblemSolution get_solution()
        {
            DateTime start = DateTime.Now;
            List<double> randomPoint = this.get_random_solution();
            double temp = this.Temp;
            for(int i = 0; i < this.Iterations; i++)
            {
                List<double> randomNew = this.shift1(randomPoint[1], randomPoint[2]);

                if (randomPoint[0] > randomNew[0])
                {
                    randomPoint = randomNew;
                }
                else
                {
                    randomPoint = this.get_probability(randomPoint, randomNew);
                }

                temp *= this.Alpha;

            }
            TimeSpan duration = DateTime.Now - start;
            ProblemSolution solved = new ProblemSolution(randomPoint, duration);

            return solved;
        }
    }
}
