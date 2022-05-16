using System;
using System.Drawing;
using System.Windows.Forms;
using DomainModel;

namespace Laba2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();           
        }

        public void InitializeMenu()
        {
            foreach (Type itm in Program.DomainModel.TypeList)
            {
                toolStripCMBMouse.Items.Add(itm.ToString());
                toolStripCMBCoordinates.Items.Add(itm.ToString());
            }
        }

        // New file
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Controller.NewFile();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Program.Controller.MouseDown(e.X, e.Y);       
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Program.Controller.MouseUp();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Program.AppModel.CurrentElement != null && Program.AppModel.IsCurrentElementActive)
            {
                EraseSelectedElement();
                Program.Controller.MouseMove(e.X, e.Y);
                DrawWithSelectedElement();
                Program.DomainModel.DrawElements();
            }
            else 
            {
                Program.Controller.MouseMove(e.X, e.Y);
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
                Program.Controller.OpenFile(openFileDialog1.FileName);
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
                Program.Controller.SaveFile(saveFileDialog.FileName);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            Program.DomainModel.DrawElements();
            DrawWithSelectedElement();
        }

        private void DrawWithSelectedElement()
        {
            if (Program.AppModel.CurrentElement != null && Program.AppModel.IsCurrentElementActive)
            {
                Pen pen = new Pen(Program.AppModel.CurrentElement.BorderColor, Program.AppModel.CurrentElement.Width);
                Program.AppModel.CurrentElement.Draw(Program.DomainModel.Graphics, pen);
            }
        }

        private void EraseSelectedElement()
        {
            if (Program.AppModel.CurrentElement != null && Program.AppModel.IsCurrentElementActive)
            {
                Pen pen = new Pen(Color.White, Program.AppModel.CurrentElement.Width);
                Program.AppModel.CurrentElement.Draw(Program.DomainModel.Graphics, pen);
            }
        }

        private void toolStripCMBMouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newElement = toolStripCMBMouse.SelectedItem.ToString();
            Program.Controller.CreateNewElement(newElement);
        }

        private void toolStripMenuItemPaint_Click(object sender, EventArgs e)
        {
            int coordX1 = Convert.ToInt16(toolStripTXBCoordX1.Text);
            int coordY1 = Convert.ToInt16(toolStripTXBCoordY1.Text);
            int coordX2 = Convert.ToInt16(toolStripTXBCoordX2.Text);
            int coordY2 = Convert.ToInt16(toolStripTXBCoordY2.Text);

            string newElement = toolStripCMBCoordinates.SelectedItem.ToString();

            Program.Controller.DrawByCoordinates(newElement, coordX1, coordY1, coordX2, coordY2);
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set current element to draw to: Line
            var element = new Line();
            element.PosX1 = Program.AppModel.CursorPositionX;
            element.PosY1 = Program.AppModel.CursorPositionY;
            element.TypeOfElement = element.GetType().ToString();
            Program.AppModel.CurrentElement = element;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Controller.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Controller.Redo();
        }

        private void toolStripCMBMainColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string color = toolStripCMBMainColor.SelectedItem.ToString();
            Program.Controller.SetMainColor(color);
        }

        private void toolStripCMBBackgroundColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string backgroudcolor = toolStripCMBBackgroundColor.SelectedItem.ToString();
            Program.Controller.SetFillColor(backgroudcolor);
        }

        private void toolStripCMBWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            float width = Convert.ToSingle(toolStripCMBWidth.SelectedItem);
            Program.Controller.SetWidth(width);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            "Вы хотите сохранить изменения в файле?",
                            "Сообщение",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
            this.Close();
        }
    }
}
