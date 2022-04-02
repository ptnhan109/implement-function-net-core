using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualization.Options
{
    public class PenOptions
    {
        public static Pen White() => new Pen(Color.White, ArrayOptions.Width);

        public static Pen Blue() => new Pen(Color.Aqua, ArrayOptions.Width);

        public static Pen MediumOrchid() => new Pen(Color.MediumOrchid, ArrayOptions.Width);

        public static Pen MediumPurple() => new Pen(Color.MediumPurple, ArrayOptions.Width);
    }
}
