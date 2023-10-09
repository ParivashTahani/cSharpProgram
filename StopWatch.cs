using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class StopWatch
    {
        private DateTime _start;
        private DateTime _stop;
        private TimeSpan _elapsed;
        private bool _running;

        public void Start() 
        {
            if (_running)
            {
                throw new InvalidOperationException("Program is running!");
            }
            _start = DateTime.Now;
            _running = true;
        }
        public void Stop() 
        {
            if (!_running)
            {
                throw new InvalidOperationException("Program is running!");
            }
            _stop = DateTime.Now;
            _running = false;
        }
        public void Elapsed() 
        {
            if (_running)
            {
                throw new InvalidOperationException("Program is running!");
            }
            _elapsed = _stop - _start;
            Console.WriteLine("Time elapsed:" + _elapsed);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            StopWatch stopwatch = new StopWatch();
            while (true)
            {
                Console.WriteLine("Please enter one of them (start, stop, duration,quit)");
                string input = Console.ReadLine().ToLower();
                if (input == "start")
                {
                    stopwatch.Start();
                }
                else if (input == "stop")
                {
                    stopwatch.Stop();
                }
                else if (input == "duration")
                {
                    stopwatch.Elapsed();
                }
                else if (input == "quit")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please try again!");
                }
            }

        }

    }
}
