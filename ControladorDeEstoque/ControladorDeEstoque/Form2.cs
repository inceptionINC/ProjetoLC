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
        public void CriaTabela()
        {
            try
            {
                conexao = new MySqlConnection("server=31.170.160.91; user id=a8477448_admin; pwd=server123; database= a8477448_projeto");
                conexao.Open();
                try
                {
                    comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS cadProdutos(nomeF varchar(15),categoria varchar(15), fornecedor varchar(15), dataVal DATE, descricao varchar(40),StatusF integer)", conexao);
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
