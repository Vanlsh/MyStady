using LibraryFit.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitWinForm
{
    public partial class Enter : Form
    {
        public Enter()
        {
            InitializeComponent();
        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            var userController = new UserController(nameTextBox.Text);
            MessageBox.Show(userController.CurrentUser.Name);
            var form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
