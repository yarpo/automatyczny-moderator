using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace automatyczny_moderator
{
    public class Post
    {
        private int iduser;

        public int Iduser
        {
            get { return iduser; }
            set { iduser = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Post(int iduser, string post, DateTime date)
        {
            this.iduser = iduser;
            this.content = post;
            this.date = date;
        }

        
    }
}
