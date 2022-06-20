using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogSystem
{
    public class Answer
    {
        public string Text { get; set; }

        public Phrase Next { get; set; }

        public bool Exit = false;
    }
}
