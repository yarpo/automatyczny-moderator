using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace automatyczny_moderator
{
    class SpellingResult
    {
        public double Procentage
        {
            get { return (double)Misspelled/(double)words * 100; }
            private set { }
        }
        public ArrayList MisspelledWords = new ArrayList();

        private int words;

        public int Words
        {
            get { return words; }
            set { words = value; }
        }

        public int Misspelled
        {
            get { return MisspelledWords.Count; }
            private set { }
        }
    }
}
