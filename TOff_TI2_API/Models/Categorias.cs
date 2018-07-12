namespace TimeOff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Categorias
    {
        public Categorias()
        {
            Filmes = new HashSet<Filme>();
        }
        //chave prim�ria
        [Key]
        public int Id { get; set; }

        //Nome da categoria obrigat�ria 
        [Required]
        public string Nome { get; set; }

        // especifica que uma Categoria tem v�rios Filmes
        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
