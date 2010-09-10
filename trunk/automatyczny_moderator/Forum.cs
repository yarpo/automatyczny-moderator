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

        public ArrayList readPosts(string date)
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
                    POST_TIME_COL + " >= " + (time-2000000);

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
    }
}
