using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuanlyNhahang.MA
{
    public class DataProvider
    {

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public DataTable ExcuteQueryGetDataTable(string query, object[] parameter = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connectionSQL = new SqlConnection(Dangnhap.svconnect))
            {
                connectionSQL.Open();

                SqlCommand commandSQL = new SqlCommand(query, connectionSQL);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            commandSQL.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(commandSQL);
                adapter.Fill(dataTable);

                connectionSQL.Close();

            }

            return dataTable;
        }

        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int dataNumberAffected = 0;

            using (SqlConnection connectionSQL = new SqlConnection(Dangnhap.svconnect))
            {
                connectionSQL.Open();

                SqlCommand commandSQL = new SqlCommand(query, connectionSQL);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            commandSQL.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                try
                {
                    dataNumberAffected = commandSQL.ExecuteNonQuery();
                }
                catch
                { }
                connectionSQL.Close();

            }

            return dataNumberAffected;
        }

        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object dataScalar = 0;

            using (SqlConnection connectionSQL = new SqlConnection(Dangnhap.svconnect))
            {
                connectionSQL.Open();

                SqlCommand commandSQL = new SqlCommand(query, connectionSQL);

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            commandSQL.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                dataScalar = commandSQL.ExecuteScalar();

                connectionSQL.Close();

            }

            return dataScalar;
        }
    }
}
