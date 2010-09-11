using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace automatyczny_moderator
{
    class EmoticonsResult
    {
        public int Iduser;
        public int Words;
        public int Counter;

        public double Procentage
        {
            get { return (double)Counter / (double)Words * 100; }
            private set { }
        }
    }
}
