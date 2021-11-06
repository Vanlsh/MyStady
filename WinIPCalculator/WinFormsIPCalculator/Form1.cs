using LibraryIpApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsIPCalculator
{
    public partial class Form1 : Form
    {
        Point lastPoint;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Yellow;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.IndianRed;
        }         
        private void UpPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void UpPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        /// <summary>
        /// Кнопка резалт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resultButton_Click(object sender, EventArgs e)
        {
            this.Calculate();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.ClearText();
        }
        private void Calculate()
        {
            IPCalculator calculator = new IPCalculator();

            int[] ipInput = IpCalculatorInterface.StringToIntArray(ipTextBox1.Text, ipTextBox2.Text,
                ipTextBox3.Text, ipTextBox4.Text);
            int[] maskInput = IpCalculatorInterface.StringToIntArray(maskipTextBox1.Text, maskipTextBox2.Text,
                maskipTextBox3.Text, maskipTextBox4.Text);

            calculator.SetIpAddres(ipInput);
            calculator.SetNetworkMask(maskInput);

            this.ShowResult(calculator);
        }
        private void ShowResult(IPCalculator calculator)
        {
            BitArray[] NetworkAdress = calculator.GetNetworkAdress();
            BitArray[] HostMin = calculator.GetHostMin();
            BitArray[] HostMax = calculator.GetHostMax();
            int maskPrefixes = calculator.MaskPrefixes();
            int numberOfHosts = calculator.NumberOfHosts();

            maskPrefixesTB.Text = maskPrefixes.ToString();
            numOfHostTB.Text = numberOfHosts.ToString();

            {
                String text = "";
                foreach (BitArray i in NetworkAdress)
                {
                    text += IpCalculatorInterface.BitArrayToInt(i) + ".";
                }

                string t = text.Remove(text.Length - 1, 1);
                netWorkAdress.Text = t;
            }
            {
                String text = "";
                foreach (BitArray i in HostMax)
                {
                    text += IpCalculatorInterface.BitArrayToInt(i) + ".";
                }

                string t = text.Remove(text.Length - 1, 1);
                maxNetWorkAdress.Text = t;
            }

            {
                String text = "";
                foreach (BitArray i in HostMin)
                {
                    text += IpCalculatorInterface.BitArrayToInt(i) + ".";
                }

                string t = text.Remove(text.Length - 1, 1);
                minNetWorkAdress.Text = t;
            }
        }
        private void ClearText()
        {
            ipTextBox1.Clear();
            ipTextBox2.Clear();
            ipTextBox3.Clear();
            ipTextBox4.Clear();
            maskipTextBox1.Clear();
            maskipTextBox2.Clear();
            maskipTextBox3.Clear();
            maskipTextBox4.Clear();
        }
        private void CheckIpAdress(string text)
        {
            if (text.Length > 3)
            {
                labelExeption.Text = "Не коректний IP адрес";
            }
            if (text.Length <= 3)
            {
                labelExeption.Text = " ";
            }
        }
        private void ipTextBox1_TextChanged(object sender, EventArgs e)
        {
            CheckIpAdress(ipTextBox1.Text);

            ipBinaryTB1.Text = IpCalculatorInterface.StrToBineryStr(ipTextBox1.Text);
            
        }

        private void ipTextBox2_TextChanged(object sender, EventArgs e)
        {
            CheckIpAdress(ipTextBox2.Text);

            ipBinaryTB2.Text = IpCalculatorInterface.StrToBineryStr(ipTextBox2.Text);
        }

        private void ipTextBox3_TextChanged(object sender, EventArgs e)
        {
            CheckIpAdress(ipTextBox3.Text);

            ipBinaryTB3.Text = IpCalculatorInterface.StrToBineryStr(ipTextBox3.Text);
        }

        private void ipTextBox4_TextChanged(object sender, EventArgs e)
        {
            CheckIpAdress(ipTextBox4.Text);
            ipBinaryTB4.Text = IpCalculatorInterface.StrToBineryStr(ipTextBox4.Text);
        }

        private void CheckIpMask(string text)
        {
            if (text.Length > 3)
            {
                labelExeption2.Text = "Не коректний IP адрес";
            }
            if (text.Length <= 3)
            {
                labelExeption2.Text = " ";
            }
        }


        private void maskipTextBox1_TextChanged(object sender, EventArgs e)
        {
            CheckIpMask( maskipTextBox1.Text);
            maskBinaryTB1.Text = IpCalculatorInterface.StrToBineryStr(maskipTextBox1.Text);
        }

        private void maskipTextBox2_TextChanged(object sender, EventArgs e)
        {
            CheckIpMask(maskipTextBox2.Text);
            maskBinaryTB2.Text = IpCalculatorInterface.StrToBineryStr(maskipTextBox2.Text);
        }

        private void maskipTextBox3_TextChanged(object sender, EventArgs e)
        {
            CheckIpMask(maskipTextBox3.Text);
            maskBinaryTB3.Text = IpCalculatorInterface.StrToBineryStr(maskipTextBox3.Text);
        }

        private void maskipTextBox4_TextChanged(object sender, EventArgs e)
        {
            CheckIpMask(maskipTextBox4.Text);
            maskBinaryTB4.Text = IpCalculatorInterface.StrToBineryStr(maskipTextBox4.Text);
        }
    }
}
