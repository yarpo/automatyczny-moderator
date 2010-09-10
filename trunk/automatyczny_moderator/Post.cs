using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace automatyczny_moderator
{
    public class Post
    {
        private int iduser;
        private string post;
        private DateTime date;

        public Post(int iduser, string post, DateTime date)
        {
            this.iduser = iduser;
            this.post = post;
            this.date = date;
        }

        
    }
}
