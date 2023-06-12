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

namespace lab_7_2
{
    public partial class Form1 : Form
    {

        int[,] mas = new int[1, 1];//объявляем массив
        Random rand = new Random();//делаем рандом для генерации
        //тех.переменные и флаги
        int r = 1;
        int rr = 1;
        int lik = 0;
        int k = 1;
        int l = 1;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("", "");//делаем столбец
            dataGridView1.Rows.Add("", " ");//делаем строку, это надо, чтобы в начале показывалась
        }

        private void button1_Click(object sender, EventArgs e) //генерируем и заносим в таблицу массив
        {
            for (int i = 0; i < k; i++)
            {

                for (int a = 0; a < l; a++)
                {
                    mas[i, a] = rand.Next(0, 256);
                    dataGridView1.Rows[i].Cells[a].Value = mas[i, a];

                }
             
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sred = 0;//количество элементов
            int dd = 0;//сумма

            

            for(int i =0; i<dataGridView1.RowCount; i++)//алгоритм, который находит среднее через два цикла и проверки по условию задания
            {
                for(int a =0; a< dataGridView1.ColumnCount; a++)
                {
                    int kim = mas[i, a] % 2;
                    if (i>a && kim==0)
                    {
                        sred++;
                        mas[i, a] = int.Parse(dataGridView1.Rows[i].Cells[a].Value.ToString());
                        dd = dd + mas[i, a];
                    }
                }

            }

            double link = dd / sred;
            label3.Text = "Среднее значение = " +link+" "+dd; //выводим среднее
        }

        //Поверка флагов на режимах, если стоит, то показывает, если нет, то не показыват
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
               
                dataGridView1.ReadOnly = false;
            }
            else
            {
         
                dataGridView1.ReadOnly = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                button1.Visible = true;

            }
            else
            {
                button1.Visible = false;
            }
        }


        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // регулируем солбцы таблици и задаём размер одного из значений. Аналогично со строками

            numericUpDown1.Maximum = 256;
            l = Convert.ToInt32(numericUpDown1.Value.ToString());


            mas = new int[k, l];


            //алгоритм регулировки
            if (r - l < 0)
            {
                r++;
                dataGridView1.Columns.Add("", " ");
            }

            if (r - l > 0)
            {
                dataGridView1.Columns.RemoveAt(r - 1);
                r--;
            }

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            numericUpDown2.Maximum = 256;
            k = Convert.ToInt32(numericUpDown2.Value.ToString());
            mas = new int[k, l];


            //
            if (rr - k < 0)
            {
                rr++;
                dataGridView1.Rows.Add(" ", "");
            }

            if (rr - k > 0)
            {
                dataGridView1.Rows.RemoveAt(k - 1);
                rr--;
            }

        }
    }
}
