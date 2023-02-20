using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TouristsForm
{
    public partial class Form1 : Form
    {
        CityData[] cities = new CityData[] {
                    new CityData  (1, "Берлин", 399, 175),
                    new CityData  (2, "Прага", 300, 175),
                    new CityData  (3, "Париж", 350, 220),
                    new CityData  (4, "Рига", 250, 170),
                    new CityData  (5, "Лондон", 390, 270),
                    new CityData  (6, "Ватикан", 500, 350),
                    new CityData  (7, "Палермо", 230, 150),
                    new CityData  (8, "Варшава", 300, 190),
                    new CityData  (9, "Кишинев", 215, 110),
                    new CityData  (10, "Мадрид", 260, 190),
                    new CityData  (11, "Будапешт", 399, 175)
        };

        public int countCitiesToVisit;
        public int departureCity;
        public int budget;
        public int price;

        public double tripPrice;

        List<TextBox> textBoxes = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            countCitiesToVisit = int.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            departureCity = int.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            budget = int.Parse(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CityData> select = new List<CityData>();

            tripPrice= 0;

            if (budget <= 0)
            {
                MessageBox.Show("Введите свой бюджет!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < cities.Length; i++)
                {
                    if (cities[i].ToString() == textBox2.Text)
                    {
                        select.Add(cities[i]);
                    }
                    for (int j = 0; j < textBoxes.Count; j++)
                    {
                        if (cities[i].ToString() == textBoxes[j].Text)
                        {
                            select.Add(cities[i]);
                        }
                    }
                }

                for (int i = 1; i < select.Count; i++)
                {
                    tripPrice += CalculatePrice(price, cities, select[0], select[i]);
                }

                label8.Text = tripPrice.ToString();

                if(tripPrice > budget)
                {
                    MessageBox.Show($"Сумма поездки = {tripPrice}, ваш бюджет = {budget}, вам не хватает {tripPrice - budget}", "К сожалению вашего бюджета не хватит для этой поездки :(", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] textBox = new TextBox[countCitiesToVisit];

            this.AutoSize = true;
            if(countCitiesToVisit> 3) 
            {
                MessageBox.Show("Количество городов должно быть не больше 3!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < countCitiesToVisit; i++)
                {
                    if (i < 3)
                    {
                        textBox[i] = new TextBox();
                        textBox[i].Top = 300 + i * 25;
                        textBox[i].Left = 350;
                        this.Controls.Add(textBox[i]);
                        textBoxes.Add(textBox[i]);
                    }
                }
            }   
        }

        static double CalculatePrice(double calculatePrice, CityData[] cities, CityData firstCity, CityData secondCity)
        {
            calculatePrice += secondCity.price;

            if (secondCity.id == 1)
            {
                calculatePrice += cities[1].price * 1.13 - cities[1].price;
                calculatePrice += cities[1].price * 1.04 - cities[1].price;
            }

            if (secondCity.id == 2)
                calculatePrice += cities[2].price * 1.04 - cities[2].price;

            if (secondCity.id == 3)
                calculatePrice += cities[3].price * 1.04 - cities[3].price;

            if (secondCity.id == 4)
            {
                calculatePrice += cities[8].transit;
                if (firstCity.id == 3) calculatePrice += cities[4].price * 1.09 - cities[4].price;
                calculatePrice += cities[4].price * 1.04 - cities[4].price;
                if (firstCity.id == 7) calculatePrice += cities[8].transit + cities[1].transit;
            }

            if (secondCity.id == 5)
                calculatePrice += cities[3].price;


            if (secondCity.id == 7)
            {
                if (firstCity.id == 5) calculatePrice += cities[7].price * 1.07 - cities[7].price;
                if (firstCity.id == 9) calculatePrice += cities[7].price * 1.11 - cities[7].price;
                calculatePrice += cities[7].price * 1.04 - cities[7].price;
                if (firstCity.id == 4) calculatePrice += cities[8].transit + cities[1].transit;
            }

            if (secondCity.id == 8)
                calculatePrice += cities[8].price * 1.04 - cities[8].price;

            if (secondCity.id == 9)
                calculatePrice += cities[11].transit;

            if (secondCity.id == 10)
            {
                calculatePrice += cities[3].transit;
                calculatePrice += cities[10].price * 1.04 - cities[10].price;
            }

            if (secondCity.id == 11)
                calculatePrice += cities[11].price * 1.04 - cities[11].price;

            return calculatePrice;
        }
    }
}
