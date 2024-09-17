using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Transaction_System
{
    class db
    {
        private static MySqlConnection connection = new MySqlConnection();
        private static MySqlCommand command = new MySqlCommand();
        private static MySqlDataReader DbReader;
        private static MySqlDataAdapter adapter = new MySqlDataAdapter();
        public MySqlTransaction DbTran;

        private static string strConnString2 = "datasource=localhost;port=3306;username=root;password=;database=tsa";

        //  private static string strConnString = "Data Source=DESKTOP-P1BF4E0\\SQLEXPRESS;Initial Catalog=EESA;Integrated Security=True";

        public static MySqlConnection GetConnection()
        {
            String sql = "datasource=localhost;port=3306;username=root;password=;database=tsa";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL connection" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public void createConn()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString2;
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void closeConn()
        {
            connection.Close();
        }


        public int executeDataAdapter(DataTable tblName, string strSelectSql)
        {
            try
            {
                if (connection.State == 0)
                {
                    createConn();
                }

                adapter.SelectCommand.CommandText = strSelectSql;
                adapter.SelectCommand.CommandType = CommandType.Text;
                MySqlCommandBuilder DbCommandBuilder = new MySqlCommandBuilder(adapter);


                string insert = DbCommandBuilder.GetInsertCommand().CommandText.ToString();
                string update = DbCommandBuilder.GetUpdateCommand().CommandText.ToString();
                string delete = DbCommandBuilder.GetDeleteCommand().CommandText.ToString();


                return adapter.Update(tblName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void readDatathroughAdapter(string query, DataTable tblName)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }

                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                adapter = new MySqlDataAdapter(command);
                adapter.Fill(tblName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public MySqlDataReader readDatathroughReader(string query)
        {
            //DataReader used to sequentially read data from a data source
            MySqlDataReader reader;

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }

                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int executeQuery(MySqlCommand dbCommand)
        {
            try
            {
                if (connection.State == 0)
                {
                    createConn();
                }

                dbCommand.Connection = connection;
                dbCommand.CommandType = CommandType.Text;


                return dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
