using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GestionEmpleados.Application.Interfaces;

namespace GestionEmpleados.Application.Departamentos.Commands.ActualizarDepartamento
{
    public class ActualizarDepartamentoCommand : IRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class ActualizarDepartamentoCommandHandler : IRequestHandler<ActualizarDepartamentoCommand>
    {
        private readonly IApplicationDbContext _context;
        public ActualizarDepartamentoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ActualizarDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = await _context.Departamentos.FindAsync(new object[] { request.Id }, cancellationToken);
            if (departamento == null) return;

            departamento.Nombre = request.Nombre;
            departamento.Descripcion = request.Descripcion;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}