using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace automatyczny_moderator
{
    class EmoticonsResult
    {
        public double Procentage
        {
            get { return (double)counter / (double)words * 100; }
            private set { }
        }

        private int words;

        public int Words
        {
            get { return words; }
            set { words = value; }
        }

        private int counter;

        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }
    }
}
