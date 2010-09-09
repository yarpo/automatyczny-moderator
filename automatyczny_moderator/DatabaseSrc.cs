using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace automatyczny_moderator
{
    class DatabaseSrc
    {
        static public MySqlConnection connection = null;
        protected const string DB_HOST = "localhost";
        protected const string DB_NAME = "forum";
        protected const string DB_USER = "moderator";
        protected const string DB_PASS = "qwe123";

        static public MySqlConnection getConnection()
        {
            if (null == connection)
            {
                connection = new MySqlConnection(
                            "server=" + DB_HOST + 
                            ";database="+ DB_NAME +
                            ";uid=" + DB_USER +
                            ";password=" + DB_PASS
                );
                connection.Open();
            }
            return connection;
        }

        static public void closeConnection()
        {
            getConnection().Close();
        }

        static public MySqlDataReader query(string sql)
        {
            MySqlCommand mysqlCmd = new MySqlCommand(sql, connection);

            return mysqlCmd.ExecuteReader();
        }
    }
}

         /*
            string strSQL = "SELECT * FROM phpbb_posts";
            MySqlCommand mysqlCmd = new MySqlCommand(strSQL, connection);

            //open the connection
            connection.Open();
    }
}
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHunspell;
using MySql.Data.MySqlClient;

namespace proba_nhuspell
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;database=forum;uid=moderator;password=qwe123");

            string strSQL = "SELECT * FROM phpbb_posts";
            MySqlCommand mysqlCmd = new MySqlCommand(strSQL, connection);

            //open the connection
            connection.Open();

            MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();
            while (mysqlReader.Read())
            {
                Console.WriteLine(mysqlReader.GetInt32(0) + "\t" +
                    mysqlReader.GetString(15) + "\t" + mysqlReader.GetString(16));
            }

            //close the connection
            connection.Close();

            Console.WriteLine("NHunspell functions and classes demo");

            Console.WriteLine("");
            Console.WriteLine("Spell Check with with Hunspell");

            // Important: Due to the fact Hunspell will use unmanaged memory
            // you have to serve the IDisposable pattern
            // In this block of code this is be done
            // by a using block. But you can also call hunspell.Dispose()
            using (NHunspell.Hunspell hunspell = new Hunspell("pl_pl.aff", "pl_pl.dic"))
            {
                Console.WriteLine("Sprawdzam slowo 'rekomendacja'");
                bool correct = hunspell.Spell("Rekomendacja");
                Console.WriteLine("Rekomendacja jest napisana " +
                          (correct ? "porawnie" : "niepoprawnie"));

                Console.WriteLine("");
                Console.WriteLine("Sprawdzmy dla 'Rekomendaca'");
                List<string> suggestions = hunspell.Suggest("Rekomendaca");
                Console.WriteLine("Sa sugerowane slowa " + suggestions.Count.ToString());
                foreach (string suggestion in suggestions)
                {
                    Console.WriteLine("Podpowiedz: " + suggestion);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Hyphenation with Hyph");

            // Important: Due to the fact Hyphen will use unmanaged
            // memory you have to serve the IDisposable pattern
            // In this block of code this is be done by a using block.
            // But you can also call hyphen.Dispose()
            using (NHunspell.Hyphen hyphen = new Hyphen("hyph_en_us.dic"))
            {
                Console.WriteLine("Get the hyphenation of the word 'Recommendation'");
                NHunspell.HyphenResult hyphenated = hyphen.Hyphenate("Recommendation");
                Console.WriteLine("'Recommendation' is hyphenated as: " +
                                  hyphenated.HyphenatedWord);
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
*/