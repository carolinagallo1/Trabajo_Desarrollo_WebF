using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabajo_Final_Desarro_Web.Response;
using Trabajo_Final_Desarro_Web.ViewModels;
using Trabajo_Final_Desarro_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabajo_Final_Desarro_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SancionController : ControllerBase
    {
        public readonly Context _miBd;
        public SancionController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.sancions.Include("Alquiler").ToList();
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
        public IActionResult Add(SancionViewModel oSancion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Sancion sancion = new Sancion();
                sancion.AlquilerId = oSancion.AlquilerId;
                sancion.Tipo_Sancion = oSancion.Tipo_Sancion;
                sancion.Nro_Dias_Sancion = oSancion.Nro_Dias_Sancion;
                
                _miBd.sancions.Add(sancion);
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
        public IActionResult Update(SancionViewModel oSancion)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var sancion = _miBd.sancions.Find(oSancion.Id);
                sancion.AlquilerId = oSancion.AlquilerId;
                sancion.Tipo_Sancion = oSancion.Tipo_Sancion;                
                sancion.Nro_Dias_Sancion = oSancion.Nro_Dias_Sancion;
                _miBd.sancions.Update(sancion);
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
                var sancion = _miBd.sancions.Find(Id);
                _miBd.sancions.Remove(sancion);
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
