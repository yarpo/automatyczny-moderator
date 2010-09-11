using System.Collections;

namespace automatyczny_moderator
{
    interface UserHistory
    {
        void log(string status);
        void ort(string msg, int n);
        void ort(string msg);
        string swears(string msg);
        string emots(string msg);
    }
}
