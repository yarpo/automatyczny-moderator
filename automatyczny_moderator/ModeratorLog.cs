using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace automatyczny_moderator
{
    public interface ModeratorLog
    {
        string getLastModerationDate();
        void startOfWork();
        void reading();
        void endOfWork();
        void log(string status);
    }
}
