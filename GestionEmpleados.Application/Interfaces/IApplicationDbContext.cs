using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using GestionEmpleados.Domain.Entities;

namespace GestionEmpleados.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Departamento> Departamentos { get; set; }
        DbSet<Empleado> Empleados { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}