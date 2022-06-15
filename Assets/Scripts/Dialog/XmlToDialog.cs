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
        public static List<DialogItem> ReadDialog(string path, string id)
        {
            if (!File.Exists(path))
                return null;

            XDocument doc = XDocument.Load(path);

            var root = doc.Root;

            var dialogElement = root.Elements("Dialog").Where(e => e.Attribute("id").Value == id.ToString()).FirstOrDefault();
            
            return CreateItem(dialogElement);
        }

        private static List<DialogItem> CreateItem(XElement element)
        {
            List<DialogItem> toReturn = new List<DialogItem>();
            foreach (var item in element.Elements("Phrase"))
            {
                DialogItem dialog = new DialogItem();
                dialog.SetPhrase(item.Attribute("Text").Value);
                dialog.HasAction = bool.Parse(item.Attribute("HasAction").Value);

                foreach (var answer in item.Elements("Answer"))
                {
                    string text = answer.Attribute("Text").Value;
                    bool hasAction = bool.Parse(answer.Attribute("HasAction").Value);
                    DialogItem dialogItem = new DialogItem(text, CreateItem(answer));
                    dialogItem.HasAction = hasAction;
                    dialog.AddItem(dialogItem);
                }

                toReturn.Add(dialog);
            }

            return toReturn;
        }
    }
}
