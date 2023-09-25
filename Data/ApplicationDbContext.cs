using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema_Prontuario.Models;
using System.Security.Cryptography.X509Certificates;

namespace Sistema_Prontuario.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Prontuario> Prontuarios { get; set; }

}
