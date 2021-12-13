using DESAFIO.entidade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO.dal
{
   public class DALcurso
    {
        public Curso InsertCurso (Curso curso)
        {
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"INSERT INTO [dbo].[curso] ([id] ,[nomecurso]) VALUES (@id,@nomecurso);SELECT id from [dbo].[curso] where id = @iid;";
            sqlCommand.Parameters.AddWithValue("@id", curso.Id);
            sqlCommand.Parameters.AddWithValue("@iid", curso.Id);
            sqlCommand.Parameters.AddWithValue("@nomecurso", curso.NomeCurso);
            db.Executar(sqlCommand);

            return curso;
        }
    }
}
