using System;
using System.Drawing;
using DomainModel;

namespace Plugin
{
    public class Triangle : Element
    {
        public override void UpdateOnMouseMove(int x, int y)
        {
            PosX2 = x;
            PosY2 = y;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            SolidBrush brush = new SolidBrush(FillColor);
            SolidBrush clearbrush = new SolidBrush(Color.White);

            if (PosX1 >= PosX2 && PosY1 >= PosY2)
            {
                Point[] points = new Point[] { new Point { X = PosX2, Y = PosY1 }, new Point { X = PosX1 - (PosX1 - PosX2) / 2, Y = PosY2 }, new Point { X = PosX1, Y = PosY1 } };
                g.DrawPolygon(pen, points);

                if (IsFillNull == false)
                    g.FillPolygon(brush, points);

                if (IsErased == true)
                    g.FillPolygon(clearbrush, points);
            }

            else if (PosX1 <= PosX2 && PosY1 >= PosY2)
            {
                Point[] points = new Point[] { new Point { X = PosX1, Y = PosY1 }, new Point { X = PosX1 + (PosX2 - PosX1) / 2, Y = PosY2 }, new Point { X = PosX2, Y = PosY1 } };
                g.DrawPolygon(pen, points);

                if (IsFillNull == false)
                    g.FillPolygon(brush, points);

                if (IsErased == true)
                    g.FillPolygon(clearbrush, points);
            }

            else if (PosX1 >= PosX2 && PosY1 <= PosY2)
            {
                Point[] points = new Point[] { new Point { X = PosX2, Y = PosY2 }, new Point { X = PosX1 - (PosX1 - PosX2) / 2, Y = PosY1 }, new Point { X = PosX1, Y = PosY2 } };
                g.DrawPolygon(pen, points);

                if (IsFillNull == false)
                    g.FillPolygon(brush, points);

                if (IsErased == true)
                    g.FillPolygon(clearbrush, points);
            }

            else
            {
                Point[] points = new Point[] { new Point { X = PosX1, Y = PosY2 }, new Point { X = PosX1 + (PosX2 - PosX1) / 2, Y = PosY1 }, new Point { X = PosX2, Y = PosY2 } };
                g.DrawPolygon(pen, points);

                if (IsFillNull == false)
                    g.FillPolygon(brush, points);

                if (IsErased == true)
                    g.FillPolygon(clearbrush, points);
            }
        }

        public Triangle()
        {

        }
    }
}
