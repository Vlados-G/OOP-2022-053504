
namespace Laba2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCMBMouse = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCMBCoordinates = new System.Windows.Forms.ToolStripComboBox();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTXBCoordX1 = new System.Windows.Forms.ToolStripTextBox();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTXBCoordY1 = new System.Windows.Forms.ToolStripTextBox();
            this.x1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTXBCoordX2 = new System.Windows.Forms.ToolStripTextBox();
            this.y2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTXBCoordY2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItemPaint = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCMBMainColor = new System.Windows.Forms.ToolStripComboBox();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCMBBackgroundColor = new System.Windows.Forms.ToolStripComboBox();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCMBWidth = new System.Windows.Forms.ToolStripComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.widthToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1578, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCMBMouse});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 26);
            this.toolStripMenuItem1.Text = "Mouse";
            // 
            // toolStripCMBMouse
            // 
            this.toolStripCMBMouse.DropDownWidth = 50;
            this.toolStripCMBMouse.Name = "toolStripCMBMouse";
            this.toolStripCMBMouse.Size = new System.Drawing.Size(352, 28);
            this.toolStripCMBMouse.SelectedIndexChanged += new System.EventHandler(this.toolStripCMBMouse_SelectedIndexChanged);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCMBCoordinates,
            this.xToolStripMenuItem,
            this.yToolStripMenuItem,
            this.x1ToolStripMenuItem,
            this.y2ToolStripMenuItem,
            this.toolStripMenuItemPaint});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 26);
            this.toolStripMenuItem2.Text = "Coordinates";
            // 
            // toolStripCMBCoordinates
            // 
            this.toolStripCMBCoordinates.Name = "toolStripCMBCoordinates";
            this.toolStripCMBCoordinates.Size = new System.Drawing.Size(121, 28);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTXBCoordX1});
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xToolStripMenuItem.Text = "X1:";
            // 
            // toolStripTXBCoordX1
            // 
            this.toolStripTXBCoordX1.Name = "toolStripTXBCoordX1";
            this.toolStripTXBCoordX1.Size = new System.Drawing.Size(100, 27);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTXBCoordY1});
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.yToolStripMenuItem.Text = "Y1:";
            // 
            // toolStripTXBCoordY1
            // 
            this.toolStripTXBCoordY1.Name = "toolStripTXBCoordY1";
            this.toolStripTXBCoordY1.Size = new System.Drawing.Size(100, 27);
            // 
            // x1ToolStripMenuItem
            // 
            this.x1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTXBCoordX2});
            this.x1ToolStripMenuItem.Name = "x1ToolStripMenuItem";
            this.x1ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.x1ToolStripMenuItem.Text = "X2:";
            // 
            // toolStripTXBCoordX2
            // 
            this.toolStripTXBCoordX2.Name = "toolStripTXBCoordX2";
            this.toolStripTXBCoordX2.Size = new System.Drawing.Size(100, 27);
            // 
            // y2ToolStripMenuItem
            // 
            this.y2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTXBCoordY2});
            this.y2ToolStripMenuItem.Name = "y2ToolStripMenuItem";
            this.y2ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.y2ToolStripMenuItem.Text = "Y2:";
            // 
            // toolStripTXBCoordY2
            // 
            this.toolStripTXBCoordY2.Name = "toolStripTXBCoordY2";
            this.toolStripTXBCoordY2.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripMenuItemPaint
            // 
            this.toolStripMenuItemPaint.Name = "toolStripMenuItemPaint";
            this.toolStripMenuItemPaint.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItemPaint.Text = "Paint";
            this.toolStripMenuItemPaint.Click += new System.EventHandler(this.toolStripMenuItemPaint_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainColorToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // mainColorToolStripMenuItem
            // 
            this.mainColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCMBMainColor});
            this.mainColorToolStripMenuItem.Name = "mainColorToolStripMenuItem";
            this.mainColorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.mainColorToolStripMenuItem.Text = "Main color";
            // 
            // toolStripCMBMainColor
            // 
            this.toolStripCMBMainColor.Items.AddRange(new object[] {
            "Red",
            "Pink",
            "Purple",
            "Green",
            "Blue",
            "Yellow",
            "Black",
            "Gray"});
            this.toolStripCMBMainColor.Name = "toolStripCMBMainColor";
            this.toolStripCMBMainColor.Size = new System.Drawing.Size(121, 28);
            this.toolStripCMBMainColor.Text = "Black";
            this.toolStripCMBMainColor.SelectedIndexChanged += new System.EventHandler(this.toolStripCMBMainColor_SelectedIndexChanged);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCMBBackgroundColor});
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.backgroundColorToolStripMenuItem.Text = "Background color";
            // 
            // toolStripCMBBackgroundColor
            // 
            this.toolStripCMBBackgroundColor.Items.AddRange(new object[] {
            "Null",
            "Red",
            "Pink",
            "Purple",
            "Green",
            "Blue",
            "Yellow",
            "Black",
            "Gray"});
            this.toolStripCMBBackgroundColor.Name = "toolStripCMBBackgroundColor";
            this.toolStripCMBBackgroundColor.Size = new System.Drawing.Size(121, 28);
            this.toolStripCMBBackgroundColor.Text = "Null";
            this.toolStripCMBBackgroundColor.SelectedIndexChanged += new System.EventHandler(this.toolStripCMBBackgroundColor_SelectedIndexChanged);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // widthToolStripMenuItem
            // 
            this.widthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCMBWidth});
            this.widthToolStripMenuItem.Name = "widthToolStripMenuItem";
            this.widthToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.widthToolStripMenuItem.Text = "Width";
            // 
            // toolStripCMBWidth
            // 
            this.toolStripCMBWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.toolStripCMBWidth.Name = "toolStripCMBWidth";
            this.toolStripCMBWidth.Size = new System.Drawing.Size(121, 28);
            this.toolStripCMBWidth.Text = "1";
            this.toolStripCMBWidth.SelectedIndexChanged += new System.EventHandler(this.toolStripCMBWidth_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 888);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripCMBMainColor;
        private System.Windows.Forms.ToolStripComboBox toolStripCMBBackgroundColor;
        private System.Windows.Forms.ToolStripMenuItem widthToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripCMBWidth;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox toolStripCMBMouse;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripComboBox toolStripCMBCoordinates;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTXBCoordX1;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTXBCoordY1;
        private System.Windows.Forms.ToolStripMenuItem x1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTXBCoordX2;
        private System.Windows.Forms.ToolStripMenuItem y2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTXBCoordY2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPaint;
    }
}

