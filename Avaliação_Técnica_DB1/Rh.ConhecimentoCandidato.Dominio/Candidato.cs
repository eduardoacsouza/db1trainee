using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.ConhecimentoCandidato.Dominio
{
    public class Candidato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Candidato")]
        [StringLength(50,ErrorMessage = "O nome deve conter entre 5 e 50 caracteres"),MinLength(5)]
        public string NomeCandidato { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        [Display(Name = "Número de contato principal")]
        public int Telefone1 { get; set; }
        [Display(Name = "Número de contato secundário")]
        public int Telefone2 { get; set; }
        public string LinkedInURL { get; set; }
        public string FacebookURL { get; set; }

        // ForeignKey
        public virtual ICollection<Tecnologia> Tecnologias { get; set; }
        public int VagaId { get; set; }
        public virtual Vaga Vagas { get; set; }

        public string Detalhes { get; set; }
        [Display(Name = "Pontuação")]
        public int Pontuacao { get; set; }
    }
}