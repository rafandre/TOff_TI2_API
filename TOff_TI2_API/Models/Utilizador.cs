namespace TimeOff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class Utilizador
    {
        public Utilizador()
        {
            Comentarios = new HashSet<Comentarios>();
        }
        //chave prim�ria
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} � de preenchimento obrigat�rio!")]
        [RegularExpression("[A-Z����][a-z�����������������������]+(( |'|-| dos | da | de | e | d')[A-Z����][a-z�����������������������]+){1,3}",
           ErrorMessage = "O {0} apenas pode conter letras e espa�os em branco. Cada palavra come�a em Mai�scula, seguida de min�sculas...")]
        public string NomeCompleto { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode =true)]//formata a data para aparecer Ano/M�s/Dia
        public DateTime DataNasc { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sexo { get; set; }

        public string ImagemUtilizador { get; set; }

        // especifica que um Utilizador pode fazer v�rios Coment�rios
        public virtual ICollection<Comentarios> Comentarios { get; set; }
    }
}
