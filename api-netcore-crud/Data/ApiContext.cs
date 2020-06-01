using api_netcore_crud.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_netcore_crud.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Provincia> Provincias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Paises
            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasIndex(e => e.NomPais)
                    .HasName("UQ_NomPais")
                    .IsUnique();
                entity.HasIndex(e => e.CodPais)
                    .HasName("UQ_CodPais")
                    .IsUnique();
            });
            #endregion

            #region Provincias
            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasIndex(e => e.NomProv)
                    .HasName("UQ_NomProv")
                    .IsUnique();
                entity.HasIndex(e => e.CodProv)
                    .HasName("UQ_CodProv")
                    .IsUnique();
            });
            #endregion

            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership
                             && (fk.DeleteBehavior == DeleteBehavior.Casca­de
                             || fk.DeleteBehavior == DeleteBehavior.SetNull));
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}