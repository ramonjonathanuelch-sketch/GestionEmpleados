using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GestionEmpleados.Application.Interfaces;
using GestionEmpleados.Domain.Entities;

namespace GestionEmpleados.Application.Departamentos.Commands.CrearDepartamento
{
    public class CrearDepartamentoCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class CrearDepartamentoCommandHandler : IRequestHandler<CrearDepartamentoCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CrearDepartamentoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CrearDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = new Departamento
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion
            };

            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync(cancellationToken);
            return departamento.Id;
        }
    }
}