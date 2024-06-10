using Codigos.Modelo.Entidades.Colaboradores;
using Codigos.Modelo.Entidades.Componentes;
using Codigos.Modelo.Entidades.Despachos;
using Codigos.Modelo.Entidades.Generales;
using Codigos.Modelo.Entidades.Vehiculos;
using Codigos.Negocio.Contratos.Despachos;
using Codigos.Negocio.Negocios.Colaboradores;
using Codigos.Negocio.Negocios.Common;
using Codigos.Negocio.Negocios.Componentes;
using Codigos.Negocio.Negocios.Despachos;
using Codigos.Negocio.Negocios.Vehiculos;
using Codigos.Repositorio.Contratos;
using Codigos.Repositorio.Contratos.Colaboradores;
using Codigos.Repositorio.Contratos.Common;
using Codigos.Repositorio.Contratos.Componentes;
using Codigos.Repositorio.Contratos.Despachos;
using Codigos.Repositorio.Contratos.Vehiculos;
using Codigos.Repositorio.Repositorios;
using Codigos.Repositorio.Repositorios.Colaboradores;
using Codigos.Repositorio.Repositorios.Common;
using Codigos.Repositorio.Repositorios.Componentes;
using Codigos.Repositorio.Repositorios.Despachos;
using Codigos.Repositorio.Repositorios.Vehiculos;
using FirebaseAdmin.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Codigos.Negocio.Negocios
{
    public class ValidarNuevosRegistrosBusiness : GenericBusiness<ImagenCodigo>
    {

        /// <summary>
        /// Método para validar si existen nuevos registros creados y si estos necesitan imagenes QR/BC
        /// </summary>
        /// <param name="fechaValidacion"></param>
        /// <returns></returns>
        public async Task<Respuesta> ValidarNuevosRegistros(DateTime fechaValidacion)
        {
            Console.WriteLine("Ejcucion de ValidarNuevosRegistros a las " + fechaValidacion.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
            Respuesta respuesta = new("ValidarNuevosRegistros") { Status = 500, Message = "Error en el servidor" };
            List<Respuesta> AcumulacionRespuestas = [];
            List<Respuesta> AcumulacionRespuestasFallidas = [];

            //Declaración de todos las interfaces necesarias
            GeneradorImagenBusiness generadorImagenBusiness = new GeneradorImagenBusiness();

            IImagenCodigoRepositorio ImagCodRepo = new ImagenCodigoRepositorio();
            IGenericRepository<ImagenCodigo> ImagCodGenericRepo = new GenericRepository<ImagenCodigo>();
            ImagenCodigoBusiness imagenCodigoBusiness = new(ImagCodGenericRepo, ImagCodRepo);

            IDespachoRepositorio DespRepo = new DespachoRepositorio();
            IGenericRepository<Despacho> DespGenericRepo = new GenericRepository<Despacho>();
            DespachoBusiness despachoBusines = new(DespGenericRepo, DespRepo);

            ITicketRepositorio TicketRepo = new TicketRepositorio();
            IGenericRepository<Ticket> TicketGenericRepo = new GenericRepository<Ticket>();
            TicketBusiness ticketBusiness = new(TicketGenericRepo, TicketRepo);

            IVehiculoRepositorio VehRepo = new VehiculoRepositorio();
            IGenericRepository<Vehiculo> VehGenericRepo = new GenericRepository<Vehiculo>();
            VehiculoBusiness vehiculoBusiness = new(VehGenericRepo, VehRepo);

            IColaboradorRepositorio ColabRepo = new ColaboradorRepositorio();
            IGenericRepository<Colaborador> ColabGenericRepo = new GenericRepository<Colaborador>();
            ColaboradorBusiness colaboradorBusiness = new(ColabGenericRepo, ColabRepo);
            //--

            //Realizamos la consulta para obtener las listas
            List<ImagenCodigo> listaImagenCodigo = imagenCodigoBusiness.ObtenerTodosHoy(fechaValidacion);
            List<Despacho> listaDespachos = despachoBusines.ObtenerTodosHoy(fechaValidacion);
            List<Ticket> listaTickets = ticketBusiness.ObtenerTodosHoy(fechaValidacion);
            List<Vehiculo> listaVehiculos = vehiculoBusiness.ObtenerTodosHoy(fechaValidacion);
            List<Colaborador> listaColaboradores = colaboradorBusiness.ObtenerTodosHoy(fechaValidacion);

            //Si existen registros nuevos en alguna lista en la fecha solicitada; Verificaremos si tienen creada sus respectivas imagenes
            // Eliminar los despachos que tienen un FolioDespacho presente en listaImagenes
            listaDespachos.RemoveAll(despacho => listaImagenCodigo.Any(imagen => (imagen.Tipo == 1 || imagen.Tipo == 2) && imagen.Elemento == despacho.FolioDespacho));
            // Eliminar los tickets que tienen un FolioTicket presente en listaImagenes
            listaTickets.RemoveAll(ticket => listaImagenCodigo.Any(imagen => (imagen.Tipo == 3 || imagen.Tipo == 4) && imagen.Elemento == ticket.FolioTicket));
            // Eliminar los despachos que tienen un FolioDespacho presente en listaImagenes
            listaVehiculos.RemoveAll(vehiculo => listaImagenCodigo.Any(imagen => (imagen.Tipo == 5 || imagen.Tipo == 6) && imagen.Elemento == vehiculo.Vin));
            // Eliminar los despachos que tienen un FolioDespacho presente en listaImagenes
            listaColaboradores.RemoveAll(colaborador => listaImagenCodigo.Any(imagen => (imagen.Tipo == 7 || imagen.Tipo == 8) && imagen.Elemento == colaborador.Nombre));

            if (listaDespachos.Count > 0 || listaTickets.Count > 0 || listaVehiculos.Count > 0 || listaColaboradores.Count > 0)
            {
                //Esperamos el recorrido para la creación de las imagenes
                await Task.Run(async () =>
                {
                    List<Respuesta> RespuestasCreacionImagenes = generadorImagenBusiness.CrearImagenesAsync(listaDespachos, listaTickets, listaVehiculos, listaColaboradores);
                    AcumulacionRespuestas = RespuestasCreacionImagenes.Where(x => x.Status == 200).ToList();
                    AcumulacionRespuestasFallidas = RespuestasCreacionImagenes.Where(x => x.Status == 500 || x.Status == 400).ToList();
                });

                if (AcumulacionRespuestasFallidas.Count > 0) {
                    // Se actualiza el estatus de la respuesta y su mensaje
                    respuesta.Status = 500;
                    respuesta.Message = "Proceso ejecutado con fallas.";
                    respuesta.Data = AcumulacionRespuestasFallidas;
                    respuesta.Function = "ValidarNuevosRegistros";
                    respuesta.timeMeasure.Stop();
                }
                else
                {
                    // Se actualiza el estatus de la respuesta y su mensaje
                    respuesta.Status = 200;
                    respuesta.Message = "Proceso ejecutado correctamente.";
                    respuesta.Data = AcumulacionRespuestas;
                    respuesta.Function = "ValidarNuevosRegistros";
                    respuesta.timeMeasure.Stop();
                }

            }
            else
            {
                //Si no hay ningún registro nuevo creado
                respuesta.Status = 200;
                respuesta.Message = "No hay registros nuevos que crear";
                respuesta.Data = null;
                respuesta.timeMeasure.Stop();
            }
            return respuesta;
        }

    }
}
