using Microsoft.EntityFrameworkCore;
using ProjecteBLD.Model;

namespace ProjecteBLD.Data
{
    public class ProjecteCtx : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Map_Info> Maps_Info { get; set; }
        public DbSet<Map_Info_Player> Maps_Info_Player { get; set; }
        
        protected override void OnModelCreating(ModelBuilder mdb)
        {
            mdb.Entity<Map_Info_Player>()
                .HasOne(m => m.mapInfo)
                .WithMany(p => p.players)
                .HasForeignKey(e => e.mapInfoFK);

            mdb.Entity<Map_Info_Player>()
                            .HasOne(p => p.player)
                            .WithMany(m => m.maps)
                            .HasForeignKey(e => e.playerFK);

            mdb.Entity<Map_Info_Player>()
                .HasKey(e => new { e.playerFK, e.mapInfoFK});
            /*
            mdb.Entity<Gestiona>()
            .HasKey(e => new { e.TreballadorFK, e.HotelFK, e.DataInici });

            mdb.Entity<Gestiona>()
                .HasOne(e => e.Hotel)
                .WithMany(g => g.Gestions)
                .HasForeignKey(e => e.HotelFK)
                .OnDelete(DeleteBehavior.Restrict);

            mdb.Entity<Gestiona>()
                .HasOne(e => e.Treballador)
                .WithMany(g => g.Gestions)
                .HasForeignKey(e => e.TreballadorFK);
            

            mdb.Entity<Habitacio>()
                .HasKey(e => new { e.HotelFK, e.Numero });

            mdb.Entity<Reserva>()
                .HasOne(h => h.Habitacio)
                .WithMany(r => r.Reserves)
                .HasForeignKey(p => new { p.HotelFK, p.HabitacioFK });

            mdb.Entity<Reserva>()
                .HasKey(e => new { e.HotelFK, e.HabitacioFK, e.Data });
            */
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "Host=172.24.127.102;Port=5432;Database=ProjecteBLD;Username=postgres;Password=patata";
            optionsBuilder.UseNpgsql(con);
        }
    }
}