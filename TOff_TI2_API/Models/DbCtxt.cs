
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeOff.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TOff_TI2_API.Models
{
        public class DbCtxt : DbContext
        {

            public virtual DbSet<Categorias> Categorias { get; set; }
            public virtual DbSet<Comentarios> Comentarios { get; set; }
            public virtual DbSet<Filme> Filmes { get; set; }
            public virtual DbSet<Realizador> Realizador { get; set; }
            public virtual DbSet<Utilizador> Utilizador { get; set; }
            public virtual DbSet<Ator> Ators { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

                base.OnModelCreating(modelBuilder);

            }

        }

}