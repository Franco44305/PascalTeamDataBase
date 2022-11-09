using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Conexion()
        {
            var conString = ConfigurationManager.ConnectionStrings["dbSql"].ConnectionString;
            try
            {
                using (SqlConnection Conector = new SqlConnection(conString))
                {
                    Conector.Open();
                    DataTable dt = new DataTable();
                    string query = "Select * from Vista_Saldo_Pacientes";
                    SqlCommand comando = new SqlCommand(query, Conector);
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    da.SelectCommand = comando;
                    da.Fill(dt);
                    dataGridView4.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /*private void EjecutarStoredProcedure()
        {
            var conString = ConfigurationManager.ConnectionStrings["dbSql"].ConnectionString;
            try
            {
                using (SqlConnection conector = new SqlConnection(conString))
                {
                    conector.Open();
                    string query = @"AddPaciente";
                    SqlCommand comando = new SqlCommand(query, conector);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Nro_Doc", SqlDbType.Int).Value = int.Parse(txt_Nro_Doc.Text);
                    comando.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = txt_Nombre.Text;
                    comando.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = txt_Direccion.Text;
                    comando.Parameters.Add("@Localidad", SqlDbType.NVarChar).Value = txt_Localidad.Text;
                    comando.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = Int64.Parse(txt_Telefono.Text);
                    comando.Parameters.Add("@Posee_Trabajo", SqlDbType.Bit).Value = true;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Carga correcta");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }*/


        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Conexion();
        }
    }
}
