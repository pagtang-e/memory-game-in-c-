using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryMatchingGame
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        
        public Form2()
        {
            InitializeComponent();
            instance = this;
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            object okna = numericUpDown1.Value;
            
            GameWindow f1 = new GameWindow(okna);
            
            GameWindow.instance.name1.Text = textBox1.Text;
            GameWindow.instance.name2.Text = textBox2.Text;
            
            f1.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
