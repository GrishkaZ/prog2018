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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboBox();
            //SetModelToUI(GetModelFromUI());
        }

        OrderRequestDto GetModelFromUI()
        {
            return new OrderRequestDto
            {
                FullName = fioTextBox.Text,
                TimeOfRepair = new TimeOfRepair()
                {
                    Filled = dateTimePicker.Value,
                    Days = (int)numericUpDown1.Value,
                },
                Price = new Payment()
                {
                    Price = numericUpDown2.Value,
                },
                DescriptionOfBreakageDevice = new Device()
                {
                    Breakage = mainListBox.Items.OfType<Breakage>().ToList(),
                },
                Repair = new AdditionalRequirements()
                {
                    BuySomeDetailsYourself = checkBox1.Checked,
                    AdditionalRequests = textBox1.Text,
                }
            };
        }

        private void ComboBox()
        {
            comboBox1.Items.Add(Apparat.Утюг);
            comboBox1.Items.Add(Apparat.Микроволновка);
            comboBox1.Items.Add(Apparat.Чайник);
            comboBox1.Items.Add(Apparat.Миксер);
            comboBox1.Items.Add(Apparat.Обогреватель);
            comboBox1.Items.Add(Apparat.Пылесос);
            comboBox1.Items.Add(Apparat.Телевизор);  
            comboBox1.Items.Add(Apparat.Другое);

            comboBox2.Items.Add(Currency.Rubles);
            comboBox2.Items.Add(Currency.Dollars);
            comboBox2.Items.Add(Currency.Euro);
            comboBox2.Items.Add(Currency.Bitcoins);
            comboBox2.Items.Add(Currency.Ethereum);
        }


        private void SetModelToUI(OrderRequestDto dto)
        {  
            dateTimePicker.Value = dto.TimeOfRepair.Filled;
            numericUpDown1.Value = dto.TimeOfRepair.Days;
            dateTimePicker1.Value = dto.TimeOfRepair.RepairTime(dto.TimeOfRepair.Filled);
            fioTextBox.Text = dto.FullName;
            textBox1.Text = dto.Repair.AdditionalRequests;
            checkBox1.Checked = dto.Repair.BuySomeDetailsYourself;
            numericUpDown2.Value = dto.Price.Price;
            mainListBox.Items.Clear();
            foreach (var e in dto.DescriptionOfBreakageDevice.Breakage)
            {
                mainListBox.Items.Add(e);
            }
        }

        private void Saver(OrderRequestDto dto)
        {
            if (comboBox1.SelectedIndex == 0)
                dto.DescriptionOfBreakageDevice.BrokenDevice = Apparat.Утюг;
            if (comboBox1.SelectedIndex == 1)
                dto.DescriptionOfBreakageDevice.BrokenDevice = Apparat.Микроволновка;
            if (comboBox1.SelectedIndex == 2)
                dto.DescriptionOfBreakageDevice.BrokenDevice = Apparat.Чайник;
            if (comboBox1.SelectedIndex == 3)
                dto.DescriptionOfBreakageDevice.BrokenDevice = Apparat.Миксер;
            if (comboBox1.SelectedIndex == 4)
                dto.DescriptionOfBreakageDevice.BrokenDevice = Apparat.Обогреватель;
            if (comboBox1.SelectedIndex == 5)
                dto.DescriptionOfBreakageDevice.BrokenDevice = Apparat.Пылесос;
            if (comboBox1.SelectedIndex == 6)
                dto.DescriptionOfBreakageDevice.BrokenDevice = Apparat.Телевизор;
            if (comboBox1.SelectedIndex == 7)
                dto.DescriptionOfBreakageDevice.BrokenDevice = Apparat.Другое;

            if (comboBox2.SelectedIndex == 0)
                dto.Price.Currency = Currency.Rubles;
            if (comboBox2.SelectedIndex == 1)
                dto.Price.Currency = Currency.Dollars;
            if (comboBox2.SelectedIndex == 2)
                dto.Price.Currency = Currency.Euro;
            if (comboBox2.SelectedIndex == 3)
                dto.Price.Currency = Currency.Bitcoins;
            if (comboBox2.SelectedIndex == 4)
                dto.Price.Currency = Currency.Ethereum;  
        }
        private void Setter(OrderRequestDto dto)//тут всё сделать наоборот как в сейвере
        {
            if (dto.DescriptionOfBreakageDevice.BrokenDevice == Apparat.Утюг)
                comboBox1.SelectedIndex = 0;
            if (dto.DescriptionOfBreakageDevice.BrokenDevice == Apparat.Микроволновка)
                comboBox1.SelectedIndex = 1;
            if ( dto.DescriptionOfBreakageDevice.BrokenDevice == Apparat.Чайник)
                comboBox1.SelectedIndex = 2;
            if ( dto.DescriptionOfBreakageDevice.BrokenDevice == Apparat.Миксер)
                comboBox1.SelectedIndex = 3;
            if (dto.DescriptionOfBreakageDevice.BrokenDevice == Apparat.Обогреватель)
                comboBox1.SelectedIndex = 4;
            if (dto.DescriptionOfBreakageDevice.BrokenDevice == Apparat.Пылесос)
                comboBox1.SelectedIndex = 5;
            if (dto.DescriptionOfBreakageDevice.BrokenDevice == Apparat.Телевизор)
                comboBox1.SelectedIndex = 6;
            if ( dto.DescriptionOfBreakageDevice.BrokenDevice == Apparat.Другое)
                comboBox1.SelectedIndex = 7;

            if (dto.Price.Currency == Currency.Rubles)
                comboBox2.SelectedIndex = 0 ;
            if ( dto.Price.Currency == Currency.Dollars)
                comboBox2.SelectedIndex = 1;
            if (  dto.Price.Currency == Currency.Euro)
                comboBox2.SelectedIndex = 2;
            if ( dto.Price.Currency == Currency.Bitcoins)
                comboBox2.SelectedIndex = 3;
            if (dto.Price.Currency == Currency.Ethereum)
                comboBox2.SelectedIndex = 4 ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetModelToUI(GetModelFromUI());
            Saver(GetModelFromUI());

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {        
            if(comboBox1.SelectedIndex == 7)   
                MessageBox.Show("Напишите в комментариях тип устройства");
        }
  

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new DescriptionOfBreakForm(new Breakage());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
                mainListBox.Items.Add(form.br);
        }

        private void mainListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var br = mainListBox.SelectedItem as Breakage;
            if (br == null)
                return;
            var form = new DescriptionOfBreakForm(br.Clone());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                var si = mainListBox.SelectedIndex;
                mainListBox.Items.RemoveAt(si);
                mainListBox.Items.Insert(si, form.br);
            }
        }

        private void mainListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var si = mainListBox.SelectedIndex;
            mainListBox.Items.RemoveAt(si);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Файлы заказов|*.remont" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = GetModelFromUI();
                Saver(dto);
                RideDtoHelper.WriteToFile(sfd.FileName, dto);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Файл заказа|*.remont" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = RideDtoHelper.LoadFromFile(ofd.FileName);
                SetModelToUI(dto);
                Setter(dto);
            }
        }
    }
}
