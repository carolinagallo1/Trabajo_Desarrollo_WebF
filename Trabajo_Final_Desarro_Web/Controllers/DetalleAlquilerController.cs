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
    public class DetalleAlquilerController : ControllerBase
    {
        public readonly Context _miBd;
        public DetalleAlquilerController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var Lista = _miBd.detalle_Alquilers.Include("CD").Include("Alquiler").ToList();
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
        public IActionResult Add(DetalleAlquilerViewModel oDetalleAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Detalle_Alquiler detalle_Alquiler = new Detalle_Alquiler();
                detalle_Alquiler.CdId = oDetalleAlquiler.CdId;
                detalle_Alquiler.AlquilerId = oDetalleAlquiler.AlquilerId;
                detalle_Alquiler.Dias_Prestamo = oDetalleAlquiler.Dias_Prestamo;
                detalle_Alquiler.Fecha_Devolucion = oDetalleAlquiler.Fecha_Devolucion;
                _miBd.detalle_Alquilers.Add(detalle_Alquiler);
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
        public IActionResult Update(DetalleAlquilerViewModel oDetalleAlquiler)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var detalle_Alquiler = _miBd.detalle_Alquilers.Find(oDetalleAlquiler.Id);
                detalle_Alquiler.CdId = oDetalleAlquiler.CdId;
                detalle_Alquiler.AlquilerId = oDetalleAlquiler.AlquilerId;
                detalle_Alquiler.Dias_Prestamo = oDetalleAlquiler.Dias_Prestamo;
                detalle_Alquiler.Fecha_Devolucion = oDetalleAlquiler.Fecha_Devolucion;
                _miBd.detalle_Alquilers.Update(detalle_Alquiler);
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
                var detalle_Alquiler = _miBd.detalle_Alquilers.Find(Id);
                _miBd.detalle_Alquilers.Remove(detalle_Alquiler);
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
