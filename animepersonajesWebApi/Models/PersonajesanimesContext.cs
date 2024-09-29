using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace animepersonajesWebApi.Models;

public partial class PersonajesanimesContext : DbContext
{
    public PersonajesanimesContext()
    {
    }

    public PersonajesanimesContext(DbContextOptions<PersonajesanimesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anime> Animes { get; set; }

    public virtual DbSet<Personaje> Personajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=animeDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anime>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Anime1)
                .HasMaxLength(100)
                .HasColumnName("Anime");
        });

        modelBuilder.Entity<Personaje>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Edad).HasMaxLength(10);
            entity.Property(e => e.Genero).HasMaxLength(10);
            entity.Property(e => e.IdAnime).HasColumnName("Id_Anime");
            entity.Property(e => e.Localizacion).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Ocupacion).HasMaxLength(100);

            entity.HasOne(d => d.IdAnimeNavigation).WithMany(p => p.Personajes)
                .HasForeignKey(d => d.IdAnime)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personajes_Animes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
