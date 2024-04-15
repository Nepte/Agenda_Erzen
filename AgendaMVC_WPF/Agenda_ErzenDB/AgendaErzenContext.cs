using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AgendaMVC_WPF.Modèle;

namespace AgendaMVC_WPF.Agenda_ErzenDB;

public partial class AgendaErzenContext : DbContext
{
    BDD_Manager bDD_Manager;

    public AgendaErzenContext()
    {
        bDD_Manager = new BDD_Manager();
    }

    public AgendaErzenContext(DbContextOptions<AgendaErzenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ProfilSocial> ProfilSocials { get; set; }

    public virtual DbSet<ReseauxSociaux> ReseauxSociauxes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Tach> Taches { get; set; }

    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseMySql(bDD_Manager.connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse(bDD_Manager.mysqlVer));
        }


    }


        //=> optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda_erzen", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contacts");

            entity.HasIndex(e => e.StatusId, "fk_Contacts_Status1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adresse).HasMaxLength(45);
            entity.Property(e => e.DateOfBirth).HasMaxLength(45);
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Phone).HasMaxLength(45);
            entity.Property(e => e.Prenom).HasMaxLength(45);
            entity.Property(e => e.Sexe).HasColumnType("enum('Homme','Femme')");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
            entity.Property(e => e.Ville).HasMaxLength(45);

            entity.HasOne(d => d.Status).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contacts_Status1");
        });

        modelBuilder.Entity<ProfilSocial>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ContactsId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("profil_social");

            entity.HasIndex(e => e.ContactsId, "fk_Profil_social_Contacts1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ContactsId).HasColumnName("Contacts_ID");
            entity.Property(e => e.Lien).HasMaxLength(45);
            entity.Property(e => e.Nom).HasMaxLength(45);

            entity.HasOne(d => d.Contacts).WithMany(p => p.ProfilSocials)
                .HasForeignKey(d => d.ContactsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Profil_social_Contacts1");
        });

        modelBuilder.Entity<ReseauxSociaux>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ProfilSocialId, e.ProfilSocialContactsId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("reseaux_sociaux");

            entity.HasIndex(e => new { e.ProfilSocialId, e.ProfilSocialContactsId }, "fk_Reseaux_sociaux_Profil_social1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ProfilSocialId).HasColumnName("Profil_social_ID");
            entity.Property(e => e.ProfilSocialContactsId).HasColumnName("Profil_social_Contacts_ID");
            entity.Property(e => e.Lien).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(45);

            entity.HasOne(d => d.ProfilSocial).WithMany(p => p.ReseauxSociauxes)
                .HasForeignKey(d => new { d.ProfilSocialId, d.ProfilSocialContactsId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Reseaux_sociaux_Profil_social1");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Status1)
                .HasMaxLength(45)
                .HasColumnName("Status");
        });

        modelBuilder.Entity<Tach>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ToDoListId, e.ToDoListContactsId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("taches");

            entity.HasIndex(e => new { e.ToDoListId, e.ToDoListContactsId }, "fk_Tâches_To-Do_List1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ToDoListId).HasColumnName("To-Do_List_ID");
            entity.Property(e => e.ToDoListContactsId).HasColumnName("To-Do_List_Contacts_ID");
            entity.Property(e => e.Check).HasMaxLength(45);
            entity.Property(e => e.Nom).HasMaxLength(45);
            entity.Property(e => e.Tips).HasMaxLength(45);

            entity.HasOne(d => d.ToDoList).WithMany(p => p.Taches)
                .HasForeignKey(d => new { d.ToDoListId, d.ToDoListContactsId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tâches_To-Do_List1");
        });

        modelBuilder.Entity<ToDoList>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ContactsId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("to-do_list");

            entity.HasIndex(e => e.ContactsId, "fk_To-Do_List_Contacts1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ContactsId).HasColumnName("Contacts_ID");
            entity.Property(e => e.Date).HasMaxLength(45);
            entity.Property(e => e.DateFin)
                .HasMaxLength(45)
                .HasColumnName("Date_fin");
            entity.Property(e => e.Description).HasMaxLength(45);
            entity.Property(e => e.Titre).HasMaxLength(45);

            entity.HasOne(d => d.Contacts).WithMany(p => p.ToDoLists)
                .HasForeignKey(d => d.ContactsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_To-Do_List_Contacts1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
