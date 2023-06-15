using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zadanie2
{
    public partial class Form1 :Form
    {
        private Playlist playlist;
        Shop monetka = new Shop();
        Product cola = new Product("Кола", 85);
        Product juice = new Product("Сок \"Добрый\"", 100);
        List<string> products = new List<string>();
        Product product;
        public Form1 ()
        {
            InitializeComponent();
            playlist = new Playlist();
        }

        public bool checkSym(string text)
        {
            foreach (var ch in text)
            {
                if (!char.IsDigit(ch))
                {
                    MessageBox.Show("Введи число");
                    return false;
                }
            }
            if (Convert.ToInt32(text) <= 0)
            {
                MessageBox.Show("Введи положительное число");
                return false;
            }
            return true;
        }

        private void button1_Click (object sender, EventArgs e)
        {
           
        }

        private void Form1_Load (object sender, EventArgs e)
        {

            listBox1.Items.Add(cola.GetInfo());
            listBox1.Items.Add(juice.GetInfo());
            monetka.AddProduct(cola, 150);
            monetka.AddProduct(juice, 150);
            monetka.WriteAllProducts(listBox1);
        }

        private void button5_Click (object sender, EventArgs e)
        {
            string autor = textBox3.Text;
            string title = textBox4.Text;
            Song song = new Song(autor, title);
            playlist.AddSong(song);
            listBox2.Items.Add(song);

        }
        private void spillOverSong()
        {
            Song currentSong = playlist.CurrentSong();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                string itemText = listBox2.Items[i].ToString();
                if (itemText == $"{currentSong.Title} - {currentSong.Author}")
                {
                    listBox2.SetSelected(i, true);
                    return;
                }
            }
            button4.Enabled = playlist.list.Count > 1;
            button6.Enabled = playlist.list.Count > 1;


        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (checkSym(kol1_txt.Text) && checkSym(sale_txt.Text))
            {
                product = new Product(name_txt.Text, Convert.ToInt32(sale_txt.Text));
                products.Add(name_txt.Text);
                comboBox1.Items.Add(name_txt.Text);
                monetka.AddProduct(product, Convert.ToInt32(kol1_txt.Text));
                monetka.WriteAllProducts(listBox1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int amount = 0;
            name_txt.Text = "";
            switch (comboBox1.Text)
            {
                case "Кола":
                    amount = 150;
                    break;
                case "Сок \"Добрый\"":
                    amount = 180;
                    break;
                case "":
                    amount = Convert.ToInt32(kol1_txt.Text);
                    break;
            }
            if (comboBox1.Text != "")
            {
                if (kol2_txt.Text != "")
                {
                    if (checkSym(kol2_txt.Text))
                    {
                        bool amountt = monetka.amountReturn();
                        if (amountt)
                        {
                            prib_lbl.Text = $"{int.Parse(prib_lbl.Text) + (product.Price * int.Parse(kol2_txt.Text))}";
                            amount -= int.Parse(kol2_txt.Text);
                            monetka.Sell(comboBox1.Text, int.Parse(kol2_txt.Text));
                            monetka.WriteAllProducts(listBox1);
                        }
                        
                    }
                    else
                        MessageBox.Show("Введи количество");
                }
                else
                    MessageBox.Show("Выбери товар");

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            playlist.BackSong();
            spillOverSong();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playlist.NextSong();
            spillOverSong();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            playlist.currentIndex = 0;
            spillOverSong();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            playlist.ClearPlaylist();
            listBox2.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < playlist.list.Count)
            {
                playlist.list.RemoveAt(selectedIndex);
                listBox2.Items.RemoveAt(selectedIndex);
                spillOverSong();
            }
        }
    }
}
