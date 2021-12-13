using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO.entidade
{
   public class Aluno : Pessoa
    {
        public int Matricula { get; set; }
        public int IdCurso { get; set; }
        public int IdPessoa { get; set; }
        public Curso curso { get; set; }
    }
}
