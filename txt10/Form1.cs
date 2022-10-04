using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace txt10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                while (!streamReader.EndOfStream)
                {
                 
                    listBox1.Items.Add(streamReader.ReadLine());
                }
                streamReader.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
            StreamWriter streamWriter = new StreamWriter("pomocnik.txt");
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                char aritoperator;
                char[] sep = { ' ' };
                string[] priklad = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                int cislo1 = int.Parse(priklad[0]);
                aritoperator = char.Parse(priklad[1]);
                int cislo2 = int.Parse(priklad[2]);

                double vysledek = 0;

                if (aritoperator == '+')
                {
                    vysledek = cislo1 + cislo2;
                }
                else if (aritoperator == '-')
                {
                    vysledek = cislo1 - cislo2;
                }
                else if (aritoperator == '/')
                {
                    vysledek = cislo1 / cislo2;
                }
                else if (aritoperator == '*')
                {
                    vysledek = cislo1 * cislo2;
                }
                line += vysledek;
                streamWriter.WriteLine(line);


            }
            streamWriter.Close();
            streamReader.Close();
            File.Delete(openFileDialog1.FileName);
            File.Move("pomocnik.txt", openFileDialog1.FileName);
            streamReader = new StreamReader(openFileDialog1.FileName);
            while (!streamReader.EndOfStream)
            {
                listBox2.Items.Add(streamReader.ReadLine());
            }


        }
    }
}
