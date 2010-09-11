using System.Collections;

namespace automatyczny_moderator
{
    class SwearResult
    {
        public int Iduser;

        public ArrayList SwearWords = new ArrayList();

        private int words;

        public int Words
        {
            get { return words; }
            set { words = value; }
        }

        public int Swears
        {
            get { return SwearWords.Count; }
            private set { }
        }
    }
}
