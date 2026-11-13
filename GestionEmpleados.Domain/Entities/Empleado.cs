namespace GestionEmpleados.Domain.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public decimal Salario { get; set; }
        public int IdDepartamento { get; set; }

        public Departamento Departamento { get; set; }
    }
}