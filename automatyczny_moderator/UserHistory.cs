using System.Collections;

namespace automatyczny_moderator
{
    interface UserHistory
    {
        ArrayList getWarnings();
        void log(string status);
        void warning(string msg);
        void deletePost(string msg);
        void ban(string msg);
        void deleteUser(string msg);
    }
}
