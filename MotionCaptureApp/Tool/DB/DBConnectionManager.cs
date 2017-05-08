using MotionCaptureApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MotionCaptureApp.Tool.DB
{
    public class DBConnectionManager
    {
        private string dbName;
        public string DBPath { get; set; }
        public string DBName { get { return dbName + ".db"; } set { dbName = value; } }

        public SQLiteConnection conn;

        public DBConnectionManager(string dbPath, string dbName = "db")
        {
            DBPath = dbPath;
            DBName = dbName;

            executeInitTable();
        }

        public void connection()
        {
            conn = new SQLiteConnection("Data Source=" + DBPath + "\\" + DBName);
            conn.Open();
        }

        public void disconnection()
        {
            if (conn != null)
                conn.Close();
        }

        public void executeInitTable()
        {
            connection();

            using (SQLiteCommand command = new SQLiteCommand(conn))
            {
                ///Process Table
                ///Field{ INTEGER id; TEXT name; TEXT explanation }
                string processModelTableCreateQuery = "CREATE TABLE ProcessModel (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "name TEXT," +
                    "explanation TEXT" +
                    ")";
                command.CommandText = processModelTableCreateQuery;
                command.ExecuteNonQuery();

                ///Worker Table
                ///Field{ INTEGER id, TEXT name, INTEGER age, INTEGER gender, REAL height, REAL weight }
                string workerModelTableCreateQuery = "CREATE TABLE WorkerModel (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "name TEXT," +
                    "age INTEGER," +
                    "gender INTEGER," +
                    "height REAL," +
                    "weight REAL" +
                    ")";
                command.CommandText = workerModelTableCreateQuery;
                command.ExecuteNonQuery();
            }

            disconnection();
        }

        public void executeInsertQuery(List<ModelInterface> queryString)
        {
            connection();

            using (SQLiteTransaction transaction = conn.BeginTransaction())
            {
                using (SQLiteCommand command = conn.CreateCommand())
                {
                    command.Transaction = transaction;

                    foreach (ModelInterface query in queryString)
                    {
                        command.CommandText = query.toInsertQueryString();
                        command.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
            }
               
            disconnection();
        }
    }
}
