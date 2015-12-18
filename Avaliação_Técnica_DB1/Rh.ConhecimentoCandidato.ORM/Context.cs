using Rh.ConhecimentoCandidato.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.ConhecimentoCandidato.ORM
{
    public class Context : DbContext
    {
        /// <summary>
        /// Método Construtor do Context
        /// </summary>
        public Context() : base ("Rh_ConhecimentoCandidato")
        {

        }

        /// <summary>
        /// Informações do banco de dados
        /// </summary>
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
    }
}
