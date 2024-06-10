using Codigos.Modelo.Entidades.Generales;

namespace Codigos.Modelo.Entidades.Despachos {
    public class Despacho : EntidadBase
    {
        public string FolioDespacho { get; set; }

        public bool? Borrador { get; set; }

        public bool? Express { get; set; }

        public string? Origen { get; set; }

        public long? OrigenId { get; set; }

        public int? TipoOrigen { get; set; }

        public string? Destino { get; set; }

        public long? DestinoId { get; set; }

        public int? TipoDestino { get; set; }

        public long? VehiculoId { get; set; }

        public string? VehiculoTercero { get; set; }

        public long? RemolqueId { get; set; }

        public long? OperadorId { get; set; }

        public bool? Custodia { get; set; }

        public string? Auxiliares { get; set; }

        public bool? Peligroso { get; set; }

        public long? RutaId { get; set; }

        public string? ServiciosAdicionales { get; set; }

        public long? AndenId { get; set; }

        public long? EstatusId { get; set; }

        public string? Usuario { get; set; }

        public string? OcupacionEfectiva { get; set; }

        public string? TiempoEntrega { get; set; }

        public string? Validador { get; set; }

        public int? EncuestaOperadorPickup { get; set; }

        public int? OperadorPickupId { get; set; }

        public long? UsuarioAutorizacionId { get; set; }

        public string? UsuarioAutorizacion { get; set; }
    }
}