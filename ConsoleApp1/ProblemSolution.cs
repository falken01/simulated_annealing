using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ProblemSolution
    {
        public List<double> solution { get; set; }
        public TimeSpan duration { get; set; }
        public ProblemSolution(List<double> solution, TimeSpan duration)
        {
            this.solution = solution;
            this.duration = duration;
        }
    }
}
