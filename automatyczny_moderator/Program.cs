using System;
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
                Forum forum = new Forum();
                ArrayList posts = forum.readPosts(date);
                Moderator moderator = new ModeratorImpl();
                SpellingResult sr = moderator.checkSpelling(posts[0] as Post);
                SwearResult swr = moderator.checkSwearWords(posts[0] as Post);
                var b = moderator.checkEmoticons(posts[1] as Post);
                modLog.endOfWork();
            }
            view.goodByeScreen();
        }
    }
}
