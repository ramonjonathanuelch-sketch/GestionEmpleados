using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GestionEmpleados.Application.Interfaces;

namespace GestionEmpleados.Application.Departamentos.Commands.EliminarDepartamento
{
    public class EliminarDepartamentoCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class EliminarDepartamentoCommandHandler : IRequestHandler<EliminarDepartamentoCommand>
    {
        private readonly IApplicationDbContext _context;
        public EliminarDepartamentoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(EliminarDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = await _context.Departamentos.FindAsync(new object[] { request.Id }, cancellationToken);
            if (departamento == null) return;

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}