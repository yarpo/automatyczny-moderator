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
                
                Forum forum = new Forum();
                forum.moderate(new ModeratorImpl(new ModeratorLogDB()));
            }
            view.goodByeScreen();
        }
    }
}
