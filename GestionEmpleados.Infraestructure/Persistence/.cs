using GestionEmpleados.Application.Interfaces;
using GestionEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpleados.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}