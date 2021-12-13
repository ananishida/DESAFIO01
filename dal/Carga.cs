using DESAFIO.entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO.dal
{
    public class Carga
    {
        public void FazerCarga (List<Aluno> alunos)
        {
            foreach (var item in alunos)
            {
                if (item.curso != null)
                {
                    var dalcurso = new DALcurso();
                    dalcurso.InsertCurso(item.curso);
                    item.IdCurso = item.curso.Id;
                }

                var dalcidade = new DALcidade();
                dalcidade.InsertCidade(item.cidade);

                item.IdCidade = item.cidade.Id;
                

                var dalaluno = new DALaluno();
                dalaluno.InsertAluno(item);
            }
        }
    }
}
