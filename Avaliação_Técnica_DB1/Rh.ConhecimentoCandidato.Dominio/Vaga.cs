using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.ConhecimentoCandidato.Dominio
{
    public class Vaga
    {
        public Vaga()
        {

        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome da Vaga")]
        [StringLength(50, ErrorMessage = "O nome deve conter entre 2 e 50 caracteres"), MinLength(2)]
        public string NomeVaga { get; set; }

        public virtual ICollection<Candidato> Candidatos { get; set; }
    }
}