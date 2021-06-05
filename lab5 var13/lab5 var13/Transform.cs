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
    public partial class Transform : Form
    {
        Form1 main_form;
        public Transform()
        {
            InitializeComponent();
        }
        public Transform(Form1 main_form) : this()
        {

            this.main_form = main_form;
        }
        private void Transform_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;
            Save.Enabled = false; 


            X0label.Visible = false;
            Y0label.Visible = false;
            textBoxX0.Visible = false;
            textBoxY0.Visible = false;
            Anglelabel.Visible = false;
            textBoxAngle.Visible = false;
          

        }


        private void textBoxX_TextChanged(object sender, EventArgs e) 
        {
           
            if(checkBox1.Checked&&checkBox2.Checked)
            {
            if(!int.TryParse(textBoxX.Text, out int  o)&& textBoxX.Text!="")
            {
                textBoxXerror.SetError(textBoxX, "Ви ввели некоректне значення"); 
                
                Save.Enabled = false;
            }
            else
            {
                    textBoxXerror.Clear(); 
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d) && int.TryParse(textBoxAngle.Text, out int f))
                    {

                        Save.Enabled = true;
                    }
            }
            }
            if(checkBox1.Checked && !checkBox2.Checked)
            {
                if (!int.TryParse(textBoxX.Text, out int a) && textBoxX.Text != "")
                {
                    textBoxXerror.SetError(textBoxX, "Ви ввели некоректне значення");
                    Save.Enabled = false;
                }
                else
                {
                    textBoxXerror.Clear();
                    if (int.TryParse(textBoxX.Text, out int h) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d))
                    {
                        Save.Enabled = true;
                    }
                }
            }
            if(!checkBox1.Checked && checkBox2.Checked)
            {
                if (!int.TryParse(textBoxX.Text, out int o) && textBoxX.Text != "")
                {
                    textBoxXerror.SetError(textBoxX, "Ви ввели некоректне значення");

                    Save.Enabled = false;
                }
                else
                {
                    textBoxXerror.Clear();
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxAngle.Text, out int f))
                    {
                        Save.Enabled = true;
                    }
                }
            }
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked && checkBox2.Checked)
            {
                if (!int.TryParse(textBoxY.Text, out int o) && textBoxY.Text != "")
                {
                    textBoxYerror.SetError(textBoxY, "Ви ввели некоректне значення");

                    Save.Enabled = false;
                }
                else
                {
                    textBoxYerror.Clear();
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d) && int.TryParse(textBoxAngle.Text, out int f))
                    {
                        Save.Enabled = true;
                    }
                }
            }
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                if (!int.TryParse(textBoxY.Text, out int a) && textBoxY.Text != "")
                {
                    textBoxYerror.SetError(textBoxY, "Ви ввели некоректне значення");
                    Save.Enabled = false;
                }
                else
                {
                    textBoxYerror.Clear();
                    if (int.TryParse(textBoxX.Text, out int h) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d))
                    {
                        Save.Enabled = true;
                    }
                }
            }
            if (!checkBox1.Checked && checkBox2.Checked)
            {
                if (!int.TryParse(textBoxY.Text, out int o) && textBoxY.Text != "")
                {
                    textBoxYerror.SetError(textBoxY, "Ви ввели некоректне значення");

                    Save.Enabled = false;
                }
                else
                {
                    textBoxYerror.Clear();
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxAngle.Text, out int f))
                    {
                        Save.Enabled = true;
                    }
                }
            }
        }

        private void textBoxX0_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                if (!int.TryParse(textBoxX0.Text, out int o) && textBoxX0.Text != "")
                {
                    textBoxX0error.SetError(textBoxX0, "Ви ввели некоректне значення");

                    Save.Enabled = false;
                }
                else
                {
                    textBoxX0error.Clear();
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d) && int.TryParse(textBoxAngle.Text, out int f))
                    {
                        Save.Enabled = true;
                    }
                }
            }
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                if (!int.TryParse(textBoxX0.Text, out int a) && textBoxX0.Text != "")
                {
                    textBoxX0error.SetError(textBoxX0, "Ви ввели некоректне значення");
                    Save.Enabled = false;
                }
                else
                {
                    textBoxX0error.Clear();
                    if (int.TryParse(textBoxX.Text, out int h) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d))
                    {
                        Save.Enabled = true;
                    }
                }
            }
            if (!checkBox1.Checked && checkBox2.Checked)
            {
                
                if (!int.TryParse(textBoxX0.Text, out int o) && textBoxX0.Text != "")
                {
                    textBoxX0error.SetError(textBoxX0, "Ви ввели некоректне значення");

                    Save.Enabled = false;
                }
                else
                {
                    textBoxX0error.Clear();
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxAngle.Text, out int f))
                    {
                        Save.Enabled = true;
                    }
                }
            }
        }
        private void textBoxY0_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                if (!int.TryParse(textBoxY0.Text, out int o) && textBoxY0.Text != "")
                {
                    textBoxY0error.SetError(textBoxY0, "Ви ввели некоректне значення");

                    Save.Enabled = false;
                }
                else
                {
                    textBoxY0error.Clear();
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d) && int.TryParse(textBoxAngle.Text, out int f))
                    {
                        Save.Enabled = true;
                    }
                }
            }
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                if (!int.TryParse(textBoxY0.Text, out int a) && textBoxY0.Text != "")
                {
                    textBoxY0error.SetError(textBoxY0, "Ви ввели некоректне значення");
                    Save.Enabled = false;
                }
                else
                {
                    textBoxY0error.Clear();
                    if (int.TryParse(textBoxX.Text, out int h) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d))
                    {
                        Save.Enabled = true;
                    }
                }
            }
            if (!checkBox1.Checked && checkBox2.Checked)
            {

                if (!int.TryParse(textBoxY0.Text, out int o) && textBoxY0.Text != "")
                {
                    textBoxY0error.SetError(textBoxY0, "Ви ввели некоректне значення");

                    Save.Enabled = false;
                }
                else
                {
                    textBoxY0error.Clear();
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxAngle.Text, out int f))
                    {
                        Save.Enabled = true;
                    }
                }
            }
        }
        private void textBoxAngle_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                if (!int.TryParse(textBoxAngle.Text, out int o) && textBoxAngle.Text != "")
                {
                    textBoxAngleerror.SetError(textBoxAngle, "Ви ввели некоректне значення");

                    Save.Enabled = false;
                }
                else
                {
                    textBoxAngleerror.Clear();
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d) && int.TryParse(textBoxAngle.Text, out int f))
                    {
                        Save.Enabled = true;
                    }
                }
            }
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                if (!int.TryParse(textBoxAngle.Text, out int a) && textBoxAngle.Text != "")
                {
                    textBoxAngleerror.SetError(textBoxAngle, "Ви ввели некоректне значення");
                    Save.Enabled = false;
                }
                else
                {
                    textBoxAngleerror.Clear();
                    if (int.TryParse(textBoxX.Text, out int h) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d))
                    {
                        Save.Enabled = true;
                    }
                }
            }
            if (!checkBox1.Checked && checkBox2.Checked)
            {

                if (!int.TryParse(textBoxAngle.Text, out int o) && textBoxAngle.Text != "")
                {
                    textBoxAngleerror.SetError(textBoxAngle, "Ви ввели некоректне значення");

                    Save.Enabled = false;
                }
                else
                {
                    textBoxAngleerror.Clear();
                    if (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxAngle.Text, out int f))
                    {
                        Save.Enabled = true;
                    }
                }
            }
        }


        private void checkBox1_Click(object sender, EventArgs e)
        {
          

            if (checkBox1.Checked && checkBox2.Checked)
            Save.Enabled = (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d) && int.TryParse(textBoxAngle.Text, out int f));
            if (checkBox1.Checked && !checkBox2.Checked)
            Save.Enabled = (int.TryParse(textBoxX.Text, out int h) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d));
            if (!checkBox1.Checked && checkBox2.Checked)
            Save.Enabled = (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxAngle.Text, out int f));
 



            X0label.Visible = checkBox1.Checked;
            Y0label.Visible = checkBox1.Checked;
            textBoxX0.Visible = checkBox1.Checked;
            textBoxY0.Visible = checkBox1.Checked;
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
                Save.Enabled = (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d) && int.TryParse(textBoxAngle.Text, out int f));
            if (checkBox1.Checked && !checkBox2.Checked)
                Save.Enabled = (int.TryParse(textBoxX.Text, out int h) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxX0.Text, out int c) && int.TryParse(textBoxY0.Text, out int d));
            if (!checkBox1.Checked && checkBox2.Checked)
                Save.Enabled = (int.TryParse(textBoxX.Text, out int a) && int.TryParse(textBoxY.Text, out int b) && int.TryParse(textBoxAngle.Text, out int f));
            Anglelabel.Visible = checkBox2.Checked;
            textBoxAngle.Visible = checkBox2.Checked;


        }

        private void Save_Click(object sender, EventArgs e)
        {
            
            main_form.X = int.Parse(textBoxX.Text);
            main_form.Y = int.Parse(textBoxY.Text);
            if (checkBox1.Checked)
            {
                main_form.X0 = int.Parse(textBoxX0.Text);
                main_form.Y0 = int.Parse(textBoxY0.Text);
            }
            if (checkBox2.Checked)
            {
                main_form.Angle = int.Parse(textBoxAngle.Text);
            }
            
            main_form.Turn = checkBox2.Checked;
            main_form.Offset = checkBox1.Checked;
            main_form.view_menu.Enabled = true;
        }
    }
}
