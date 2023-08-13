namespace Microservicios.Domain
{
    public class Proveedores
    {
        public Guid Id_proveedor { get; set; }
        public string? Rfc { get; set; }
        public string? Razon_Social { get; set; }
        public string? Nombre_Contacto { get; set; }
        public string? Tel_Principal { get; set; }
        public string? Tel_Movil { get; set; }
        public string? E_mail { get; set; }
        public string? Estatus { get; set; }
        public DateTime? Fecha_Registro { get; set; }
    }
}
