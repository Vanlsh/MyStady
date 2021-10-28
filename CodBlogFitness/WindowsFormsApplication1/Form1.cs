using ClassLibrary1.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userController = new UserController(nameTextBox.Text,genderTextBox.Text,DateTime.Parse(birthDayTextBox.Text), double.Parse(weightTextBox.Text), double.Parse(hightTextBox.Text));
            userController.Save();
        }
    }
}
