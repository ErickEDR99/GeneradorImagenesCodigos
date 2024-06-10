using Codigos.Modelo.Entidades.Colaboradores;
using Codigos.Modelo.Entidades.Componentes;
using Codigos.Modelo.Entidades.Despachos;
using Codigos.Modelo.Entidades.Generales;
using Codigos.Modelo.Entidades.Vehiculos;
using Codigos.Negocio.Negocios.Common;
using Codigos.Negocio.Negocios.Componentes;
using Codigos.Repositorio.Contratos.Common;
using Codigos.Repositorio.Contratos.Componentes;
using Codigos.Repositorio.Repositorios.Common;
using Codigos.Repositorio.Repositorios.Componentes;
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Codigos.Negocio.Negocios
{

    public class GeneradorImagenBusiness : GenericBusiness<ImagenCodigo>
    {
        private List<Respuesta> ListaRespuestas = [];
        /// <summary>
        /// Método para generar imagenes y su respectivo objeto que contendra la información de la imagen generada
        /// </summary>
        /// <param name="despachos"></param>
        /// <param name="tickets"></param>
        /// <param name="vehiculos"></param>
        /// <param name="colaboradores"></param>
        /// <returns></returns>
        public List<Respuesta> CrearImagenesAsync(List<Despacho> despachos, List<Ticket> tickets, List<Vehiculo> vehiculos, List<Colaborador> colaboradores)
        {
            GeneratorCode generatorCode = new();
            //Variables de creación generales:
            DateTime fechaCreacion = DateTime.Now;
            string usuario = "componenteCodigos";
            string rutaGuardado = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ApiURLS")["FileStorage"];

            // Lógica para generar imágenes QR y BC para cada tipo de entidad
            //Despachos:
            foreach (var despacho in despachos)
            {
                string formatoUrlQR = $"/{despacho.FolioDespacho}-QR.png";
                string formatoUrlBC = $"/{despacho.FolioDespacho}-BC.png";
                string rutaCarpeta = $"{rutaGuardado}/Manifiesto/{despacho.FolioDespacho}";
                string rutaGuardadoQR = rutaCarpeta + formatoUrlQR;
                string rutaGuardadoBC = rutaCarpeta + formatoUrlBC;
                // Lógica para generar imagen QR/BC para el despacho
                ImagenCodigo imagenCodigoQR = new ImagenCodigo
                {
                    Tipo = 1, // Define el tipo de imagen
                    Elemento = despacho.FolioDespacho, // Identificador elemento
                    URL = formatoUrlQR, // URL en el server
                    FechaCreacion = fechaCreacion,
                    Usuario = usuario,
                };
                ImagenCodigo imagenCodigoBC = new ImagenCodigo
                {
                    Tipo = 2, // Define el tipo de imagen
                    Elemento = despacho.FolioDespacho, // Identificador elemento
                    URL = formatoUrlBC, // URL en el server
                    FechaCreacion = fechaCreacion,
                    Usuario = usuario,
                };
                List<ImagenCodigo> listaImagenCodigo = [imagenCodigoQR, imagenCodigoBC];

                string qrbase64 = generatorCode.GenerateQR(despacho.FolioDespacho);
                string bcbase64 = generatorCode.GenerateBarcode(despacho.FolioDespacho);
                bool ImagenesCreadasCorrectamente = GuardarImagenesServer(rutaCarpeta, qrbase64, bcbase64, rutaGuardadoQR, rutaGuardadoBC);

                if (ImagenesCreadasCorrectamente)
                {
                    GuardarImagenesTabla(listaImagenCodigo);
                }
            }

            //Tickets
            foreach (var ticket in tickets)
            {
                string formatoUrlQR = $"/{ticket.FolioTicket}-QR.png";
                string formatoUrlBC = $"/{ticket.FolioTicket}-BC.png";
                string rutaCarpeta = $"{rutaGuardado}/Ticket/{ticket.FolioTicket}";
                string rutaGuardadoQR = rutaCarpeta + formatoUrlQR;
                string rutaGuardadoBC = rutaCarpeta + formatoUrlBC;
                // Lógica para generar imagen QR/BC para el despacho
                ImagenCodigo imagenCodigoQR = new ImagenCodigo
                {
                    Tipo = 3, // Define el tipo de imagen
                    Elemento = ticket.FolioTicket, // Identificador elemento
                    URL = formatoUrlQR, // URL en el server
                    FechaCreacion = fechaCreacion,
                    Usuario = usuario,
                };
                ImagenCodigo imagenCodigoBC = new ImagenCodigo
                {
                    Tipo = 4, // Define el tipo de imagen
                    Elemento = ticket.FolioTicket, // Identificador elemento
                    URL = formatoUrlBC, // URL en el server
                    FechaCreacion = fechaCreacion,
                    Usuario = usuario,
                };
                List<ImagenCodigo> listaImagenCodigo = [imagenCodigoQR, imagenCodigoBC];

                string qrbase64 = generatorCode.GenerateQR(ticket.FolioTicket);
                string bcbase64 = generatorCode.GenerateBarcode(ticket.FolioTicket);
                bool ImagenesCreadasCorrectamente = GuardarImagenesServer(rutaCarpeta, qrbase64, bcbase64, rutaGuardadoQR, rutaGuardadoBC);

                if (ImagenesCreadasCorrectamente)
                {
                    GuardarImagenesTabla(listaImagenCodigo);
                }
            }

            //Vehiculo
            foreach (var vehiculo in vehiculos)
            {
                string formatoUrlQR = $"/{vehiculo.Vin}-QR.png";
                string formatoUrlBC = $"/{vehiculo.Vin}-BC.png";
                string rutaCarpeta = $"{rutaGuardado}/Vehiculo/{vehiculo.Vin}";
                string rutaGuardadoQR = rutaCarpeta + formatoUrlQR;
                string rutaGuardadoBC = rutaCarpeta + formatoUrlBC;
                // Lógica para generar imagen QR/BC para el despacho
                ImagenCodigo imagenCodigoQR = new ImagenCodigo
                {
                    Tipo = 5, // Define el tipo de imagen
                    Elemento = vehiculo.Vin, // Identificador elemento
                    URL = formatoUrlQR, // URL en el server
                    FechaCreacion = fechaCreacion,
                    Usuario = usuario,
                };
                ImagenCodigo imagenCodigoBC = new ImagenCodigo
                {
                    Tipo = 6, // Define el tipo de imagen
                    Elemento = vehiculo.Vin, // Identificador elemento
                    URL = formatoUrlBC, // URL en el server
                    FechaCreacion = fechaCreacion,
                    Usuario = usuario,
                };
                List<ImagenCodigo> listaImagenCodigo = [imagenCodigoQR, imagenCodigoBC];

                string qrbase64 = generatorCode.GenerateQR(vehiculo.Vin);
                string bcbase64 = generatorCode.GenerateBarcode(vehiculo.Vin);
                bool ImagenesCreadasCorrectamente = GuardarImagenesServer(rutaCarpeta, qrbase64, bcbase64, rutaGuardadoQR, rutaGuardadoBC);

                if (ImagenesCreadasCorrectamente)
                {
                    GuardarImagenesTabla(listaImagenCodigo);
                }
            }

            //Colaborador
            foreach (var colaborador in colaboradores)
            {
                string formatoUrlQR = $"/{colaborador.Nombre}-QR.png";
                string formatoUrlBC = $"/{colaborador.Nombre}-BC.png";
                string rutaCarpeta = $"{rutaGuardado}/Colaborador/{colaborador.Nombre}";
                string rutaGuardadoQR = rutaCarpeta + formatoUrlQR;
                string rutaGuardadoBC = rutaCarpeta + formatoUrlBC;
                // Lógica para generar imagen QR/BC para el despacho
                ImagenCodigo imagenCodigoQR = new ImagenCodigo
                {
                    Tipo = 7, // Define el tipo de imagen
                    Elemento = colaborador.Nombre, // Identificador elemento
                    URL = formatoUrlQR, // URL en el server
                    FechaCreacion = fechaCreacion,
                    Usuario = usuario,
                };
                ImagenCodigo imagenCodigoBC = new ImagenCodigo
                {
                    Tipo = 8, // Define el tipo de imagen
                    Elemento = colaborador.Nombre, // Identificador elemento
                    URL = formatoUrlBC, // URL en el server
                    FechaCreacion = fechaCreacion,
                    Usuario = usuario,
                };
                List<ImagenCodigo> listaImagenCodigo = [imagenCodigoQR, imagenCodigoBC];

                string qrbase64 = generatorCode.GenerateQR(colaborador.Nombre);
                string bcbase64 = generatorCode.GenerateBarcode(colaborador.Nombre);
                bool ImagenesCreadasCorrectamente = GuardarImagenesServer(rutaCarpeta, qrbase64, bcbase64, rutaGuardadoQR, rutaGuardadoBC);

                if (ImagenesCreadasCorrectamente)
                {
                    GuardarImagenesTabla(listaImagenCodigo);
                }
            }

            ListaRespuestas.Add(new Respuesta
            {
                Status = 200,
                Message = $"Imagenes creadas correctamente",
                Function = "ValidarNotificaciones",
                Data = $"Listas actualizadas de imagenes el {fechaCreacion}"
            });

            return ListaRespuestas;
        }

        public void GuardarImagenesTabla(List<ImagenCodigo> listaImagenesCodigos) {
            IImagenCodigoRepositorio ImagCodRepo = new ImagenCodigoRepositorio();
            IGenericRepository<ImagenCodigo> ImagCodGenericRepo = new GenericRepository<ImagenCodigo>();
            ImagenCodigoBusiness imagenCodigoBusiness = new(ImagCodGenericRepo, ImagCodRepo);
            //Guardar registros en la tabla ImagenesCodigo en DB
            try {
                imagenCodigoBusiness.GuardarRevivirRegistro(listaImagenesCodigos);
            } 
            catch (Exception ex) {
                // Si fallo la creación del registro en la DB
                ListaRespuestas.Add(new Respuesta
                {
                    Status = 400,
                    Message = $"Falló en la creación del registro para el elemento {listaImagenesCodigos.First().Elemento}.",
                    Function = "ValidarNotificaciones",
                    Data = $" Message: {ex.Message}, Data: {ex.Data}"
                });
                // Manejar la excepción (por ejemplo, registrar el error)
                Console.WriteLine($"Error al crear el registro: {ex.Message}");
            }
            
        }

        public bool GuardarImagenesServer(string rutaCarpeta, string? qrbase64, string? bcbase64, string? rutaGuardadoQR, string? rutaGuardadoBC)
        {
            Console.WriteLine("Inicio creación de carpeta");
            try
            {
                // Crear el directorio si no existe
                Directory.CreateDirectory(rutaCarpeta);

                if (!qrbase64.IsNullOrEmpty())
                {
                    Console.WriteLine("Inicio creación de QR");
                    byte[] imageBytesQR = Convert.FromBase64String(qrbase64);
                    using (var ms = new MemoryStream(imageBytesQR))
                    {
                        using (var img = Image.FromStream(ms))
                        {
                            img.Save(rutaGuardadoQR, ImageFormat.Png); // Guarda la imagen como PNG
                        }
                    }
                }

                if (!bcbase64.IsNullOrEmpty())
                {
                    Console.WriteLine("Inicio creación de BC");
                    byte[] imageBytesBC = Convert.FromBase64String(bcbase64);
                    using (var ms = new MemoryStream(imageBytesBC))
                    {
                        using (var img = Image.FromStream(ms))
                        {
                            img.Save(rutaGuardadoBC, ImageFormat.Png); // Guarda la imagen como PNG
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Si fallo la creación del directorio añadiremos el error
                ListaRespuestas.Add(new Respuesta
                {
                    Status = 500,
                    Message = $"Falló en la detección del directorio.",
                    Function = "ValidarImagenesServer",
                    Data = $" Message: {ex.Message}, Data: {ex.Data}"
                });
                // Manejar la excepción (por ejemplo, registrar el error)
                Console.WriteLine($"Error al crear el directorio: {ex.Message}");
                return false;
            }
        }


    }
}
