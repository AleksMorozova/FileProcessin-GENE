using FileSystemSearch.Model;
using System.Data.Entity;

namespace FileSystemSearch.DAL
{
    public class StatisticContext : DbContext
    {
        public StatisticContext() : base("name=RedaxStatisticConnection")
        {

        }

        public DbSet<SagaAction> Sagas { get; set; }
        public DbSet<Selector> Selectors { get; set; }
    }
}
