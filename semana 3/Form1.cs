using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace semana_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Classuapa uapa = new Classuapa();
                txtnota.Text = uapa.Resulatado(int.Parse(txtpo.Text), int.Parse(txtpe.Text), int.Parse(txtprac.Text), int.Parse(txtvalo.Text), int.Parse(txtprueba.Text));
                txtresul.Text = uapa.Condicion(int.Parse(txtnota.Text));
                txtliteral.Text = uapa.Literal(int.Parse(txtnota.Text));


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=notas;Uid=root;password=genobreaker66");
            try
            {

                string strsql;
                strsql = "insert into calificacion(pe,po,prac,valores,prue,nota,resul,literal)values(@pe,@po,@prac,@valores,@prue,@nota,@resul,@literal)";
                MySqlCommand cmd = new MySqlCommand(strsql, con);
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@pe", txtpe.Text);
                cmd.Parameters.AddWithValue("@po", txtpo.Text);
                cmd.Parameters.AddWithValue("@prac", txtprac.Text);
                cmd.Parameters.AddWithValue("@valores", txtvalo.Text);
                cmd.Parameters.AddWithValue("@prue", txtprueba.Text);
                cmd.Parameters.AddWithValue("@nota", txtnota.Text);
                cmd.Parameters.AddWithValue("@resul", txtresul.Text);
                cmd.Parameters.AddWithValue("@literal", txtliteral.Text);
                cmd.ExecuteNonQuery();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos Guadados");


                }

                else
                {
                    MessageBox.Show("No guardados!");
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                proalm mo = new proalm();
                conecciomysql da = new conecciomysql();
                mo.pe = int.Parse(txtpe.Text);
                mo.po = int.Parse(txtpo.Text);
                mo.pract = int.Parse(txtprac.Text);
                mo.val = int.Parse(txtvalo.Text);
                mo.prue = int.Parse(txtprueba.Text);
                mo.nota = int.Parse(txtnota.Text);
                mo.resul = txtresul.Text;
                mo.lite = txtliteral.Text;
                da.guardar(mo);
                MessageBox.Show("Datos guardados");


               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
