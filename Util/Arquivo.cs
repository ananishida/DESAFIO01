using DESAFIO.entidade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESAFIO.Util
{
    class Arquivo
    {
        public List<Aluno> LerArquivo()
        {
            List<Aluno> ListaAluno = new List<Aluno>();

            using (StreamReader texto = new StreamReader(@"C:\Users\anani\Desktop\# BOOTCAMP\DESAFIO 01\DESAFIO\desafio1.txt", Encoding.UTF8))
            {
                string mensagem;

                Aluno aluno = null;

                while ((mensagem = texto.ReadLine()) != null)
                {
                    string[] linha = mensagem.Split('-');

                    if (linha[0] == "X")
                    {
                        continue;
                    }
                    else if (linha[0] == "Z")
                    {
                        if (aluno != null)
                        {
                            ListaAluno.Add(aluno);
                        }
                        aluno = new Aluno();
                        aluno.Nome = linha[1];
                        aluno.Telefone = linha[2];
                        aluno.cidade = new Cidade() { NomeCidade = linha[3] };
                        aluno.Rg = linha[4];
                        aluno.Cpf = linha[5];
                    }
                    else if (linha[0] == "Y" && aluno != null)
                    {
                        aluno.Matricula = int.Parse(linha[1]);
                        aluno.curso = new Curso() { NomeCurso = linha[3], Id = int.Parse(linha[2]) };
                        ListaAluno.Add(aluno);
                        aluno = null;
                    }
                }
                if (aluno != null)
                {
                    ListaAluno.Add(aluno);
                    aluno = null;
                }
            }

            return ListaAluno;
        }
    }
}
