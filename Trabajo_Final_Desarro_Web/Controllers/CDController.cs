using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabajo_Final_Desarro_Web.Models;
using Trabajo_Final_Desarro_Web.Response;
using Trabajo_Final_Desarro_Web.ViewModels;

namespace Trabajo_Final_Desarro_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDController : ControllerBase
    {
        public readonly Context _miBd;
        public CDController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.CDs.ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Datos = Lista;
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(CDViewModel oCd)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                CD Cd = new CD();
                Cd.Condicion = oCd.Condicion;
                Cd.ubicacion = oCd.ubicacion;
                Cd.Estado = oCd.Estado;
                
                _miBd.CDs.Add(Cd);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;
            }

            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Update(CDViewModel oCd)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Cd = _miBd.CDs.Find(oCd.Id);
                Cd.Condicion = oCd.Condicion;
                Cd.ubicacion = oCd.ubicacion;
                Cd.Estado = oCd.Estado;
                _miBd.CDs.Update(Cd);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Cd = _miBd.CDs.Find(Id);
                _miBd.CDs.Remove(Cd);
                _miBd.SaveChanges();
                oRespuesta.Exito = 1;
            }

            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
