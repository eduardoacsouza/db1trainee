using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.ConhecimentoCandidato.Dominio
{
    public class Tecnologia
    {
        public Tecnologia()
        {

        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeTecnologia { get; set; }
        public virtual ICollection<Candidato> Candidatos { get; set; }
    }
}