using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_2._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);
                double c = double.Parse(txtC.Text);
                double xStart = double.Parse(txtXStart.Text);
                double xEnd = double.Parse(txtXEnd.Text);
                double dx = double.Parse(txtStep.Text);

                Cal(a, b, c, xStart, xEnd, dx);
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат ввода. Пожалуйста, введите числовые значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Cal(double a, double b, double c, double xStart, double xEnd, double dx)
        {
            dataGridView1.Rows.Clear();

            for (double x = xStart; x <= xEnd; x += dx)
            {
                double result = CalFun(a, b, c, x);

                int rowId = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowId];
                row.Cells[0].Value = x;
                row.Cells[1].Value = result;
            }
        }

        private double CalFun(double a, double b, double c, double x)
        {
            double result;

            if (x < 0 && b != 0)
                result = a * x * x + b;
            else if (x > 0 && b == 0)
                result = (x - a) / (x - c);
            else
                result = a * x / c;

            return result;
        }


    }
}
