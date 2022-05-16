using System;
using System.Drawing;

namespace DomainModel
{
    public class Element
    {
        public int PosX1 { get; set; }

        public int PosY1 { get; set; }

        public int PosX2 { get; set; }

        public int PosY2 { get; set; }

        public bool IsLastElement { get; set; }

        public bool IsFillNull { get; set; }

        public bool IsErased { get; set; }

        public string TypeOfElement { get; set; }

        public Color BorderColor { get; set; }
        public String BorderColorName { get; set; }

        public Color FillColor { get; set; }
        public String FillColorName { get; set; }

        public float Width { get; set; }

        public Element()
        {
            IsFillNull = true;
            IsErased = false;
            Width = 1;
            BorderColor = Color.Black;
            FillColor = Color.White;
        }

        public virtual void UpdateOnMouseMove(int x, int y)
        {
        }

        public virtual void Draw(Graphics g, Pen pen)
        {
        }
    }
}
