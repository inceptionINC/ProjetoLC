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
                    comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS cadProdutos(nomeF varchar(15),Codf varchar(9),categoria varchar(15),unidade varchar(10), fornecedor varchar(15), dataVal DATE, descricao varchar(40),StatusF integer,tipo varchar(5),CodBarras varchar(256),EstMax varchar(10),EstMin varchar(10))", conexao);
                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro no Sql1");

                }
                conexao.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("erro no segundo Catch1");

            }

        }
        //=======================================================================================================================

        public void Inserir()
        {
            try
            {
                String data = Convert.ToDateTime(maskedTextBox1.Text).ToString("yyyy-MM-dd");
                conexao = new MySqlConnection("server=85.10.205.73; user id=brunopizol; pwd=1q2w3e4r5t6y; database= projetolc");
                conexao.Open();
                try
                {
                    comando = new MySqlCommand("INSERT INTO cadProdutos(NomeF, CodF, descricao,unidades,categoria,dataVal,peso, tipo,fornecedor,EstMin, EstMax,CodBarras, StatusF) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+comboBox2.Text+"','"+data+"','"+textBox5.Text+"','"+comboBox3.Text+"','"+comboBox1.Text+"','"+ numericUpDown1.Text+"','"+ numericUpDown2.Text+"','"+textBox8.Text+"',1)", conexao);
                    //MessageBox.Show(comando.CommandText);
                    MessageBox.Show("Produtos cadastrados com sucesso!");
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
            Inserir();
        }
    }
}
