using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace semana_3
{
    class conecciomysql
    {
        MySqlConnection cnx = new MySqlConnection("Server=localhost;Database=notas;Uid=root;password=genobreaker66");
        public string Insertbdd(string  sql)
        {
          
            try
            {
                cnx.Open();
                MySqlCommand  com = new MySqlCommand(sql, cnx);
                com.ExecuteNonQuery();
                return "Datos Guardados";

            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                cnx.Close();
            }
        }

        public void guardar(proalm mo)

        {
            try
            {
                string strl = "guardar";
                MySqlCommand cmd = new MySqlCommand(strl, cnx);
                cnx.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pe", mo.pe);
                cmd.Parameters.AddWithValue("po", mo.po);
                cmd.Parameters.AddWithValue("prac", mo.pract);
                cmd.Parameters.AddWithValue("valores", mo.val);
                cmd.Parameters.AddWithValue("prue", mo.prue);
                cmd.Parameters.AddWithValue("nota", mo.nota);
                cmd.Parameters.AddWithValue("resul", mo.resul);
                cmd.Parameters.AddWithValue("lit", mo.lite);
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
            catch(MySqlException ex)
            {
                throw ex;
            }



        }

        }
    }

