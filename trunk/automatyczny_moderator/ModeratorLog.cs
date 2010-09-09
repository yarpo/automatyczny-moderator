using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace automatyczny_moderator
{
    public interface ModeratorLog
    {
        string getLastModerationDate();
        void setLastModerationDate();
        void setLastModerationDate(string date);
        void log(string status);
    }
}
