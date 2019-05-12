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
        private char[,] mass = new char[6,6];
        private string firstWord; //ВХОДНОЕ СЛОВО
        private string secondWord; //ВЫХОДНОЕ СЛОВО
        private char CH; //Символ Алфавита
        private string key;
        private int scifernum;//НОМЕР ОПЕРАЦИИ
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //вызываем шифровку
        {
            if (textBox1.Text == "") return;
            Chifer(true);
             
        }

        private void button2_Click(object sender, EventArgs e) //вызываем дешифровку
        {
            if (textBox1.Text == "") return;
            Chifer(false);
        }


        private void check(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { textBox1.Visible = false; scifernum = 1; button2.Visible = true; } 
            if (radioButton2.Checked) { textBox1.Visible = false; scifernum = 2; button2.Visible = true; }
            if (radioButton3.Checked) { textBox1.Visible = false; scifernum = 3; button2.Visible = true; }
            if (radioButton4.Checked) { textBox1.Visible = true; scifernum = 4; button2.Visible = true; }
            if (radioButton5.Checked) { textBox1.Visible = true; scifernum = 5; button2.Visible = false; }
            if (radioButton6.Checked) { textBox1.Visible = true; scifernum = 6; button2.Visible = true; }
            if (radioButton7.Checked) { textBox1.Visible = true; scifernum = 7; button2.Visible = true; }
            if (radioButton8.Checked) { textBox1.Visible = true; scifernum = 8; button2.Visible = true; }
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
                    trisemus(flagShif);
                        break;
                    case 5:
                    playfair(flagShif);
                        break;
                    case 6:
                    variantniy(flagShif);
                        break;
                    case 7:
                    vijiner(flagShif);
                        break;
                    case 8:
                    sovmesh(flagShif);
                        break;
            }
      
        }


        private void czeesar(bool flag)//ЦЕЗАРЬ
        {
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


        private void adbash(bool flag)//АТБАШ
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
            for (int i = 0; i < 6; i++)//двумерному массиву присваиваем алфавит
            {
                for (int j = 0; j < 6; j++)
                {
                    mass[i, j] = newalphabet[k++];  
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
                            secondWord += (mass[j, n] == firstWord[i]) ? Convert.ToString((j+1) * 10 + n+1) : "";
                        }
                    }
                }
                textBox3.Text = secondWord;
            }
            else
            {
                for (int i = 0; i < firstWord.Length - 1; i = i + 2) {
                    secondWord += mass[Convert.ToInt32(Convert.ToString(firstWord[i]))-1, Convert.ToInt32(Convert.ToString(firstWord[i + 1]))-1];                   
                }
                textBox3.Text = secondWord;
            }
            secondWord = "";
            newalphabet = ""; //обнуляем
        }


        private void trisemus(bool flag)//ТАБЛИЦА ТРИСЕМУСА
        {
            int k = 0;

            string newkey = Convert.ToString(key[0]);
            for (int i=0; i < key.Length; i++) // Убираем лишние символы
            {
                if (newkey.Contains(key[i])) continue;
                newkey += key[i];
            }
            newalphabet = newkey;
            for (int i = 0; i < alphabet.Length; i++) // генерируем новый алфавит(чтобы вставить его в матрицу)
            {
                if (newalphabet.Contains(alphabet[i])) continue;
                newalphabet += alphabet[i];
            }
            newalphabet += "./!";
            for (int i = 0; i < 6; i++)//двумерному массиву присваиваем новый алфавит
            {
                for (int j = 0; j < 6; j++)
                {
                    mass[i, j] = newalphabet[k++];  
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
                            if (mass[j, n] == firstWord[i])
                            {
                                secondWord += (j != 5) ? mass[j + 1, n] : mass[0, n];
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        for (int n = 0; n < 6; n++)
                        {
                            if (mass[j, n] == firstWord[i])
                            {
                                secondWord += (j != 0) ? mass[j - 1, n] : mass[5, n];
                            }
                        }
                    }
                }
            }
            textBox3.Text = secondWord;
            secondWord = "";
            newalphabet = ""; //обнуляем
        }


        private void playfair(bool flag)
        {
            int[] coords = new int[4];
            int k=0;
            string newfirstWord = "";
            string newkey = Convert.ToString(key[0]);
            for (int i = 0; i < key.Length; i++) // Убираем лишние символы
            {
                if (newkey.Contains(key[i])) continue;
                newkey += key[i];
            }
            newalphabet = newkey;
            for (int i = 0; i < alphabet.Length; i++) // генерируем новый алфавит(чтобы вставить его в матрицу)
            {
                if (newalphabet.Contains(alphabet[i])) continue;
                newalphabet += alphabet[i];
            }
            newalphabet += "./!";
            for (int i = 0; i < 6; i++)//двумерному массиву присваиваем новый алфавит
            {
                for (int j = 0; j < 6; j++)
                {
                    mass[i, j] = newalphabet[k++];
                }
            }
            k = 0;
            for (int i = 0; i < firstWord.Length-1; i = i + 2)
            {
                if (firstWord[i] == firstWord[i + 1])
                {
                    newfirstWord += firstWord[i].ToString() + "Я" + firstWord[i+1].ToString();
                }
                else if (firstWord[i] != firstWord[i + 1])
                {
                    newfirstWord += firstWord[i].ToString() + firstWord[i + 1].ToString();
                }
            }
            newfirstWord += (firstWord.Length % 2 == 0) ? firstWord[firstWord.Length-1].ToString() : firstWord[firstWord.Length - 1].ToString()+"Я";
            if (flag)
            {
                for (int i=0; i < newfirstWord.Length-1; i = i+2)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        for (int n = 0; n < 6; n++)
                        {
                            if (newfirstWord[i] == mass[j, n])
                            {
                                coords[0] = j; coords[1] = n;
                            }
                            if (newfirstWord[i + 1] == mass[j, n])
                            {
                                coords[2] = j; coords[3] = n;
                            }
                        }
                    }
                    if (coords[0] == coords[2])
                    {
                        coords[1] = (coords[1] == 5) ? -1 : coords[1];
                        coords[3] = (coords[3] == 5) ? -1 : coords[3];
                        secondWord += mass[coords[0], coords[1]+1].ToString() + mass[coords[2], coords[3]+1].ToString();
                    }
                    if (coords[1] == coords[3])
                    {
                        coords[0] = (coords[0] == 5) ? -1 : coords[0];
                        coords[2] = (coords[2] == 5) ? -1 : coords[2];
                        secondWord += mass[coords[0]+1, coords[1]].ToString() + mass[coords[2]+1, coords[3]].ToString();
                    }
                    if ((coords[1] != coords[3])&& (coords[0] != coords[2]))
                    {
                        secondWord += mass[coords[0], coords[3]].ToString() + mass[coords[2], coords[1]].ToString();
                    }
                }
            }
            else
            {

            }
            textBox3.Text = secondWord;
            secondWord = "";
            newalphabet = ""; //обнуляем
        }// ШИФР ПЛЕЙФЕЙР


        private void variantniy(bool flag)//ВАРИАНТНЫЙ ШИФР


        {
            string[,] varmas = new string[7, 7];
            string varalphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦ";
            int count = 0;
            int k = 0;
            string newkey = Convert.ToString(key[0]);
            for (int i = 0; i < key.Length; i++) // Убираем лишние символы
            {
                if (newkey.Contains(key[i])) continue;
                newkey += key[i];
            }
            newalphabet = newkey;
            for (int i = 0; i < alphabet.Length; i++) // генерируем новый алфавит(чтобы вставить его в матрицу)
            {
                if (newalphabet.Contains(alphabet[i])) continue;
                newalphabet += alphabet[i];
            }
            newalphabet += "./!";
            for (int i = 1; i < 7; i++)//двумерному массиву присваиваем новый алфавит
            {
                for (int j = 1; j < 7; j++)
                {
                    varmas[i, j] = newalphabet[k++].ToString();
                }
            }
            k = 0;
            for (int i = 0; i < 11; i += 2) 
            {
                varmas[++count, 0] = varalphabet[i].ToString() + varalphabet[i + 1].ToString();
            }
            count = 0;
            for (int i = 12; i < 23; i += 2)
            {
                varmas[0, ++count] = varalphabet[i].ToString() + varalphabet[i + 1].ToString();
            }
            Random rnd = new Random();
            int value1 = 0;
            int value2 = 0;
            if (flag)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    for(int j = 1; j < 7; j++)
                    {
                        for(int n=1; n < 7; n++)
                        {
                            if (varmas[j, n] == firstWord[i].ToString())
                            {
                                value1 = rnd.Next(0, 2);
                                value2 = rnd.Next(0, 2);
                                secondWord += Convert.ToString(varmas[j, 0][value1]) + Convert.ToString(varmas[0, n][value2]);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < firstWord.Length-1; i+=2)
                {
                    for (int j = 1; j < 7; j++)
                    {
                        if (varmas[j, 0].Contains(firstWord[i])) value1 = j;
                    }
                    for (int j = 1; j < 7; j++)
                    {
                        if (varmas[0, j].Contains(firstWord[i+1])) value2 = j;
                    }
                    secondWord += varmas[value1, value2];

                }
                        }
            textBox3.Text = secondWord;
            secondWord = "";
            newalphabet = "";
            value1 = value2 = 0;//обнуляем
        }


        private void vijiner(bool flag)//ШИФР ВИЖИНЕРА
        {
            string[] alphabetmas = new string[key.Length]; //Массив из строк
            string keyfirstWord = "";
            int count = 0;
            for (int i = 0; i < firstWord.Length; i++) //Закрываем обычное слово ключами
            {
                keyfirstWord += key
[count];
                count = (count < key.Length - 1) ? count + 1 : 0;
            }
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = alphabet.IndexOf(key[i]); j < alphabet.Length; j++) //присваиваем буквы с  нужной в начало
                {
                    alphabetmas[i] += alphabet[j];
                }
                for (int j = 0; j < alphabet.IndexOf(key[i]); j++) //присваисваем предыдущие буквы в конец
                {
                    alphabetmas[i] += alphabet[j];
                }
            }
            if (flag)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    for (int j = 0; j < alphabetmas.Length; j++)
                    {
                        if (keyfirstWord[i] == alphabetmas[j][0])   //Если символ замещённого ключами слова == первому символу строки одного элемента массива, то в нём
                        {
                            secondWord += alphabetmas[j][alphabet.IndexOf(firstWord[i])]; //мы берём символ с равным индексом относительно нормального алфавита 
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    for (int j = 0; j < alphabetmas.Length; j++)
                    {
                        if (keyfirstWord[i] == alphabetmas[j][0])
                        {
                            for (int m = 0; m < alphabet.Length; m++)
                            {
                                if (firstWord[i] == alphabetmas[j][m])
                                {
                                    secondWord += alphabet[m];
                                }
                            }
                        }
                    }
                }
            }
            textBox3.Text = secondWord;
            secondWord = "";
            newalphabet = "";
        }


        private void sovmesh(bool flag)//СОВМЕЩЁННЫЙ ШИФР
        {
            string[,] sovmas = new string[5,10];
            string newkey = Convert.ToString(key[0]);
            int count = 0;

            for (int i = 0; i < key.Length; i++) // Убираем лишние символы
            {
                if (newkey.Contains(key[i])) continue;
                newkey += key[i];
            }
            if (newkey.Length > 10)
            {
                MessageBox.Show("Ключ длиннее 10");
                return;
            }
            for (int i = 0; i < alphabet.Length; i++) // Убираем лишние символы в новом алфавите
            {
                if (newkey.Contains(alphabet[i])) continue;
                newalphabet += alphabet[i];
            }
            for (int i = 0; i < newkey.Length; i++) // В первую строку заправляем ключ
            {
                sovmas[0,i] = newkey[i].ToString();
            }
            for (int i = 1; i < 4; i++) // В остальные строки заправляем новый алфавит
            {
                for (int j = 0; j < 10; j++)
                {
                    if (count >= newalphabet.Length)
                    {
                        sovmas[i, j] = "!";
                        continue;
                    } 
                    sovmas[i, j] = newalphabet[count++].ToString();
                }
                
            }
            string[] masfirstWord = firstWord.Split(Convert.ToChar(" ")); // Для дешифровки разбиваем строку
            if (flag)
            {
                for (int n = 0; n < firstWord.Length; n++)  // Если символы совпадают, мы просто прибавляем строку из индексов с пробелом
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (firstWord[n].ToString() == sovmas[i, j])
                            {
                                string chisl = (j == 0) ? Convert.ToString(i * 10 + 0)+" " : Convert.ToString(i * 10 + 10 - j)+" ";
                                secondWord += chisl;
                            }
                        }
                    }
                }
                
            }
            else
            {
                for(int i = 0; i < masfirstWord.Length - 1; i++) // Я не буду это объяснять
                {
                    string chisl = (Convert.ToInt32(masfirstWord[i]) % 10 == 0) ? sovmas[Convert.ToInt32(masfirstWord[i]) / 10, 0]  : sovmas[Convert.ToInt32(masfirstWord[i])/10, 10 - Convert.ToInt32(masfirstWord[i])%10] ;
                    secondWord += chisl;
                }
            }
            textBox3.Text = secondWord;
            secondWord = "";
            newalphabet = ""; //обнуляем
        }
    }
}
