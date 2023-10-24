using System;

namespace Registro_Tickets_Garita
{
    internal class Registro
    {
        public int ID { get; internal set; }
        public int Turno { get; internal set; }
        public DateTime FechaYHora { get; internal set; }
        public string Nombre { get; internal set; }
        public string Apellido { get; internal set; }
        public string NoLicencia { get; internal set; }
        public string Proveedor { get; internal set; }
    }
}