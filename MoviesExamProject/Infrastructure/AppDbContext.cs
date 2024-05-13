using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public partial class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Gender> Genders { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Keyword> Keywords { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<LanguageRole> LanguageRoles { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<MovieCast> MovieCasts { get; set; }

        public virtual DbSet<MovieCompany> MovieCompanies { get; set; }

        public virtual DbSet<MovieCrew> MovieCrews { get; set; }

        public virtual DbSet<MovieGenre> MovieGenres { get; set; }

        public virtual DbSet<MovieKeyword> MovieKeywords { get; set; }

        public virtual DbSet<MovieLanguage> MovieLanguages { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<ProductionCompany> ProductionCompanies { get; set; }

        public virtual DbSet<ProductionCountry> ProductionCountries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql("server=localhost;database=movies;user=root;password=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId).HasName("PRIMARY");

                entity.ToTable("country");

                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CountryIsoCode)
                    .HasMaxLength(10)
                    .HasColumnName("country_iso_code");
                entity.Property(e => e.CountryName)
                    .HasMaxLength(200)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

                entity.ToTable("department");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(200)
                    .HasColumnName("department_name");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenderId).HasName("PRIMARY");

                entity.ToTable("gender");

                entity.Property(e => e.GenderId)
                    .ValueGeneratedNever()
                    .HasColumnName("gender_id");
                entity.Property(e => e.Gender1)
                    .HasMaxLength(20)
                    .HasColumnName("gender");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId).HasName("PRIMARY");

                entity.ToTable("genre");

                entity.Property(e => e.GenreId)
                    .ValueGeneratedNever()
                    .HasColumnName("genre_id");
                entity.Property(e => e.GenreName)
                    .HasMaxLength(100)
                    .HasColumnName("genre_name");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.KeywordId).HasName("PRIMARY");

                entity.ToTable("keyword");

                entity.Property(e => e.KeywordId)
                    .ValueGeneratedNever()
                    .HasColumnName("keyword_id");
                entity.Property(e => e.KeywordName)
                    .HasMaxLength(100)
                    .HasColumnName("keyword_name");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.LanguageId).HasName("PRIMARY");

                entity.ToTable("language");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");
                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(10)
                    .HasColumnName("language_code");
                entity.Property(e => e.LanguageName)
                    .HasMaxLength(500)
                    .HasColumnName("language_name");
            });

            modelBuilder.Entity<LanguageRole>(entity =>
            {
                entity.HasKey(e => e.RoleId).HasName("PRIMARY");

                entity.ToTable("language_role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_id");
                entity.Property(e => e.LanguageRole1)
                    .HasMaxLength(20)
                    .HasColumnName("language_role");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId).HasName("PRIMARY");

                entity.ToTable("movie");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");
                entity.Property(e => e.Budget).HasColumnName("budget");
                entity.Property(e => e.Homepage)
                    .HasMaxLength(1000)
                    .HasColumnName("homepage");
                entity.Property(e => e.MovieStatus)
                    .HasMaxLength(50)
                    .HasColumnName("movie_status");
                entity.Property(e => e.Overview)
                    .HasMaxLength(1000)
                    .HasColumnName("overview");
                entity.Property(e => e.Popularity)
                    .HasPrecision(12, 6)
                    .HasColumnName("popularity");
                entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
                entity.Property(e => e.Revenue).HasColumnName("revenue");
                entity.Property(e => e.Runtime).HasColumnName("runtime");
                entity.Property(e => e.Tagline)
                    .HasMaxLength(1000)
                    .HasColumnName("tagline");
                entity.Property(e => e.Title)
                    .HasMaxLength(1000)
                    .HasColumnName("title");
                entity.Property(e => e.VoteAverage)
                    .HasPrecision(4, 2)
                    .HasColumnName("vote_average");
                entity.Property(e => e.VoteCount).HasColumnName("vote_count");
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("movie_cast");

                entity.HasIndex(e => e.GenderId, "fk_mca_gender");

                entity.HasIndex(e => e.MovieId, "fk_mca_movie");

                entity.HasIndex(e => e.PersonId, "fk_mca_per");

                entity.Property(e => e.CastOrder).HasColumnName("cast_order");
                entity.Property(e => e.CharacterName)
                    .HasMaxLength(400)
                    .HasColumnName("character_name");
                entity.Property(e => e.GenderId).HasColumnName("gender_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_id");
                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Gender).WithMany()
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("fk_mca_gender");

                entity.HasOne(d => d.Movie).WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_mca_movie");

                entity.HasOne(d => d.Person).WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("fk_mca_per");
            });

            modelBuilder.Entity<MovieCompany>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("movie_company");

                entity.HasIndex(e => e.CompanyId, "fk_mc_comp");

                entity.HasIndex(e => e.MovieId, "fk_mc_movie");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Company).WithMany()
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("fk_mc_comp");

                entity.HasOne(d => d.Movie).WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_mc_movie");
            });

            modelBuilder.Entity<MovieCrew>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("movie_crew");

                entity.HasIndex(e => e.DepartmentId, "fk_mcr_dept");

                entity.HasIndex(e => e.MovieId, "fk_mcr_movie");

                entity.HasIndex(e => e.PersonId, "fk_mcr_per");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.Job)
                    .HasMaxLength(200)
                    .HasColumnName("job");
                entity.Property(e => e.MovieId).HasColumnName("movie_id");
                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Department).WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_mcr_dept");

                entity.HasOne(d => d.Movie).WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_mcr_movie");

                entity.HasOne(d => d.Person).WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("fk_mcr_per");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("movie_genres");

                entity.HasIndex(e => e.GenreId, "fk_mg_genre");

                entity.HasIndex(e => e.MovieId, "fk_mg_movie");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Genre).WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("fk_mg_genre");

                entity.HasOne(d => d.Movie).WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_mg_movie");
            });

            modelBuilder.Entity<MovieKeyword>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("movie_keywords");

                entity.HasIndex(e => e.KeywordId, "fk_mk_keyword");

                entity.HasIndex(e => e.MovieId, "fk_mk_movie");

                entity.Property(e => e.KeywordId).HasColumnName("keyword_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Keyword).WithMany()
                    .HasForeignKey(d => d.KeywordId)
                    .HasConstraintName("fk_mk_keyword");

                entity.HasOne(d => d.Movie).WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_mk_movie");
            });

            modelBuilder.Entity<MovieLanguage>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("movie_languages");

                entity.HasIndex(e => e.LanguageId, "fk_ml_lang");

                entity.HasIndex(e => e.MovieId, "fk_ml_movie");

                entity.HasIndex(e => e.LanguageRoleId, "fk_ml_role");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");
                entity.Property(e => e.LanguageRoleId).HasColumnName("language_role_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Language).WithMany()
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_ml_lang");

                entity.HasOne(d => d.LanguageRole).WithMany()
                    .HasForeignKey(d => d.LanguageRoleId)
                    .HasConstraintName("fk_ml_role");

                entity.HasOne(d => d.Movie).WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_ml_movie");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonId).HasName("PRIMARY");

                entity.ToTable("person");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");
                entity.Property(e => e.PersonName)
                    .HasMaxLength(500)
                    .HasColumnName("person_name");
            });

            modelBuilder.Entity<ProductionCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId).HasName("PRIMARY");

                entity.ToTable("production_company");

                entity.Property(e => e.CompanyId)
                    .ValueGeneratedNever()
                    .HasColumnName("company_id");
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .HasColumnName("company_name");
            });

            modelBuilder.Entity<ProductionCountry>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("production_country");

                entity.HasIndex(e => e.CountryId, "fk_pc_country");

                entity.HasIndex(e => e.MovieId, "fk_pc_movie");

                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Country).WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("fk_pc_country");

                entity.HasOne(d => d.Movie).WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_pc_movie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
