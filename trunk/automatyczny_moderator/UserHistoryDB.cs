using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace automatyczny_moderator
{
    public class UserHistoryDB : UserHistory
    {
        const string TABLE = "automod_ulog";
        const int NO_PENALITY_POINTS = 0;
        const int ACTIVE = 1;
        const int DELETED = 0;

        private int iduser;

        public UserHistoryDB( int id )
        {
            this.iduser = id;
        }

        #region UserHistory Members

        public void log(string status)
        {
            log(status, ACTIVE);
        }

        public void log(string msg, int status)
        {
            string now = getCurrentDateString();
            string sql = "INSERT INTO " + TABLE + 
                "(id, iduser, date, info, status)" +
                " VALUES (NULL," + this.iduser + 
                ", '" + now + "', '" + msg + "', " + status + ")";
            DatabaseSrc.query(sql);
        }

        public string ort(string msg, int n)
        {
            string result = "";
            while (n-- > 0)
            {
                log(msg);
                result = updateOrt();
            }
            return result;
        }

        public string ort(string msg)
        {
            return ort(msg, 1);
        }

        private string updateOrt()
        {
            updateOrtInfo();
            updateOrtWarn();
            updateOrtDisq();
            updateOrtBan();

           return "";
        }

        private int getNumberOfInfos(string info)
        {
            string sql =
                "SELECT count(*) FROM automod_ulog WHERE iduser = " +
                    this.iduser + " AND status = " + ACTIVE +
                    " AND info like('" + ModeratorImpl.ORT_INFO + "')";
            MySqlDataReader data = DatabaseSrc.query(sql);

            return (data.Read()) ? data.GetInt32(0) : 0;
        }

        private string updateOrtInfo()
        {
            int ortInfo = getNumberOfInfos(ModeratorImpl.ORT_INFO);
            if (ortInfo >= 10)
            {
                delete(ModeratorImpl.ORT_INFO); // usun te notki
                log(ModeratorImpl.ORT_WARN); // dodaj warning
            }

            return "";
        }

        private void delete(string info)
        {
            string sql =
                "UPDATE " + TABLE + " SET status = " + DELETED +
                " WHERE iduser = " + iduser + " AND info = '" + info +"'" ;
            DatabaseSrc.query(sql);
        }

        private string updateOrtWarn()
        {
            // odczytaj ile jest ORT_WARN
            // jesli jest 5 -> usun je i zapisz 1 ORT_DISQ
            return "";
        }

        private string updateOrtDisq()
        {
            // odczytaj ile jest ORT_DISQ
            // jesli jest 10 -> usun je i zapisz 1 ORT_BAN
            // wyzeruj licznik postow
            return "";
        }

        private string updateOrtBan()
        {
            // odczytaj ile jest ORT_BAN
            // jesli jest 5 -> usun je i zapisz 1 ORT_DELETE
            // usun usera z bazy danych
            return "";
        }


        public string swears(string msg)
        {
            return "";
        }

        public string emots(string msg)
        {
            return "";
        }
      
        #endregion

        private string getCurrentDateString()
        {
            return DateTime.Now.ToString();
        }
    }
}
