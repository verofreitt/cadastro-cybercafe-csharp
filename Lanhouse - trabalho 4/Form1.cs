using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lanhouse___trabalho_4
{
    public partial class CadastroCyberCafe : Form
    {
        public CadastroCyberCafe()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server='localhost';uid='root';pwd='';database='lanhouse'");
            MySqlCommand cmd = new MySqlCommand("update cadastro set nome = ?, username = ?, senha = ?, nascimento = ?, celular = ?, cidade = ?, uf = ?, cep = ?, email = ?, id = ?", cnn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 60).Value = txtNome.Text;
            cmd.Parameters.Add("@username", MySqlDbType.VarChar, 60).Value = txtUser.Text;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar, 60).Value = txtSenha.Text;
            cmd.Parameters.Add("@nascimento", MySqlDbType.VarChar, 60).Value = dateTimePickerNasc.Text;
            cmd.Parameters.Add("@celular", MySqlDbType.VarChar, 60).Value = txtCelular.Text;
            cmd.Parameters.Add("@cidade", MySqlDbType.VarChar, 60).Value = txtCidade.Text;
            cmd.Parameters.Add("@uf", MySqlDbType.VarChar, 60).Value = txtUF.Text;
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar, 60).Value = txtCep.Text;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar, 60).Value = textEmail.Text;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = txtCod.Text;


            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro alterado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return;
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
            }
        }

        private void CadastroCyberCafe_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server='localhost';uid='root';pwd='';database='lanhouse'");
            String comandoInsert = "insert into cadastro(nome,username,senha,nascimento,celular,cidade,uf,cep,email)" +
                " values('" + txtNome.Text + "','" + txtUser.Text + "','" + txtSenha.Text + "','" + dateTimePickerNasc.Text + "'" +
                ",'" + txtCelular.Text + "','" + txtCidade.Text + "','" + txtUF.Text + "','" + txtCep.Text + "'" +
                ",'" + textEmail.Text + "')";
            MySqlCommand cmd = new MySqlCommand(comandoInsert, cnn);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
              MessageBox.Show("Registro salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return;
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server='localhost';uid='root';pwd='';database='lanhouse'");
            String comandoSelect = "select * from cadastro";
            MySqlCommand cmd = new MySqlCommand(comandoSelect, cnn);

            try
            {
                cnn.Open();
                MySqlDataReader mdr = cmd.ExecuteReader();
                DataTable dt = (DataTable)dataGridViewCadastro.DataSource;
                if (dt == null)
                {
                    dt = new DataTable();
                }
                dt.Columns.Add("NOME");
                dt.Columns.Add("USERNAME");
                dt.Columns.Add("SENHA");
                dt.Columns.Add("NASCIMENTO");
                dt.Columns.Add("CELULAR");
                dt.Columns.Add("CIDADE");
                dt.Columns.Add("UF");
                dt.Columns.Add("CEP");
                dt.Columns.Add("EMAIL");
                dt.Columns.Add("ID");
                while (mdr.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = mdr["nome"];
                    dr[1] = mdr["username"];
                    dr[2] = mdr["senha"];
                    dr[3] = mdr["nascimento"];
                    dr[4] = mdr["celular"];
                    dr[5] = mdr["cidade"];
                    dr[6] = mdr["uf"];
                    dr[7] = mdr["cep"];
                    dr[8] = mdr["email"];
                    dr[9] = mdr["id"];
                    dt.Rows.Add(dr);
                }
                dataGridViewCadastro.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return;
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
            }
        }

        private void chartCadastro_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewCadastro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server='localhost';uid='root';pwd='';database='lanhouse'");
            String comandoDelete = "delete from cadastro where nome = '" + txtNome.Text + "'";
            MySqlCommand cmd = new MySqlCommand(comandoDelete, cnn);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastro deletado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return;
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("server='localhost';uid='root';pwd='';database='lanhouse'");
            MySqlCommand cmd = new MySqlCommand("select nome, username, senha, nascimento, celular, cidade, uf, cep, email from cadastro where id = ?", cnn);
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = txtCod.Text;

            try
            {
                cnn.Open();
                cmd.CommandType = CommandType.Text;
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                dr.Read();

                txtNome.Text = dr.GetString(0);
                txtUser.Text = dr.GetString(1);
                txtSenha.Text = dr.GetString(2);
                dateTimePickerNasc.Text = dr.GetString(3);
                txtCelular.Text = dr.GetString(4);
                txtCidade.Text = dr.GetString(5);
                txtUF.Text = dr.GetString(6);
                txtCep.Text = dr.GetString(7);
                textEmail.Text = dr.GetString(8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return;
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
            }
        }
    }
}
    

