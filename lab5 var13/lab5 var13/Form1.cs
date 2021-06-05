using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5_var13
{
    public partial class Form1 : Form
    {
        double angle = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            MinimumSize = Size; 
            view_menu.Enabled = false;
            Text = "Ситниченко Денис, КІ, 3 група ";
        }
        
        private void menu_transform_Click(object sender, EventArgs e)
        {
            Transform transform = new Transform(this); 
            transform.Show();
        }
        
        private void view_menu_Click(object sender, EventArgs e)
        {
            Output output = new Output();
            double new_X = X, new_Y = X;
            if(Offset)
            {
                new_X -= X0;
                new_Y -= Y0;
            }
            if(Turn)
            {
                double x1 = new_X, y1 = new_Y;
                new_X = x1 * Math.Cos(Angle) + y1 * Math.Sin(Angle);
                new_Y = -x1 * Math.Sin(Angle) + y1 * Math.Cos(Angle);
            }
            output.textBoxX0.Text = Math.Round(new_X,4).ToString();
            output.textBoxY0.Text = Math.Round(new_Y,4).ToString();
            output.Show();
        }

        private void menu_about_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menu_help_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
        

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int X0 { get; set; } = 0;
        public int Y0 { get; set; } = 0;
        public double Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = (value / 180 * Math.PI);
            }
        }

        public bool Offset { get; set; } = false;
        public bool Turn { get; set; } = false;

    }
}
