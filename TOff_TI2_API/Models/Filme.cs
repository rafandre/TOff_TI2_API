namespace TimeOff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Filme
    {
        public Filme()
        {
            Comentarios = new HashSet<Comentarios>();
            Categorias = new HashSet<Categorias>();
        }
        //chave prim�ria
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Sinopse { get; set; }

        [Required]
        public int AnoLanc { get; set; }

        [Required]
        public string LinkTrailer { get; set; }

        [Required]
        public string ImagensFilme { get; set; }

        //chave estrangeiras presentes na tabela dos filmes
        [ForeignKey("Realizadores")]
        [Display(Name = "Realizador")]
        public int RealizadorId { get; set; }
        public virtual Realizador Realizadores { get; set; }

        // especifica que um filme tem v�rios coment�rios
        public virtual ICollection<Comentarios> Comentarios { get; set; }

        // especifica que um filme tem v�rias Categorias
        public virtual ICollection<Categorias> Categorias { get; set; }

        // especifica que um filme tem v�rios Atores
        public virtual ICollection<Ator> Atores { get; set; }
    }
}
