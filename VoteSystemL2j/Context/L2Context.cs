using Microsoft.EntityFrameworkCore;
using VoteSystemL2j.Models;

namespace VoteSystemL2j.Context
{
    public class L2Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppConfigurationManager appDb = new AppConfigurationManager();
            optionsBuilder.UseMySql(string.Format(@"Server={0};Port={1};Database={2};Uid={3};Pwd={4};", appDb.HostDb(), appDb.PortaDb(), appDb.DatabaseDb(), appDb.UserDb(), appDb.SenhaDb()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>();
            modelBuilder.Entity<Character>();
            modelBuilder.Entity<Items>();
            modelBuilder.Entity<VoteSystemTops>();
            modelBuilder.Entity<VoteSystemVotos>();
            modelBuilder.Entity<VoteSystemRewards>();
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<VoteSystemTops> VoteSystemTops { get; set; }
        public DbSet<VoteSystemVotos> VoteSystemVotos { get; set; }
        public DbSet<VoteSystemRewards> VoteSystemRewards { get; set; }
    }
}
