using System;
using System.Drawing;

namespace DomainModel
{
    public class Rectangle : Element
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
                g.DrawRectangle(pen, PosX2, PosY2, Math.Abs(PosX1 - PosX2), Math.Abs(PosY1 - PosY2));

                if (IsFillNull == false)
                    g.FillRectangle(brush, PosX2, PosY2, Math.Abs(PosX1 - PosX2), Math.Abs(PosY1 - PosY2));

                if(IsErased == true)
                    g.FillRectangle(clearbrush, PosX2, PosY2, Math.Abs(PosX1 - PosX2), Math.Abs(PosY1 - PosY2));
            }

            else if(PosX1 <= PosX2 && PosY1 >= PosY2)
            {
                g.DrawRectangle(pen, PosX1, PosY2, Math.Abs(PosX2 - PosX1), Math.Abs(PosY2 - PosY1));

                if (IsFillNull == false)
                    g.FillRectangle(brush, PosX1, PosY2, Math.Abs(PosX2 - PosX1), Math.Abs(PosY2 - PosY1));

                if (IsErased == true)
                    g.FillRectangle(clearbrush, PosX1, PosY2, Math.Abs(PosX2 - PosX1), Math.Abs(PosY2 - PosY1));
            }

            else if (PosX1 >= PosX2 && PosY1 <= PosY2)
            {
                g.DrawRectangle(pen, PosX2, PosY1, Math.Abs(PosX2 - PosX1), Math.Abs(PosY2 - PosY1));

                if (IsFillNull == false)
                    g.FillRectangle(brush, PosX2, PosY1, Math.Abs(PosX2 - PosX1), Math.Abs(PosY2 - PosY1));

                if (IsErased == true)
                    g.FillRectangle(clearbrush, PosX2, PosY1, Math.Abs(PosX2 - PosX1), Math.Abs(PosY2 - PosY1));
            }

            else
            {
                g.DrawRectangle(pen, PosX1, PosY1, Math.Abs(PosX2 - PosX1), Math.Abs(PosY2 - PosY1));

                if (IsFillNull == false)
                    g.FillRectangle(brush, PosX1, PosY1, Math.Abs(PosX2 - PosX1), Math.Abs(PosY2 - PosY1));

                if (IsErased == true)
                    g.FillRectangle(clearbrush, PosX1, PosY1, Math.Abs(PosX2 - PosX1), Math.Abs(PosY2 - PosY1));
            }
        }

        public Rectangle()
        {

        }
    }
}
