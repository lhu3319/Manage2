using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Modules
{
    class MYsql
    {
        private MySqlConnection conn;
        public bool status;

        /*
        public MySqlConnection Connection()
        {
            string host = "192.168.3.130";
            string user = "root";
            string password = "1234";
            string db = "test";

            string connStr = string.Format("server={0};uid={1};password={2};database={3}", host, user, password, db);
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                Console.WriteLine("성공");
                return conn;
            }
            catch
            {
                conn.Close();
                Console.WriteLine("실패");
                return null;
            }
        }
        */
        public MySqlConnection Connection()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection();
                string path = "/public/DBInfo.json";
                string result = new StreamReader(File.OpenRead(path)).ReadToEnd();
                JObject jo = JsonConvert.DeserializeObject<JObject>(result);
                Hashtable map = new Hashtable();
                foreach (JProperty col in jo.Properties())
                {
                    Console.WriteLine("{0} : {1}", col.Name, col.Value);
                    map.Add(col.Name, col.Value);
                }
                string strConn = string.Format("server={0};user={1};password={2};database={3};", map["server"], map["user"], map["password"], map["database"]);
                //string strConn = string.Format("server={0};user={1};password={2};database={3};", "192.168.3.130","root","1234","test");
                conn.ConnectionString = strConn;
                conn.Open();
                return conn;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public bool ConnectionClose()
        {
            try
            {
                conn.Close();
                //MessageBox.Show("MS-SQL 연결끊기 성공!");
                return true;
            }
            catch
            {
                //MessageBox.Show("MS-SQL 연결끊기 실패!");
                return false;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                if (status)
                {
                    MySqlCommand comm = new MySqlCommand(sql, Connection());
                    comm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {

                MySqlCommand comm = new MySqlCommand(sql, Connection());
                return comm.ExecuteReader();

            }
            catch
            {
                return null;
            }
        }

        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }
    }
}
