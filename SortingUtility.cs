using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SortingUtility
    {
        public static void BubbleSort(List<int> numbers)
        {
            //List<int> numbers = new List<int> { 34, 12, 4, 90, 89, 1 };
            bool swapped;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < numbers.Count - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}
