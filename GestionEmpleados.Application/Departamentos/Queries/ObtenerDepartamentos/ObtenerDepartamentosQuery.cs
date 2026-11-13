using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GestionEmpleados.Application.Departamentos.DTOs;
using GestionEmpleados.Application.Interfaces;

namespace GestionEmpleados.Application.Departamentos.Queries.ObtenerDepartamentos
{
    public class ObtenerDepartamentosQuery : IRequest<List<DepartamentoDto>>
    {
    }

    public class ObtenerDepartamentosQueryHandler : IRequestHandler<ObtenerDepartamentosQuery, List<DepartamentoDto>>
    {
        private readonly IApplicationDbContext _context;
        public ObtenerDepartamentosQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartamentoDto>> Handle(ObtenerDepartamentosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Departamentos
                .Select(d => new DepartamentoDto
                {
                    Id = d.Id,
                    Nombre = d.Nombre,
                    Descripcion = d.Descripcion
                })
                .ToListAsync(cancellationToken);
        }
    }
}