using DESAFIO.entidade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO.dal
{
    class DALcidade
    {
        public Cidade InsertCidade(Cidade cidade)
        {
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"INSERT INTO [dbo].[cidade] ([nomecidade]) VALUES  (@nomecidade);SELECT SCOPE_IDENTITY(); ";
            sqlCommand.Parameters.AddWithValue("@nomecidade", cidade.NomeCidade);
            cidade.Id = db.Executar(sqlCommand);
            return cidade;
        }
    }
}
