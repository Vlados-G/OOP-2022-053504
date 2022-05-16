using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using DomainModel;

namespace MVC
{
    public class AppController
    {
        private AppModel appModel = null;

        private DomainModel.DomainModel domainModel = null;

        private AppView view = null;

        public String PluginPath = "D:\\Plugin.dll";
        private bool CheckLastFlag { get; set; }
        
        public AppController(AppModel appModel, DomainModel.DomainModel domainModel, AppView view)
        {
            this.appModel = appModel;
            this.domainModel = domainModel;
            this.view = view;
        }

        public void Initialize()
        {
            appModel.Initialize();
        }

        public void LoadPlugin()
        {
            Assembly a = Assembly.LoadFrom(PluginPath);

            Type[] type = a.GetTypes();
            Type ourtype = typeof(Element);

            foreach (var t in type)
            {
                if (t.IsSubclassOf(ourtype))
                {
                    domainModel.TypeList.Add(t);
                }
            }
        }

        public void NewFile()
        {
            appModel.Initialize();
            domainModel.Elements.Clear();
            view.Update();
        }

        public void MouseDown(int x, int y)
        {
            appModel.IsMouseDown = true;

            if (appModel.CurrentElement != null && appModel.IsCurrentElementActive == false)
            {
                appModel.IsCurrentElementActive = true;

                appModel.CurrentElement.PosX1 = x;
                appModel.CurrentElement.PosY1 = y;
                appModel.CurrentElement.PosX2 = x;
                appModel.CurrentElement.PosY2 = y;
            }

            view.Update();
        }

        public void MouseMove(int x, int y)
        {
            appModel.CursorPositionX = x;
            appModel.CursorPositionY = y;

            if (appModel.CurrentElement != null && appModel.IsCurrentElementActive == true)
            {
                if (appModel.IsFillActive == true)
                    appModel.CurrentElement.IsFillNull = false;

                // Erase current element on old position




                // Re-draw current element on new position

                appModel.CurrentElement.UpdateOnMouseMove(x, y);
//                appModel.CurrentElement.Draw(domainModel.Graphics, pen);
            }

        }

        public void MouseUp()
        {
            appModel.IsMouseDown = false;

            // If we were drawing with some tool - let's save it on the picture
            if (appModel.CurrentElement != null && appModel.IsCurrentElementActive == true)
            {
                appModel.IsCurrentElementActive = false;

                foreach (var element in domainModel.Elements)
                {
                    if (element.IsLastElement == true)
                    {
                        CheckLastFlag = true;
                        continue;
                    }

                    if(CheckLastFlag == true)
                    {
                        domainModel.Elements.RemoveRange(domainModel.Elements.IndexOf(element), domainModel.Elements.Count - domainModel.Elements.IndexOf(element));
                        break;
                    }
                }

                CheckLastFlag = false;
                appModel.CurrentElement.BorderColorName = appModel.CurrentElement.BorderColor.Name;
                appModel.CurrentElement.FillColorName = appModel.CurrentElement.FillColor.Name;
                domainModel.Elements.Add(appModel.CurrentElement);
                domainModel.CheckLastElement();
//                domainModel.DrawElements();
                view.Update();

                // Create new element
                var type = appModel.CurrentElement.GetType();
                appModel.CurrentElement = null;

                appModel.CurrentElement = (Element)Activator.CreateInstance(type);
                appModel.CurrentElement.PosX1 = appModel.CursorPositionX;
                appModel.CurrentElement.PosY1 = appModel.CursorPositionY;
                appModel.CurrentElement.BorderColor = appModel.CurrentDrawingColor;
                appModel.CurrentElement.FillColor = appModel.CurrentFillColor;
                appModel.CurrentElement.Width = appModel.CurrentWidth;
                appModel.CurrentElement.TypeOfElement = type.ToString();

            }

            view.Update();
        }

        public void SaveFile(String fileName)
        {
            domainModel.Serialize(domainModel.Elements, fileName);
        }

        public void OpenFile(String fileName)
        {
            appModel.Initialize();
            domainModel.Elements.Clear();

            domainModel.Elements = domainModel.Deserialize(fileName);
            view.Update();
        }

