using Codigos.Modelo.Entidades.Generales;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codigos.Modelo.Entidades.Despachos
{
    public class Ticket : EntidadBase
    {
        public string FolioTicket { get; set; }

        public string FolioTicketWMS { get; set; }

        public string? TipoFolio { get; set; }

        public string? Origen { get; set; }

        public long? OrigenId { get; set; }

        public int? TipoOrigen { get; set; }

        public string? Destino { get; set; }

        public long? DestinoId { get; set; }

        public int? TipoDestino { get; set; }

        public long? ClienteId { get; set; }

        public long? TarifaId { get; set; }

        public long? DestinatariosId { get; set; }

        public string? Referencia { get; set; }

        public string? SolicitaServicio { get; set; }

        public DateTime? FechaSolicitud { get; set; }

        /// <summary>
        /// 1 Planeacion 2 Confirmado
        /// </summary>
        public long? TipoSolicitudId { get; set; }

        /// <summary>
        /// 1 Recoleccion 2 Entrega
        /// </summary>    
        public long? TipoEntregaId { get; set; }

        /// <summary>
        /// 1 En cola, 2 Asignado, 3 En ruta, 4 Entregado, 5 No entregado, 6 Transferido
        /// </summary>
        public long? EstatusId { get; set; }

        public string? Comentarios { get; set; }

        public string? TipoRecepcion { get; set; }

        public string? Secuencia { get; set; }

        public DateTime? FechaPromesaLlegadaOrigen { get; set; }

        public DateTime? FechaSalidaEstimada { get; set; }

        public DateTime? FechaPromesaCarga { get; set; }

        public DateTime? FechaPromesaEntrega { get; set; }

        public DateTime? FechaPromesaRetorno { get; set; }

        public TimeSpan? TiempoCarga { get; set; }

        public TimeSpan? TiempoParadaDestino { get; set; }

        public TimeSpan? FechaVentanaInicio { get; set; }

        public TimeSpan? FechaVentanaFin { get; set; }

        public TimeSpan? FechaRestriccionCirculacionInicio { get; set; }

        public TimeSpan? FechaRestriccionCirculacionFin { get; set; }

        public string? OrigenDireccion { get; set; }

        public string? OrigenCP { get; set; }

        public string? OrigenCiudad { get; set; }

        public string? OrigenTelefono { get; set; }

        public string? OrigenContacto { get; set; }

        public string? DestinoDireccion { get; set; }

        public string? DestinoCP { get; set; }

        public string? DestinoCiudad { get; set; }

        public string? DestinoTelefono { get; set; }

        public string? DestinoTelefono2 { get; set; }

        public string? DestinoCorreo { get; set; }

        public string? DestinoContacto { get; set; }

        public string? DestinoArea { get; set; }

        public string? DestinoZona { get; set; }

        public long? TipoEnvioId { get; set; }

        public long? TipoServicioId { get; set; }

        public string? Empaque { get; set; }

        public long? RutaId { get; set; }

        public long? TipoVehiculoId { get; set; }

        public string? HabilidadesVehiculo { get; set; }

        public string? DocumentosVehiculo { get; set; }

        public string? HabilidadesOperador { get; set; }

        public string? DocumentosOperador { get; set; }

        public string? HabilidadesAuxiliar { get; set; }

        public string? DocumentosAuxiliar { get; set; }

        public string? EvidenciaSalida { get; set; }

        public string? EvidenciaLlegada { get; set; }

        public string? CheckList { get; set; }

        public int? Maniobras { get; set; }

        public string? Peligroso { get; set; }

        public string? Custodia { get; set; }

        public string? CustodiaArmada { get; set; }

        public long? TipoCustodiaId { get; set; }

        public long? PrioridadId { get; set; }

        public bool? Prioridad { get; set; }

        public string? RequiereEvidenciaSeguroSocial { get; set; }

        public bool? Seguro { get; set; }

        public bool? ServicioCobro { get; set; }

        public string? ServicioAdicional { get; set; }

        public DateTime? RecepcionTicket { get; set; }

        public DateTime? AsignacionManifiesto { get; set; }

        public DateTime? InicioEscaneoRecepcionProducto { get; set; }

        public DateTime? FinEscaneoRecepcionProducto { get; set; }

        public DateTime? InicioEntregaProducto { get; set; }

        public DateTime? FinEntregaProducto { get; set; }

        public string? Usuario { get; set; }
        //public Cliente? Cliente { get; set; }
        //public Clientes.Destinatario? Destinatarios { get; set; }
        //public Tipo? TipoVehiculo { get; set; }
        //public Ruta? Ruta { get; set; }
        //public TipoCustodia? TipoCustodia { get; set; }
        public long? DestinatariosClienteId { get; set; }

        //Propiedades extras
        public int? Cantidad { get; set; }
        public decimal? SumaAsegurada { get; set; }

        //Propiedades necesarias para SeguroDespacho
        [NotMapped]
        public long? SeguroId { get; set; }
    }
}
