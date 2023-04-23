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
using System.Runtime.CompilerServices;

namespace Úkol_1_Textové_soubory_Stach
{
    public partial class Form1 : Form
    {
        //Je dán textový soubor knihy.txt, kde na každém řádku je Název; Autor;Umístění;Žánr;Datum.
        //    Každý údaj je oddělen středníkem.Soubor zobraz do ListBoxu.Rozdělte soubor na dva textové soubory.
        //    V 1. souboru budou knihy mladší než rok 1950 a ve 2. souboru knihy starší.
        //        Do TextBoxu zadejte jméno autora a zobrazte informace o první jeho knížce zapsané v původním souboru.


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            StreamReader sr = new StreamReader("knihy.txt",Encoding.GetEncoding("UTF-8"));
            StreamWriter swyoung = new StreamWriter("mladsi.txt",true, Encoding.GetEncoding("UTF-8"));
            StreamWriter swold = new StreamWriter("starsi.txt",true, Encoding.GetEncoding("UTF-8"));
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] vec = line.Split(';');
                string nazev = vec[0];
                string autor = vec[1];
                string umisteni = vec[2];
                string zanr = vec[3];
                string datum = vec[4];
                listBox1.Items.Add(String.Format("{0} {1} {2} {3} {4}", nazev, autor, umisteni, zanr, datum));

                if(Convert.ToInt32(datum) > 1950)
                {
                    swyoung.WriteLine(line);
                }
                else { swold.WriteLine(line); }
            }
            sr.Close();
            swyoung.Close();
            swold.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            StreamReader sr = new StreamReader("knihy.txt", Encoding.GetEncoding("UTF-8"));
            string zadanejautor = textBox1.Text;
            bool konec = false;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] vec = line.Split(';');
                string nazev = vec[0];
                string autor = vec[1];
                string umisteni = vec[2];
                string zanr = vec[3];
                string datum = vec[4];

                if (zadanejautor == autor && konec == false)
                {
                    listBox2.Items.Add(line);
                    konec = true;
                }
            }
            sr.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { button1.Enabled = false; } else { button1.Enabled = true; }
        }
    }
}