        public void Undo()
        {
            if (domainModel.Elements.Count != 0)
            {
                var firstElement = domainModel.Elements.First();

                Pen pen = new Pen(Color.White);

                foreach (var element in domainModel.Elements)
                {
                    pen.Width = element.Width;

                    if (element.IsLastElement == true)
                    {
                        if (element.Equals(firstElement))
                        {
                            element.IsErased = true;
                            element.Draw(domainModel.Graphics, pen);
                            return;
                        }

                        else
                        {
                            domainModel.Elements[domainModel.Elements.IndexOf(element) - 1].IsLastElement = true;
                            element.IsLastElement = false;

                            element.IsErased = true;
                            element.Draw(domainModel.Graphics, pen);

                            return;
                        }
                    }
                }
            }
            view.Update();
        }   

        public void Redo()
        {
            if (domainModel.Elements.Count != 0)
            {
                var firstElement = domainModel.Elements.First();
                var lastElement = domainModel.Elements.Last();

                Pen pen = new Pen(Color.White);

                foreach (var element in domainModel.Elements)
                {
                    pen.Color = element.BorderColor;
                    pen.Width = element.Width;

                    if (element.IsLastElement == true)
                    {
                        if (element.Equals(firstElement) && element.IsErased == true)
                        {
                            element.IsErased = false;
                            element.Draw(domainModel.Graphics, pen);

                            element.IsLastElement = false;
                            domainModel.Elements[domainModel.Elements.IndexOf(element) + 1].IsLastElement = true;

                            return;
                        }

                        if (element.Equals(lastElement))
                        {
                            element.IsErased = false;
                            element.Draw(domainModel.Graphics, pen);

                            return;
                        }

                        else
                        {
                            element.IsErased = true;
                            element.Draw(domainModel.Graphics, pen);

                            element.IsLastElement = false;
                            domainModel.Elements[domainModel.Elements.IndexOf(element) + 1].IsLastElement = true;

                            return;
                        }
                    }
                }
            }
            view.Update();
        }

        public void CreateNewElement(string newElement)
        {
            foreach (var type in domainModel.TypeList)
            {
                if(newElement == type.ToString())
                {
                    var element = (Element)Activator.CreateInstance(type);
                    element.PosX1 = appModel.CursorPositionX;
                    element.PosY1 = appModel.CursorPositionY;
                    element.TypeOfElement = element.GetType().ToString();
                    element.BorderColor = appModel.CurrentDrawingColor;
                    element.FillColor = appModel.CurrentFillColor;
                    element.Width = appModel.CurrentWidth;
                    appModel.CurrentElement = element;
                }
            }
        }

        public void DrawByCoordinates(string newElement, int x1, int y1, int x2, int y2)
        {
            foreach (var type in domainModel.TypeList)
            {
                if (newElement == type.ToString())
                {
                    var element = (Element)Activator.CreateInstance(type);
                    element.PosX1 = x1;
                    element.PosY1 = y1;
                    element.TypeOfElement = element.GetType().ToString();
                    element.PosX2 = x2;
                    element.PosY2 = y2;
                    element.BorderColor = appModel.CurrentDrawingColor;

                    if (appModel.IsFillActive == true)
                        element.IsFillNull = false;

                    element.FillColor = appModel.CurrentFillColor;
                    element.Width = appModel.CurrentWidth;

                    domainModel.Elements.Add(element);
                    domainModel.CheckLastElement();
//                    domainModel.DrawElements();
                    view.Update();

                }
            }

        }

        public void SetMainColor(string color)
        {
            appModel.CurrentDrawingColor = Color.FromName(color); 
        }

        public void SetFillColor(string backgroudcolor)
        {
            if(backgroudcolor != "Null")
            {
                appModel.IsFillActive = true;
                appModel.CurrentFillColor = Color.FromName(backgroudcolor);
            }

            else
                appModel.IsFillActive = false;
        }

        public void SetWidth(float width)
        {
            appModel.CurrentWidth = width;
        }
    }
}
