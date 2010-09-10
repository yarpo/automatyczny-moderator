using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace automatyczny_moderator
{
    class SpellingResult
    {
        private double procentage;

        public double Procentage
        {
            get { return procentage; }
            set { procentage = value; }
        }
        public ArrayList MisspelledWords = new ArrayList();

        private int words;

        public int Words
        {
            get { return words; }
            set { words = value; }
        }
        private int misspelled = 0;

        public int Misspelled
        {
            get { return MisspelledWords.Count; }
            private set { }
        }
    }
}
