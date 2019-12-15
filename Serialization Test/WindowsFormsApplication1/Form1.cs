using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string current = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();
        private string text1 = " ";
        public Dictionary<string, string> org = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            try// !!!!!!!!! При инициализации Читаем бинарный файл
            {
                Stream file = File.OpenRead("data.txt");
                BinaryFormatter fileRead = new BinaryFormatter();

                Data data = (Data)fileRead.Deserialize(file);
                file.Close();
                org = data.org;
            }
            catch {
                org = new Dictionary<string, string>();
            }// !!!!!!!!!
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            org[current] = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            text1 = textBox1.Text;
            org[current] = text1;
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            current = monthCalendar1.SelectionStart.Day.ToString();
            current += "." + monthCalendar1.SelectionStart.Month.ToString();
            current += "." + monthCalendar1.SelectionStart.Year.ToString();
            try { org.Add(current, text1); org[current] = ""; } catch { }
            textBox1.Text = org[current];
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();// !!!!!!!!! при закрытии сохраняем бинарный файл
            using (FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate))
            {
                Data data = new Data(org);
                formatter.Serialize(fs, data);// !!!!!!!!!
            }
        }
        [Serializable]// !!!!!!!!! Обьявляем класс с переменными для сериализации.
        public class Data
        {
            public Dictionary<string, string> org;

            public Data(Dictionary<string, string> org) {
                this.org = org;
            }
        }// !!!!!!!!!

    }
}
