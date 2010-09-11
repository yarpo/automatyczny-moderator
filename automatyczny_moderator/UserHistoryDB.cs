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

        public void ort(string msg, int n)
        {
            while (n-- > 0)
            {
                log(msg);
                updateOrt();
            }
        }

        public void ort(string msg)
        {
            ort(msg, 1);
        }

        private void updateOrt()
        {
            update(ModeratorImpl.ORT_INFO, ModeratorImpl.ORT_WARN, 10);
            update(ModeratorImpl.ORT_WARN, ModeratorImpl.ORT_DISQ, 5);
            update(ModeratorImpl.ORT_DISQ, ModeratorImpl.ORT_BAN, 5);
            update(ModeratorImpl.ORT_BAN, ModeratorImpl.ORT_DEL, 5);
        }

        private int getNumberOfInfos(string info)
        {
            string sql =
                "SELECT count(*) FROM automod_ulog WHERE iduser = " +
                    this.iduser + " AND status = " + ACTIVE +
                    " AND info like('" + info + "')";
            MySqlDataReader data = DatabaseSrc.query(sql);

            return (data.Read()) ? data.GetInt32(0) : 0;
        }

        private void delete(string info)
        {
            string sql =
                "UPDATE " + TABLE + " SET status = " + DELETED +
                " WHERE iduser = " + iduser + " AND info = '" + info +"'" ;
            DatabaseSrc.query(sql);
        }

        /**
         * Pozwala na update ze statusu `currentStatus`, jesli w tabeli 
         * znajduje sie wystarczajaco = `n` wpisow z tym statusem
         * Update polega na dodaniu wpisu o `nextStatus` statusie
         */
        private bool update(string currentStatus, string nextStatus, int n)
        {
            int warnigns = getNumberOfInfos(currentStatus);
            if (warnigns >= n)
            {
                delete(currentStatus); // usun te notki
                log(nextStatus); // dodaj warning
                return true;
            }
            return false;
        }

        public string swears(string msg)
        {
            log(msg);
            updateSwears();
            return "";
        }

        private void updateSwears()
        {
            update(ModeratorImpl.SWEAR_INFO, ModeratorImpl.SWEAR_WARN, 10);
            update(ModeratorImpl.SWEAR_WARN, ModeratorImpl.SWEAR_DISQ, 3);
            update(ModeratorImpl.SWEAR_DISQ, ModeratorImpl.SWEAR_BAN, 3);
            update(ModeratorImpl.SWEAR_BAN, ModeratorImpl.SWEAR_DEL, 2);
        }

        public string emots(string msg)
        {
            log(msg);
            updateEmots();
            return "";
        }

        private void updateEmots()
        {
            update(ModeratorImpl.EMO_INFO, ModeratorImpl.EMO_WARN, 20);
            update(ModeratorImpl.EMO_WARN, ModeratorImpl.EMO_DISQ, 10);
            update(ModeratorImpl.EMO_DISQ, ModeratorImpl.EMO_BAN, 10);
            update(ModeratorImpl.EMO_BAN, ModeratorImpl.EMO_DEL, 10);
        }

        #endregion

        private string getCurrentDateString()
        {
            return DateTime.Now.ToString();
        }
    }
}
