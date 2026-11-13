using System.Collections.Generic;

namespace GestionEmpleados.Domain.Entities
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }
}