using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace automatyczny_moderator
{
    class SpellingResult
    {
        public int Iduser;

        public double Procentage
        {
            get { return (double)Misspelled/(double)Words * 100; }
            private set { }
        }
        public ArrayList MisspelledWords = new ArrayList();

        public int Words;

        public int Misspelled
        {
            get { return MisspelledWords.Count; }
            private set { }
        }
    }
}
