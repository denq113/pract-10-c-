using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pract_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string name1 = Convert.ToString(f.textBox1.Text);
                int kol1 = Convert.ToInt32(f.textBox2.Text);
                double stoim1 = Convert.ToDouble(f.textBox3.Text);
                People p = new People(name1,kol1,stoim1);
                listBox1.Items.Add(p);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Обьект для удаления не выбран");
            } 
            else
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Обьект для редоктирования не выбран");
            }
            else
            {
               Form2 f = new Form2();
               People p = listBox1.Items[listBox1.SelectedIndex] as People;
               f.textBox1.Text = p.Name;
                f.textBox2.Text = p.Kol.ToString();
                f.textBox3.Text = p.Stoim.ToString();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    string skladame = f.textBox1.Text;
                    int skladkol = Convert.ToInt32(f.textBox2.Text);
                    double skladStoim = Convert.ToDouble(f.textBox3.Text);
                    p.Name = skladame;
                    p.Kol = skladkol;
                    p.Stoim = skladStoim;
                    listBox1.Items[listBox1.SelectedIndex] = p;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double sred = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                People p = listBox1.Items[i] as People;
                double g = p.Stoim;
                sred = sred + g;
            }
            sred = sred / listBox1.Items.Count;
            label2.Text = sred.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
               while (streamReader.EndOfStream == false)
                {
                    People p = new People();
                    p.Name = streamReader.ReadLine();
                    p.Stoim = Convert.ToInt32(streamReader.ReadLine());
                    p.Kol = Convert.ToInt32(streamReader.ReadLine());   
                    listBox1.Items.Add(p);
                }
               streamReader.Close();
            }
          

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; listBox1.Items.Count > i; i++)
                {
                    People p = listBox1.Items[i] as People;
                    streamWriter.WriteLine(p.Name);
                    streamWriter.WriteLine(p.Stoim);
                    streamWriter.WriteLine(p.Kol);
                }
                streamWriter.Close();
            }
        }
    }
}
