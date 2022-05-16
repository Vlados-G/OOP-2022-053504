using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace DomainModel
{
    public class DomainModel
    {
        public List<Element> Elements { get; set; }
        public List<Type> TypeList { get; set; } 

        public Graphics Graphics { get; set; }

        public void Initialize(Graphics graphics)
        {
            Elements = new List<Element>();
            this.Graphics = graphics;

            Type ourtype = typeof(Element);
            IEnumerable<Type> Types = Assembly.GetAssembly(ourtype).GetTypes().Where(type => type.IsSubclassOf(ourtype));

            TypeList = Types.ToList();
        }

        public void Serialize(List<Element> elements, String fileName)
        {
            var jsonString = JsonSerializer.Serialize((List<Element>)elements);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Element> Deserialize(String fileName)
        {
            var newjsonliststring = File.ReadAllText(fileName);
            var newElementList = JsonSerializer.Deserialize<List<Element>>(newjsonliststring);
            List<Element> elementList = new List<Element>();

            foreach (var element in newElementList)
            {
                foreach (var type in TypeList)
                {
                    if(element.TypeOfElement == type.ToString())
                    {
                        var newelement = (Element)Activator.CreateInstance(type);
                        newelement.PosX1 = element.PosX1;
                        newelement.PosX2 = element.PosX2;
                        newelement.PosY1 = element.PosY1;
                        newelement.PosY2 = element.PosY2;
                        
                        newelement.BorderColor = Color.FromName(element.BorderColorName);
                        newelement.FillColor = Color.FromName(element.FillColorName);
                        newelement.Width = element.Width;
                        newelement.TypeOfElement = element.TypeOfElement;
                        newelement.IsErased = element.IsErased;
                        newelement.IsFillNull = element.IsFillNull;
                        newelement.IsLastElement = element.IsLastElement;

                        elementList.Add(newelement);
                    }
                }
            }

            newElementList.Clear();

            return elementList;
        }

        public void DrawElements()
        {
            Pen pen = new Pen(Color.Black);

            foreach (Element element in Elements)
            {
                pen.Color = element.BorderColor;
                pen.Width = element.Width;

                if (element.IsErased == false)
                {
                    if (element.IsLastElement == false)
                        element.Draw(this.Graphics, pen);

                    else
                    {
                        element.Draw(this.Graphics, pen);
                        return;
                    }
                }

                else
                    continue;
            }
        }

        public void CheckLastElement()
        {
            var lastElement = Elements.Last();

            foreach (Element element in Elements)
            {
                if (element.Equals(lastElement))
                    element.IsLastElement = true;
                else
                    element.IsLastElement = false;
            }
        }
    }
}
