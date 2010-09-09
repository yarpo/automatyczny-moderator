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
            view.appInfo();

            DatabaseSrc.getConnection();
            DatabaseSrc.query("INSERT INTO `forum`.`phpbb_words` (`word_id` , `word` , `replacement` ) VALUES ( NULL , 'aaa', 'bbb' );");
            DatabaseSrc.closeConnection();
            Console.Read();
        }
    }
}
