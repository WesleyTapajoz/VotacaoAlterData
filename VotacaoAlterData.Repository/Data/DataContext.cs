using VotacaoAlterData.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VotacaoAlterData.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;

namespace VotacaoAlterData.Repository.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<ItemRecurso> ItemRecursos { get; set; }
        public DbSet<Voto> Votos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserRole>(x =>
            {
                x.HasKey(ur => new { ur.UserId, ur.RoleId });

                x.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                x.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            }
              );


            modelBuilder.Entity<ItemRecurso>(x =>
            {
                x.HasKey(em => new { em.ItemRecursoId });

                x.HasOne(ur => ur.Recurso)
                    .WithMany(r => r.ItensRecurso)
                    .HasForeignKey(ur => ur.RecursoId)
                    .IsRequired();
            });

            modelBuilder.Entity<Voto>(x =>
            {
                x.HasKey(em => new { em.VotoId });

                x.HasOne(ur => ur.ItemRecurso)
                    .WithMany(r => r.Votos)
                    .HasForeignKey(ur => ur.ItemRecursoId)
                    .IsRequired();
            });


            modelBuilder.Entity<RecursoUser>()
              .HasKey(x => new { x.RecursoId, x.Id });

            modelBuilder.Seed();

        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DataCadastro").IsModified = false;
                    }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}