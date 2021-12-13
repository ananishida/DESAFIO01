using DESAFIO.entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO.dal
{
    public class DALaluno
    {
        public Aluno InsertAluno (Aluno aluno)
        {
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"INSERT INTO [dbo].[pessoa] ([nome] ,[telefone] ,[idcidade] ,[rg] ,[cpf]) VALUES (@nome, @telefone, @idcidade, @rg, @cpf);SELECT SCOPE_IDENTITY();";
            sqlCommand.Parameters.AddWithValue("@nome", aluno.Nome);
            sqlCommand.Parameters.AddWithValue("@telefone", aluno.Telefone);
            sqlCommand.Parameters.AddWithValue("@idcidade", aluno.IdCidade);
            sqlCommand.Parameters.AddWithValue("@rg", aluno.Rg);
            sqlCommand.Parameters.AddWithValue("@cpf", aluno.Cpf);
            aluno.Id = db.Executar(sqlCommand);

            if(aluno.curso != null)
            {
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = @"INSERT INTO [dbo].[aluno]([matricula],[idcurso],[idpessoa]) VALUES (@matricula, @idcurso, @idpessoa);select 1";
                sqlCommand.Parameters.AddWithValue("@matricula", aluno.Matricula);
                sqlCommand.Parameters.AddWithValue("@idcurso", aluno.IdCurso);
                sqlCommand.Parameters.AddWithValue("@idpessoa", aluno.Id);
                db.Executar(sqlCommand);
            }
            return aluno;
        }

        public DataTable Consulta()
        {
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select nome, nomecurso from pessoa inner join aluno on idpessoa = id inner join curso as c on idcurso = c.id ";
            return db.Consulta(sqlCommand);
        }
        public DataTable ConsultaAluno()
        {
            var db = new BandoDados();
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"Select *from pessoa as p left join aluno as a on a.idpessoa = p.id left join curso as c on a.idcurso = c.id left join cidade as cid on p.idcidade = cid.id";
            return db.Consulta(sqlCommand);
        }
    }
}
