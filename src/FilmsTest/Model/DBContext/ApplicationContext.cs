using Microsoft.EntityFrameworkCore;

namespace FilmsTest.Model.DBContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbFileName = "Films.db";

            #region DEBUG
            //string dbPathWin = @"A:\" + dbFileName;
            //optionsBuilder.UseSqlite($"Filename={dbPathWin}");
            #endregion

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmGenre>()
                .HasKey(fg => new { fg.FmID, fg.GenID });

            modelBuilder.Entity<FilmActor>()
                .HasKey(fa => new { fa.FmID, fa.ActID });
        }
    }
}
