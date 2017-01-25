using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranslatorForWeb
{
    public partial class Form1 : Form
    {
        ComboBox forSwap;//Для свапа выбранных языков
        Translate YandexAPI;
        public Form1()
        {
            InitializeComponent();
            //---Первоначальные языки в боксах---
            comboBox1.SelectedItem = "Английский";
            comboBox2.SelectedItem = "Русский";
            //---
            //---Для свапа выбранных языков---
            forSwap = new ComboBox();
            forSwap.Items.AddRange(new object[] {
            #region Бокс для свапа
            "Английский",
            "Иврит",
            "Испанский",
            "Итальянский",
            "Китайский",
            "Немецкий",
            "Русский",
            "Французский",
            "Японский"});
            #endregion
            //---
            YandexAPI = new Translate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //===================Кнопка свапа языков========================
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            forSwap.SelectedItem = comboBox2.SelectedItem;
            comboBox2.SelectedItem = comboBox1.SelectedItem;
            comboBox1.SelectedItem = forSwap.SelectedItem;
        }
        //==============================================================

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            #region Преобразование языка в код
            string inputlang;//Начальный язык
            inputlang = (String)Convert.ChangeType(comboBox1.SelectedItem, typeof(String));//Значение из первого бокса
            string outputlang;//Язык перевода
            outputlang = (String)Convert.ChangeType(comboBox2.SelectedItem, typeof(String));//Значение из второго бокса
            //===Преобразование названия языка в его кодовое значение===
            //---Для начального языка
            switch (inputlang)
            {
                case "Английский": inputlang = "en"; break;
                case "Русский": inputlang = "ru"; break;
                case "Иврит": inputlang = "he"; break;
                case "Испанский": inputlang = "es"; break;
                case "Итальянский": inputlang = "it"; break;
                case "Китайский": inputlang = "zh"; break;
                case "Немецкий": inputlang = "de"; break;
                case "Французский": inputlang = "fr"; break;
                case "Японский": inputlang = "ja"; break;
            }
            //---
            //---Для языка перевода
            switch (outputlang)
            {
                case "Английский": outputlang = "en"; break;
                case "Русский": outputlang = "ru"; break;
                case "Иврит": outputlang = "he"; break;
                case "Испанский": outputlang = "es"; break;
                case "Итальянский": outputlang = "it"; break;
                case "Китайский": outputlang = "zh"; break;
                case "Немецкий": outputlang = "de"; break;
                case "Французский": outputlang = "fr"; break;
                case "Японский": outputlang = "ja"; break;
            }
            //---
            //==========================================================
            #endregion
            string language = string.Format("{0}-{1}", inputlang, outputlang);//Итоговая строка языков с кодами
            richTextBox2.Text = YandexAPI.TranslateText(richTextBox1.Text, language);
        }

    }
}
