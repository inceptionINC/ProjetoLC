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
                conexao = new MySqlConnection("server=85.10.205.173; user id=brunopizol; pwd=1q2w3e4r5t6y; database= projetolc");
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
