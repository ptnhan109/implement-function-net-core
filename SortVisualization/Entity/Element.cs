using SortVisualization.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualization.Entity
{
    public class Element
    {
        public Point Start { get; set; }

        public Point End { get; set; }

        public int Value { get; set; }

        public Element(Point start, Point end, int value)
        {
            Start = start;
            End = end;
            Value = value;
        }

        public Element Clone() => new Element(Start, End, Value);

        public void Draw(Graphics graphic)
        {
            var pen = new Pen(Color.MediumOrchid, ArrayOptions.Width);
            graphic.DrawLine(pen, Start, End);
        }

        public void Eraser(Graphics graphic)
        {
            var pen = new Pen(Color.White, ArrayOptions.Width);
            graphic.DrawLine(pen, Start, End);
        }

        public void Selected(Graphics graphic)
        {
            var pen = new Pen(Color.MediumPurple, ArrayOptions.Width);
            graphic.DrawLine(pen, Start, End);
        }
    }
}
