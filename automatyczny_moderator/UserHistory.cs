using System.Collections;

namespace automatyczny_moderator
{
    interface UserHistory
    {
        ArrayList getWarnings();
        void log(string status);
    }
}
