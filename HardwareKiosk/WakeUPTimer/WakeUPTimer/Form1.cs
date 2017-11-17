using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WakeUPTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNow.Text = string.Format("Now: {0}",DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WakeUP wup = new WakeUP();
            wup.Woken += WakeUP_Woken;
            wup.SetWakeUpTime(DateTimePicker1.Value);
        }

        private void WakeUP_Woken(object sender, EventArgs e)
        {
            lblWoken.Text = string.Format("Woken: {0}", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());

            System.Threading.Thread.Sleep(60000);
            System.Diagnostics.Process.Start("shutdown", "-r -t 20");   //'Restart ภายใน 20 วินาที
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Suspend, false, false);
            //Application.SetSuspendState(PowerState.Hibernate, false, false);
        }
    }
}
