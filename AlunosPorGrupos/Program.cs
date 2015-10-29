using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunosPorGrupos
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            List<Aluno> alunos = new List<Aluno>();
            // inicializando alunos
            
            Console.WriteLine("Quantos alunos deseja adicionar? ");
            int quantiAlunos = int.Parse(Console.ReadLine());

            Console.WriteLine("Quantos grupos serão feitos? ");
            int quantiGrupos = int.Parse(Console.ReadLine());

            for (i = 0; i < quantiAlunos; i++)
            {
                Console.WriteLine("Entre com o nome do aluno: ");
                alunos.Add(new Aluno() { Nome = Console.ReadLine()});
            }
             
            //lista desordenada
            Random rdn = new Random();

            List<Aluno> listaDesorganizada = new List<Aluno>();

            foreach (var item in alunos)
            {
                listaDesorganizada.Add(alunos[rdn.Next(quantiAlunos)]);
            }

            int alunoPorGrupo = quantiAlunos % quantiGrupos;
            
            if (alunoPorGrupo == 0)
            {
                alunoPorGrupo = quantiAlunos / quantiGrupos;
               
            }
            else
                alunoPorGrupo = (quantiAlunos / quantiGrupos) + 1;
            //organizando grupos
            i = 0;
            foreach (var aluno in listaDesorganizada)
            {
                Console.WriteLine("{0} : Grupo {1}", aluno.Nome, (i % alunoPorGrupo)+1);
                i++;
            }
            Console.ReadKey();
        }
    }
}