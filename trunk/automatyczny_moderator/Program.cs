using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace automatyczny_moderator
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface view = new Interface();
            if (view.startModerator())
            {
                ModeratorLog modLog = new ModeratorLogDB();
                string date = modLog.getLastModerationDate();
                Console.WriteLine(date);
                modLog.startOfWork();
                UserHistory userLog = new UserHistoryDB(1);
                userLog.ban("BAN");
                modLog.endOfWork();
            }
            view.goodByeScreen();
        }
    }
}
