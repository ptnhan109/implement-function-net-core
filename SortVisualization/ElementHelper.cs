using SortVisualization.Entity;
using SortVisualization.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortVisualization
{
    public class ElementHelper
    {
        public static void DrawSwap(Element first, Element second, Graphics graphic)
        {
            var firstClone = first.Clone();
            var secondClone = second.Clone();
            int temporary = firstClone.End.Y;

            //show selected
            firstClone.Selected(graphic);
            secondClone.Selected(graphic);
            Thread.Sleep(ArrayOptions.Delayed);
            // eraser
            firstClone.Eraser(graphic);
            secondClone.Eraser(graphic);

            // swap
            firstClone.End = new Point(firstClone.End.X, second.End.Y);
            secondClone.End = new Point(secondClone.End.X, temporary);

            // redraw

            firstClone.Draw(graphic);
            secondClone.Draw(graphic);

        }

        public static void ElementSwap(List<Element> elements, int first, int second)
        {
            // swap location
            var temporary = elements[first].End.Y;
            elements[first].End = new Point(elements[first].End.X, elements[second].End.Y);
            elements[second].End = new Point(elements[second].End.X, temporary);

            // swap value
            var tempValue = elements[first].Value;
            elements[first].Value = elements[second].Value;
            elements[second].Value = tempValue;
        }

        public static void CompletedList(List<Element> elements, Graphics graphic)
        {

            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Selected(graphic);
                Thread.Sleep(1);
            }
        }
    }
}
