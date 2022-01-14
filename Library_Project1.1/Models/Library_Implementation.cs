using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using Library_Project1._1.Models;

namespace Library_Project1._1.Models
{
    public class Library_Implementation
    {
        public List<Library> GetBk()
        {
            List<Library> emplist = new List<Library>();
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from book";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlquery, mysqlconn);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();
            foreach(DataRow dr in dt.Rows)
            {
                emplist.Add(new Library
                {
                    id = Convert.ToInt32(dr["id"]),
                    author = Convert.ToString(dr["author"]),
                    book_name = Convert.ToString(dr["book_name"]),
                    genre = Convert.ToString(dr["genre"]),
                    publish_date = Convert.ToDateTime(dr["publish_date"]),
                    isbn = Convert.ToString(dr["isbn"])
                });
            }

            return emplist;
        }

        public bool insertbk(Library bkinsert)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "insert into book(author,book_name,genre,publish_date,isbn) values ('" +bkinsert.author+ "','" + bkinsert.book_name + "', '" + bkinsert.genre + "', '" + bkinsert.publish_date + "', '" + bkinsert.isbn + "' )";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqlconn.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}