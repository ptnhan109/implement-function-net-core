using SortVisualization.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualization.Algorithms
{
    public class QuickSort
    {
        public static int Partition(List<Element> elements, int left, int right, Graphics graphic)
        {
            var pivot = elements[left];
            while (true)
            {
                // get start
                while(elements[left].Value < pivot.Value)
                {
                    left++;
                }

                // get end
                while(elements[right].Value > pivot.Value)
                {
                    right--;
                }

                if(elements[right].Value == pivot.Value && elements[left].Value == pivot.Value)
                {
                    left++;
                }

                if(left < right)
                {
                    ElementHelper.DrawSwap(elements[left], elements[right], graphic);
                    ElementHelper.ElementSwap(elements, left, right);
                }
                else
                {
                    return right;
                }
            }
        }

        public static void QuickSortAlgorithm(List<Element> elements, int left, int right, Graphics graphic)
        {
            if(left < right)
            {
                int pivotIndex = Partition(elements, left, right, graphic);
                
                if(pivotIndex > 1)
                {
                    QuickSortAlgorithm(elements, left, pivotIndex - 1, graphic);
                }

                if(pivotIndex + 1 < right)
                {
                    QuickSortAlgorithm(elements, pivotIndex + 1, right, graphic);
                }

            }
        }
    }
}
