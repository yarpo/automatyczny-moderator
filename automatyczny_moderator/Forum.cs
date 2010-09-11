using MySql.Data.MySqlClient;
using System;
using System.Collections;
namespace automatyczny_moderator
{
    class Forum
    {
        private const string TABLE = "phpbb_posts";
        private const string ID_USER_COL = "poster_id";
        private const string POST_CONT_COL = "post_text";
        private const string POST_TIME_COL = "post_time";

        private const int ID_USER = 0;
        private const int POST_CONTENT = 1;
        private const int POST_TIME = 2;

        private Moderator moderator;

        public Forum(Moderator moderator)
        {
            this.moderator = moderator;
        }

        public ArrayList readPosts(string date)
        {
            string sql = createSQL(date);
            MySqlDataReader data = DatabaseSrc.query(sql);
            ArrayList result = new ArrayList();
            while (data.Read())
            {
                result.Add(
                    new Post(
                        data.GetInt32(ID_USER), 
                        data.GetString(POST_CONTENT), 
                        getDateTime(data.GetInt32(POST_TIME))
                    )
                );
            }

            return result;
        }

        private string createSQL(string date)
        {
            int time = getTimeStampFromDateString(date);
            string sql =
                "SELECT " +
                    ID_USER_COL + ", " +
                    POST_CONT_COL + ", " +
                    POST_TIME_COL + " " +
                "FROM " +
                    TABLE + " " +
                "WHERE 1 = 1 or " +
                    POST_TIME_COL + " >= " + time;
        }

        private DateTime getDateTime(int time)
        {
            return getFirstDateTime().AddSeconds(time);
        }

        private int getTimeStampFromDateString(string date)
        {
            DateTime oDate = DateTime.Parse(date);
            TimeSpan span = (oDate - getFirstDateTime().ToLocalTime());
            return (int)span.TotalSeconds;
        }

        private DateTime getFirstDateTime()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0);
        }

        public void moderate()
        {
            ModeratorLog modLog = this.moderator.getModeratorLog();
            string date = modLog.getLastModerationDate();

            Console.WriteLine("Ostatnia moderacja miała miejsce" + date);
            modLog.startOfWork();

            ArrayList posts = readPosts(date);
            foreach (Post post in posts)
            {
                SpellingResult sr = moderator.checkSpelling(post);
                moderator.jadgeSpelling(sr);
                SwearResult swr = moderator.checkSwearWords(post);
                moderator.jadgeSwearWords(swr);
                EmoticonsResult er = moderator.checkEmoticons(post);
                moderator.jadgeEmoticons(er);
            }
            modLog.endOfWork();
        }
    }
}
