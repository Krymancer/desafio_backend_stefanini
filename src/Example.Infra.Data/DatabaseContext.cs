using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Crud.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<Domain.CityAggregate.City> City { get; set; }
        public DbSet<Domain.PersonAggregate.Person> Person { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.Entity<Domain.CityAggregate.City>();
            modelBuilder.Entity<Domain.PersonAggregate.Person>();

        }
    }

    public class CityEntityTypeConfiguration : IEntityTypeConfiguration<Domain.CityAggregate.City>
    {
        public void Configure(EntityTypeBuilder<Domain.CityAggregate.City> orderConfiguration)
        {
            orderConfiguration.ToTable("City", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).ValueGeneratedOnAdd();
            orderConfiguration.Property(o => o.Name).IsRequired();
            orderConfiguration.Property(o => o.UF).IsRequired();
        }
    }

    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Domain.PersonAggregate.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.PersonAggregate.Person> orderConfiguration)
        {
            orderConfiguration.ToTable("Person", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).ValueGeneratedOnAdd();
            orderConfiguration.Property(o => o.Name).IsRequired();
            orderConfiguration.Property(o => o.Age).IsRequired();
            orderConfiguration.Property(o => o.CPF).IsRequired();

            orderConfiguration.HasOne(o => o.City).WithMany(x=> x.Persons).HasForeignKey(o => o.CityId);
        }
    }
}
