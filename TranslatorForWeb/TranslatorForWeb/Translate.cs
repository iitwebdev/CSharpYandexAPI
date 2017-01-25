using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;//Пакет JSON

namespace TranslatorForWeb
{
    class Translate
    {
        public string TranslateText(string s, string language)
        {
            if (s.Length > 0)//Проверка на непустую строку
            {
                //---Запрос---
                WebRequest request = WebRequest.Create("https://translate.yandex.net/api/v1.5/tr.json/translate?"
                    + "key=trnsl.1.1.20170125T084253Z.cc366274cc3474e9.68d49c802348b39b5d677c856e0805c433b7618c"//Ключ
                    + "&text=" + s//Текст
                    + "&lang=" + language);//Язык

                WebResponse response = request.GetResponse();
                //--------------------
                //---Распарсить JSON ответ. Я скачал фреймворк Json.NET
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = stream.ReadLine()) != null)
                    {
                        Translation translation = JsonConvert.DeserializeObject<Translation>(line);
                        s = "";
                        foreach (string str in translation.text)
                        {
                            s += str;
                        }
                    }
                }
                //------------------
                return s;
            }
            else
                return "";
        }
    }

    class Translation
    {
        public string code { get; set; }
        public string lang { get; set; }
        public string[] text { get; set; }
    }
}