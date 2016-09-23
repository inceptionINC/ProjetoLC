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

namespace ControladorDeEstoque
{
    public partial class Form2 : Form
    {
        private MySqlConnection conexao;
        private MySqlCommand comando;

        public Form2()
        {
            InitializeComponent();
        }
           //=====================================================================================================================
        public void CriaTabela()
        {
            try
            {
                conexao = new MySqlConnection("server=85.10.205.73; user id=brunopizol; pwd=1q2w3e4r5t6y; database= projetolc");
                conexao.Open();
                try
                {
                    comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS cadProdutos(nomeF varchar(15),Codf varchar(9),categoria varchar(15),unidade varchar(10), fornecedor varchar(15), dataVal DATE, descricao varchar(40),StatusF integer,tipo varchar(5))", conexao);
                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro no Sql");

                }
                conexao.Close();
            }
            catch
            {
                MessageBox.Show("erro no segundo Catch");

            }

        }
//=======================================================================================================================

        public void Inserir()
        {
            try
            {
                String data = Convert.ToDateTime(maskedBox1.Text).ToString("yyyy-MM-dd");
                conexao = new MySqlConnection("server=85.10.205.73; user id=brunopizol; pwd=1q2w3e4r5t6y; database= projetolc");
                conexao.Open();
                try
                {
                    comando = new MySqlCommand("INSERT INTO cadProdutos(NomeF, CodF, descricao,unidades, StatusF) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+textBox4.Text+"',1)", conexao);
                    MessageBox.Show(comando.CommandText);
                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro no SQL");
                }

            }

            catch (Exception f)
            {
                MessageBox.Show("Erro na conexão");
            }


        }

//=============================================================================================================

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CriaTabela();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
