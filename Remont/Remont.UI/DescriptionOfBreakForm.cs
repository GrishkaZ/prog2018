using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remont.UI
{
    public partial class DescriptionOfBreakForm : Form
    {
        public Breakage br { get; set; }
        public DescriptionOfBreakForm(Breakage br)
        {
            this.br = br;
            InitializeComponent();
        }

        private void DescriptionOfBreak_Load(object sender, EventArgs e)
        {
            textBox1.Text = br.Description;
            switch(br.BreakageType)
            {
                case DamageType.Physical:
                    radioButton1.Checked = true;
                    break;
                case DamageType.Burned:
                    radioButton2.Checked = true;
                    break;
                case DamageType.Else:
                    radioButton3.Checked = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            br.Description = textBox1.Text;
            if (radioButton1.Checked)
                br.BreakageType = DamageType.Physical;
            if (radioButton2.Checked)
                br.BreakageType = DamageType.Burned;
            if (radioButton3.Checked)
                br.BreakageType = DamageType.Else;
        }
    }
}
