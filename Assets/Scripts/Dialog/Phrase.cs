using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogSystem
{
    public class Phrase
    {
        public string Text { get; set; }
        public List<Answer> answers = new List<Answer>();
    }
}
