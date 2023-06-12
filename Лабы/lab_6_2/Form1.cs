using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_6
{
    public partial class Form1 : Form
    {
        int[] mas = new int[15];//делаем целый массив из 15-ти элементов
        Random rand = new Random();//делаем rand для генерации
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); //делаем очистку в левом столбике

            for (int i = 0; i < 15; i++)
            {
                mas[i] = rand.Next(-50, 50); // массиву номеру I, присвается рандомное число в промежутке от -50 до 50
                listBox1.Items.Add(mas[i]); //потом вы этот элемент добавляем в столбец
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            listBox2.Items.Clear();//делаем очистку в правом столбике
            
            int start = mas[14]; //заносим последний индекс в переменну.
            for (int i = 14; i > 0; i--)//алгоритм сдвига, сдвигает всё, последнйи отдельно заносм
            {
                mas[i] =mas[i-1];
                
                
            }
            mas[0] = start; //первый индекс присвется значение последенго индекса
            for (int i = 0; i < 15; i++) //алгоритм заноса в правый столбец
            {
                listBox2.Items.Add(mas[i]);


            }


           

        }
    }
}
