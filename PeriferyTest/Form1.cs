using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeriferyTest
{
    public partial class Form1 : Form
    {
        private int pocetClicks;
        private float cas;
        private int pocetTecek = 0;
        private int pocetZaznamu = 1;
        Random random = new Random();
        String vypis;

        public Form1()
        {
            InitializeComponent();
            pocetClicks = 0;
            timer1.Stop();
            cas = 0;
            label1.Text = cas.ToString();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            pocetClicks = 0;
            pocetTecek = random.Next(5, 20);
            cas = 0;
            timer1.Start();
            createNewCheckBox();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (cb.Checked)
            {
                pocetClicks++;
                clicksLabel.Text = "Pocet kliku: " + pocetClicks;
                this.Controls.Remove(cb);

                if(pocetTecek == pocetClicks)
                {
                    MessageBox.Show("Pocet kliknutych tecek: " + pocetClicks + "\nZa cas: " + cas + " sekund");
                    vypis += "Zaznam cislo " + pocetZaznamu++ + ": Body: " + pocetClicks + ", Cas: " + cas + "\n";
                    
                    timer1.Stop();
                }else{
                    createNewCheckBox();
                }
            }

        }

        private void createNewCheckBox()
        {
            CheckBox cb = new CheckBox();

            int x = random.Next(20, 790);
            int y = random.Next(20, 410);

            cb.Location = new Point(x, y);
            //  489  816
            cb.CheckedChanged += CheckBox_CheckedChanged;
            this.Controls.Add(cb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cas++;
            label1.Text = "Time: " + cas;
        }

        private void scoreBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(vypis);
        }
    }
}
