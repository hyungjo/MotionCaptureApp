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
    class DBConnection
    {
        public string DBPath { get; set; }
        public string DBName { get; set; }

        public SQLiteConnection conn;

        public DBConnection(string dbName = "db")
        {
            DBPath = ((App)Application.Current).CurrentPath;
            DBName = dbName + ".db";
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
                ///Field{ INTEGER id; STRING name; STRING explanation}
                string processModelTableCreateQuery = "CREATE TABLE ProcessModel {" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "name TEXT," +
                    "explanation TEXT" +
                    "}";
                command.CommandText = processModelTableCreateQuery;
                command.ExecuteNonQuery();

                string workerModelTableCreateQuery = "CREATE TABLE WorkerModel {" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "name TEXT," +
                    "age INTEGER," +
                    "gender INTEGER," +
                    "height REAL," +
                    "weight REAL" +
                    "}";
                command.CommandText = workerModelTableCreateQuery;
                command.ExecuteNonQuery();
            }

            disconnection();
        }

        public void executeInsertQuery(List<ModelInterface> queryString)
        {
            connection();

            using (SQLiteTransaction tr = conn.BeginTransaction())
            {
                using (SQLiteCommand command = conn.CreateCommand())
                {
                    command.Transaction = tr;

                    foreach (ModelInterface query in queryString)
                    {
                        command.CommandText = query.toInsertQueryString();
                        command.ExecuteNonQuery();
                    }
                }
                tr.Commit();
            }
               
            disconnection();
        }
    }
}
