using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DomainModel
{
    public class Line: Element
    {
        public override void UpdateOnMouseMove(int x, int y)
        {
            PosX2 = x;
            PosY2 = y;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            g.DrawLine(pen, PosX1, PosY1, PosX2, PosY2);
        }

        public Line()
        {

        }

    }
}
