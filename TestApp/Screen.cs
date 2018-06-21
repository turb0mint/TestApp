using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Screen : Form
    {
        Controller Cntrl;
        
        public Screen()
        {
            InitializeComponent();
            Cntrl= new Controller(this);
            Cntrl.StateChangeEvent += Cntrl_StateChangeEvent;

        }

        private void Cntrl_StateChangeEvent(object sender, STATE e)
        {
            this.output(e.ToString());
        }

        public void output(string message)
        {

            textBox1.AppendText(message);
            textBox1.AppendText(Environment.NewLine);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button1.Text = "Starting...";
          await Cntrl.Initalize();
            this.button1.Enabled = true;
            this.button1.Text = "START";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cntrl.ShutDown();
        }
    }
}
