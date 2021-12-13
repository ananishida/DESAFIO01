using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO.entidade
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int  IdCidade { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public Cidade cidade { get; set; }
    }
}
