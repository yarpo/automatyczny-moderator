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
        public int words;
        public int counter;

        public double Procentage
        {
            get { return (double)counter / (double)words * 100; }
            private set { }
        }
    }
}
