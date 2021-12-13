using DESAFIO.dal;
using DESAFIO.entidade;
using DESAFIO.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESAFIO
{
    public partial class Form1 : Form
    {
        private Arquivo arquivo;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            arquivo = new Arquivo();
            var ListaAlunos = arquivo.LerArquivo();
            var carga = new Carga();
            carga.FazerCarga(ListaAlunos);

            label2.Text = ListaAlunos.Count.ToString();
            int count = 0;
            foreach (var item in ListaAlunos)
            {
                if (item.curso != null) count++;
            }

            label3.Text = count.ToString();

            DALaluno dALaluno = new DALaluno();
            dataGridView1.DataSource = dALaluno.Consulta();
            MessageBox.Show("Carga realizada com sucesso!");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DALaluno dALaluno = new DALaluno();
            dataGridView1.DataSource = dALaluno.ConsultaAluno();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"delete
  FROM [desafio1].[dbo].[aluno]
 delete
  FROM [desafio1].[dbo].[pessoa]
delete
  FROM [desafio1].[dbo].[cidade]
  delete
  FROM [desafio1].[dbo].[curso] Select 1 ";
           
            db.Executar(sqlCommand);
            MessageBox.Show("Deletado com sucesso!");

        }
    }
}
