using System.Collections;

namespace automatyczny_moderator
{
    class SwearResult
    {
        public int Iduser;

        public double Procentage
        {
            get { return (double)Swears/(double)Words * 100; }
            private set { }
        }
        public ArrayList SwearWords = new ArrayList();

        public int words;

        public int Swears
        {
            get { return SwearWords.Count; }
            private set { }
        }
    }
}
