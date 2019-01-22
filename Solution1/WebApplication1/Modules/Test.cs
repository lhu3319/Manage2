using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Modules
{
    public class Test
    {
        public int nNo { set; get; }
        public int mNo { set; get; }
        public string nTitle { set; get; }
        public string nContents { set; get; }


    }
    public static class Query
    {
        public static ArrayList Getinsert(Test test) //입력
        {
            MYsql my = new MYsql();
            string sql = string.Format("insert into Notice (mNo,nTitle,nContents) values ({0},'{1}','{2}');", test.mNo, test.nTitle, test.nContents);
            if (my.NonQuery(sql)) return Getselect();
            else return new ArrayList();
        }

        public static ArrayList Getselect() // 출력
        {
            MYsql my = new MYsql();
            string sql = "select * from Member";
            MySqlDataReader sdr = my.Reader(sql);
            ArrayList list = new ArrayList();

            while (sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));
                    //result += string.Format("{0} : {1} ", sdr.GetName(i), sdr.GetValue(i));
                }
                // result += "\n";
                list.Add(ht);
            }
            return list;
        }

        public static ArrayList Getupdate(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("update Notice set  mNo = '{1}', nTtitle = '{2}', nContents = '{3}' where nNo='{0}';", test.nNo, test.mNo, test.nTitle, test.nContents);
            if (my.NonQuery(sql)) return Getselect();
            else return new ArrayList();
        }
        public static ArrayList Getdelete(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("update Notice set delYn = 'Y' where nNo = {0}", test.nNo);
            if (my.NonQuery(sql)) return Getselect();
            else return new ArrayList();
        }
    }
}
