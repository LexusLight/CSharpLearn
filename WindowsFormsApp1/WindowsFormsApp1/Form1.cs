using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {   
        private string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"; //33 - 36   КЛАССИЧЕСКИЙ АЛФАВИТ
        private string newalphabet; // ДЛЯ ОПЕРАЦИЙ С АЛФАВИТОМ
        private char[,] polimass = new char[6,6];
        private string key; //КЛЮЧ ШИФРА
        private string firstWord; //ВХОДНОЕ СЛОВО
        private string secondWord; //ВЫХОДНОЕ СЛОВО
        private char CH; //Символ Алфавита
        private int scifernum;//НОМЕР ОПЕРАЦИИ
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //вызываем шифровку
        {
            Chifer(true);
             
        }

        private void button2_Click(object sender, EventArgs e) //вызываем дешифровку
        {
            Chifer(false);
        }
        private void check(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { textBox1.Visible = false; scifernum = 1; } 
            if (radioButton2.Checked) { textBox1.Visible = false; scifernum = 2; }
            if (radioButton3.Checked) { textBox1.Visible = false; scifernum = 3; }
            if (radioButton4.Checked) { textBox1.Visible = true; scifernum = 4; }
            if (radioButton5.Checked) { textBox1.Visible = true; scifernum = 5; }
            if (radioButton6.Checked) { textBox1.Visible = false; scifernum = 6; }
            if (radioButton7.Checked) { textBox1.Visible = true; scifernum = 7; }
            if (radioButton8.Checked) { textBox1.Visible = true; scifernum = 8; }
        }
        private void Chifer(bool flagShif)
        {
            key = textBox1.Text;
            firstWord = textBox2.Text;
            switch (scifernum) {
                    case 1:
                    czeesar(flagShif);
                        break;
                    case 2:
                    adbash(flagShif);
                        break;
                    case 3:
                    polibian(flagShif);
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
            }
      
        }
        private void czeesar(bool flag) {
            for (int i = 3; i < alphabet.Length; i++) //присваиваем символы кроме первых трёх в начало строки
            {
                newalphabet += alphabet[i];
            }
            for (int i = 0; i < 3; i++) //присваисваем АБВ в конец
            {
                newalphabet += alphabet[i];
            }
            if (flag) //зашифровка
            {   

                for (int i = 0; i < firstWord.Length; i++)//ищем символ по индексу нормального алфавита
                { 
                    CH = firstWord[i];
                    secondWord += newalphabet[alphabet.IndexOf(CH)];
                }
                textBox3.Text = secondWord;
            }
            else
            {  //расшифровка
                for (int i = 0; i < firstWord.Length; i++)//ищем символ по индексу преобразованного алфавита
                {
                    CH = firstWord[i];
                    secondWord += alphabet[newalphabet.IndexOf(CH)];
                }
                textBox3.Text = secondWord;
            }
            secondWord = "";
            newalphabet = ""; //обнуляем
        }

        private void adbash(bool flag)//ПОЛИБЕАНСКИЙ КВАДРАТ
        {
            for (int i = alphabet.Length - 1; i > -1; i--) { //Тупо переворачиваем строку можно реверсом, но я решил так
                newalphabet += alphabet[i];             
            }
            if(flag)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    secondWord += newalphabet[alphabet.IndexOf(firstWord[i])];
                    textBox3.Text = secondWord;
                }
            }
            else
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    secondWord += alphabet[newalphabet.IndexOf(firstWord[i])];
                    textBox3.Text = secondWord;
                }
            }
            secondWord = "";
            newalphabet = ""; //обнуляем
        }
        private void polibian(bool flag)//ПОЛИБЕАНСКИЙ КВАДРАТ
        {
            int k=0;
            newalphabet += alphabet + "./_"; // дополняем до 36 символов
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    polimass[i, j] = newalphabet[k++];  //двумерному массиву присваиваем алфавит
                }
            }
            k = 0;
            if (flag)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        for (int n = 0; n < 6; n++)
                        {
                            secondWord += (polimass[j, n] == firstWord[i]) ? Convert.ToString((j+1) * 10 + n+1) : "";
                        }
                    }
                }
                textBox3.Text = secondWord;
            }
            else
            {
                
                textBox3.Text = secondWord;
            }
            secondWord = "";
            newalphabet = ""; //обнуляем
        }
    }
}
