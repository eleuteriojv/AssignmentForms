
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace TrabalhoProgramação
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlCon = null;
        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BancoProva";
        private string strSql = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            strSql = "INSERT INTO Formulario(Nome, Matricula, Curso, Tema, Orientador)" +
                "values(@Nome, @Matricula, @Curso, @Tema, @Orientador)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);
            comando.Parameters.Add("Nome", SqlDbType.NVarChar).Value=NomeTextBox.Text;
            comando.Parameters.Add("Matricula", SqlDbType.NVarChar).Value = MatriculaTextBox.Text;
            comando.Parameters.Add("Curso", SqlDbType.NVarChar).Value = CursoTextBox.Text;
            comando.Parameters.Add("Tema", SqlDbType.NVarChar).Value = TemaTextBox.Text;
            comando.Parameters.Add("Orientador", SqlDbType.NVarChar).Value = OrientadorTextBox.Text;
            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
        }

        
    }
}
