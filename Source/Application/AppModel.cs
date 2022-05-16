using System;
using System.Drawing;
using DomainModel;

namespace MVC
{
    public class AppModel
    {
        public String FileName { get; set; }

        public int CursorPositionX { get; set; }

        public int CursorPositionY { get; set; }

        public Boolean IsMouseDown { get; set; }

        public Element CurrentElement { get; set; }

        public Boolean IsCurrentElementActive { get; set; }

        public Color CurrentDrawingColor { get; set; }

        public bool IsFillActive { get; set; }

        public Color CurrentFillColor { get; set; }

        public float CurrentWidth { get; set; }


        public void Initialize()
        {
            IsMouseDown = false;
            CurrentElement = null;
            IsCurrentElementActive = false;
            FileName = "C:/Temp/SerializedPicture.json";
            CursorPositionX = 0;
            CursorPositionY = 0;
            CurrentDrawingColor = Color.Black;
            CurrentFillColor = Color.White;
            CurrentWidth = 1;
        }
    }
}
