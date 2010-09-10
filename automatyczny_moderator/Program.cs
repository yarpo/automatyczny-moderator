﻿using System;
using System.Collections.Generic;
using System.Collections;

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
                Forum forum = new Forum();
                ArrayList a = forum.readPosts(date);
                Moderator moderator = new ModeratorImpl();
                SpellingResult sr = moderator.checkSpelling(a[0] as Post);
                SwearResult swr = moderator.checkSwearWords(a[0] as Post);
                moderator.checkEmoticons(a[0] as Post);
                modLog.endOfWork();
            }
            view.goodByeScreen();
        }
    }
}
