using System.Collections;

namespace automatyczny_moderator
{
    interface UserHistory
    {
        ArrayList getWarnings();
        void log(string status);
        string ort(string msg, int n);
        string ort(string msg);
        string swears(string msg);
        string emots(string msg);
    }
}
