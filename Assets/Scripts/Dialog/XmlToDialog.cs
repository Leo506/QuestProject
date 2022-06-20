using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace DialogSystem
{
    public class XmlToDialog
    {
        /// <summary>
        /// Создает структуру диалога, используя xml-файл
        /// </summary>
        /// <param name="path">Путь к файлу диалога</param>
        /// <param name="id">id диалога</param>
        /// <returns></returns>
        public static Phrase ReadDialog(string path, string id)
        {
            if (!File.Exists(path))
                return null;

            XDocument doc = XDocument.Load(path);

            return CreateDialog(doc, id);
        }



        /// <summary>
        /// Создает структуру диалога, используя строки xml
        /// </summary>
        /// <param name="str">xml, представленный в виде строки</param>
        /// <param name="id">id диалога</param>
        /// <returns></returns>
        public static Phrase ReadDialogByString(string str, string id)
        {
            XDocument doc = XDocument.Parse(str);

            return CreateDialog(doc, id);
        }


        private static Phrase CreateDialog(XDocument doc, string id)
        {
            var root = doc.Root;

            var dialogElement = root.Elements("Dialog").Where(e => e.Attribute("id").Value == id.ToString()).FirstOrDefault();

            return CreateItem(dialogElement, "start");
        }

        private static Phrase CreateItem(XElement element, string id)
        {
            var phraseElement = element.Elements("Phrase").Where(e => e.Attribute("id").Value == id).FirstOrDefault();
            Phrase phrase = new Phrase();
            phrase.Text = phraseElement.Attribute("Text").Value;

            foreach (var answer in phraseElement.Elements("Answer"))
            {
                Answer answer1 = new Answer();
                answer1.Text = answer.Attribute("Text").Value;
                //UnityEngine.Debug.Log(answer1.Text);
                if (answer.Attribute("next") != null)
                    answer1.Next = CreateItem(element, answer.Attribute("next").Value);
                else
                {
                    answer1.Next = null;
                    answer1.Exit = true;
                }

                if (answer.Attribute("HasAction") != null)
                    answer1.HasAction = bool.Parse(answer.Attribute("HasAction").Value);

                phrase.answers.Add(answer1);
            }

            return phrase;
        }
    }
}
