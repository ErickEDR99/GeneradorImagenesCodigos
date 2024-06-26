﻿using Codigos.Modelo.Entidades.Generales;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdministracionSGD.Services.Api.Controllers.Common
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public abstract class BaseApiController : Controller
    {
        private InfoUsuario CurrentUser { get; set; }


        internal long UserId
        {
            get
            {
                var current = CurrentUser;
                return current.UsuarioId;
            }
        }

        internal long EmployeeId
        {
            get
            {
                var current = CurrentUser;
                return Convert.ToInt64(current.EmpleadoId);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected Respuesta Ok(Delegate f, params object[] args)
        {
            var methodName = new System.Diagnostics.StackTrace(1, false).GetFrame(0)!.GetMethod()!.Name;
            Respuesta respuesta = new Respuesta(methodName);

            try
            {
                var result = f.DynamicInvoke(args);

                if (result != null && !result.GetType().IsPrimitive && result.GetType() != typeof(string))
                    respuesta.Data = JsonConvert.SerializeObject(result);
                else
                    respuesta.Data = result ?? new object();
            }
            catch (Exception ex)
            {
                respuesta.Exception(ex.InnerException != null ? ex.InnerException : ex);
            }
            finally
            {
                respuesta.timeMeasure.Stop();
            }
            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected Respuesta Paginated(Delegate f, params object[] args)
        {
            var methodName = new System.Diagnostics.StackTrace(1, false).GetFrame(0)!.GetMethod()!.Name;
            Respuesta respuesta = new Respuesta(methodName); try
            {
                int TotalRows = 0;
                object[] args2 = new object[args.Length + 1];
                for (int element = 0; element < args.Length; element++)
                    args2[element] = args[element];
                args2[args2.Length - 1] = TotalRows; var result = f.DynamicInvoke(args2); respuesta.PageIndex = (int)args2[0];
                respuesta.PageSize = (int)args2[1];
                respuesta.TotalRows = (int)args2[args2.Length - 1]; if (result != null && !result.GetType().IsPrimitive && result.GetType() != typeof(string))
                    respuesta.Data = JsonConvert.SerializeObject(result);
                else
                    respuesta.Data = result ?? new object();
            }
            catch (Exception ex)
            {
                respuesta.Exception(ex.InnerException != null ? ex.InnerException : ex);
            }
            finally
            {
                respuesta.timeMeasure.Stop();
            }
            return respuesta;
        }
    }
}
