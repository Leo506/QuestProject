using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogSystem
{
    public class DialogItem
    {
        public string Phrase;

        public List<DialogItem> Items;

        public bool HasAction = false;

        public DialogItem()
        {
            Phrase = "";
            Items = new List<DialogItem>();
        }

        public DialogItem(string phrase, List<DialogItem> items)
        {
            Phrase = phrase;
            Items = items;
        }

        public void AddItem(DialogItem item)
        {
            Items.Add(item);
        }

        public void SetPhrase(string phrase)
        {
            Phrase = phrase;
        }

        public override string ToString()
        {
            string toReturn = '\n' + Phrase + "\n";
            foreach (DialogItem item in Items)
                toReturn += "-" + item.Phrase + "\n";

            return toReturn;
        }
    }
}
