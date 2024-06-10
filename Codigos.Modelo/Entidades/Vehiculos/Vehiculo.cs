using Codigos.Modelo.Entidades.Generales;

namespace Codigos.Modelo.Entidades.Vehiculos
{
    public class Vehiculo : EntidadBase
    {
        public string? Placa { get; set; }

        public string? Economico { get; set; }

        public string? Vin { get; set; }

        //public Marca? Marca { get; set; }

        //public Modelo? Modelo { get; set; }

        public int? Anio { get; set; }

        //public TipoCombustible? TipoCombustible { get; set; }

        public int? TanqueCombustible { get; set; }

        public decimal? PesoVehicular { get; set; }

        public decimal? RendimientoUrbano { get; set; }

        public decimal? RendimientoMixto { get; set; }

        public decimal? RendimientoSuburbano { get; set; }

        //public Color? Color { get; set; }

        public int? CapacidadVolumen { get; set; }

        public int? CapacidadVolumenEfectivo { get; set; }

        //public Proveedor? Proveedor { get; set; }

        //public Esquema? Esquema { get; set; }

        public string? Factura { get; set; }

        public string? FacturaCarrocero { get; set; }

        public string? GrupoVehiculo { get; set; }

        //public Proveedor? ProveedorSeguro { get; set; }

        public string? PolizaSeguro { get; set; }

        public DateTime? VigenciaPolizaInicio { get; set; }

        public DateTime? VigenciaPolizaFinal { get; set; }

        //Propiedades añadidas para CartaPorte
        public string? AseguraMedAmbiente { get; set; }

        public string? PolizaMedAmbiente { get; set; }

        // Foreing key con la tabla de Proveedor
        public DateTime? VigenciaPolizaAmbienteInicio { get; set; }

        public DateTime? VigenciaPolizaAmbienteFinal { get; set; }

        public string? TipoPermisoSCT { get; set; }

        public string? NumPermisoSCT { get; set; }

        //public Configuracion? Configuracion { get; set; }

        //public Tipo? Tipo { get; set; }

        public decimal? Prima { get; set; }

        public int? Inciso { get; set; }

        //public Colaborador? Colaborador { get; set; }

        public string? HabilidadVehiculos { get; set; }

        public string? RangoOperacion { get; set; }

        public string? Un { get; set; }

        public int? Maniobras { get; set; }

        public string? Motor { get; set; }

        public decimal? FactorCo2 { get; set; }

        public string? TagCaseta { get; set; }

        public decimal? UltimoOdometro { get; set; }

        // Foreing key con la tabla de Proveedor
        public long? ProveedorSeguroId { get; set; }

        // Foreign key con la tabla de Colaborador
        public long? ColaboradorId { get; set; }

        // Foreing key con la tabla de Configuracion
        public long? ConfiguracionId { get; set; }

        // Foreing key con la tabla de Esquema
        public long? EsquemaId { get; set; }

        // Foreing key con la tabla de Proveedor
        public long? ProveedorId { get; set; }

        // Foreing key con la tabla de Tipo de combustible
        public long? TipoCombustibleId { get; set; }

        // Foreing key con la tabla de Tipo de vehiculo
        public long? TipoId { get; set; }

        // Foreing key con la tabla de Marcas
        public long? MarcaId { get; set; }

        // Foreing key con la tabla de Modelos
        public long? ModeloId { get; set; }

        // Foreing key con la tabla de Colores
        public long? ColorId { get; set; }

        //Propiedades para la app
        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

        public string? Foto { get; set; }

        public string? Usuario { get; set; }

        public bool? Estado { get; set; }
    }
}


