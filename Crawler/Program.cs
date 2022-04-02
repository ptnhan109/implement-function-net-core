using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var questions =  Processor.GetQuestions();
            Console.ReadKey();
        }
    }
}
