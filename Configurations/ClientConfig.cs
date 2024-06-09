using KolokwiumCF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KolokwiumCF.Configurations;

public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.IdClient)
            .HasName("Client_PK");

        builder.Property(c => c.IdClient)
            .UseIdentityColumn();

        builder.Property(c => c.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Phone)
            .HasMaxLength(100);

        builder.HasMany(c => c.Payments)
            .WithOne(p => p.IdClientNav)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Payment_Client_FK");

        builder.HasMany(c => c.Discounts)
            .WithOne(d => d.IdClientNav)
            .HasForeignKey(d => d.IdClient)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Client_Discount_FK");

        builder.HasMany(c => c.Sales)
            .WithOne(s => s.IdClientNav)
            .HasForeignKey(s => s.IdClient)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("Client_Sale_FK");

        var clients = new List<Client>
        {
            new()
            {
                IdClient = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "kowalski@wp.pl",
                Phone = "444333231"
            },
            new()
            {
                IdClient = 2,
                FirstName = "Marek",
                LastName = "Mostowiak",
                Email = "test@mail.com",
                Phone = "123456789"
            },
            new()
            {
                IdClient = 3,
                FirstName = "Piotr",
                LastName = "Łuszcz",
                Email = "test@mail.com",
                Phone = "123456789"
            },
            new()
            {
                IdClient = 4,
                FirstName = "Ferdynand",
                LastName = "Kiepski",
                Email = "test@mail.com",
                Phone = "123456789"
            },
            new()
            {
                IdClient = 5,
                FirstName = "Krzysztof",
                LastName = "Krawczyk",
                Email = "test@mail.com",
                Phone = "123456789"
            },
            new()
            {
                IdClient = 6,
                FirstName = "Arek",
                LastName = "Lowcadrukarek",
                Email = "test@mail.com",
                Phone = "123456789"
            }
        };

        builder.HasData(clients);
    }
}