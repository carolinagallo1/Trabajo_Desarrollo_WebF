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
    public class ClienteController : ControllerBase
    {
        public readonly Context _miBd;
        public ClienteController(Context miBd)
        {
            _miBd = miBd;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {                
                var Lista = _miBd.clientes.ToList();
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
        public IActionResult Add(ClienteViewModel oCliente)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                Cliente cliente = new Cliente();
                cliente.Direccion = oCliente.Direccion;
                cliente.Telefono = oCliente.Telefono;
                cliente.Nombre_Cliente = oCliente.Nombre_Cliente;
                cliente.Email = oCliente.Email;
                cliente.Nro_DNI = oCliente.Nro_DNI;
                cliente.Fecha_Nacimiento = oCliente.Fecha_Nacimiento;
                cliente.Fecha_Inscripcion = oCliente.Fecha_Inscripcion;
                cliente.Tema_Interes = oCliente.Tema_Interes;
                cliente.Estado = oCliente.Estado;
                cliente.Estado = oCliente.Estado;
                _miBd.clientes.Add(cliente);
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
        public IActionResult Update(ClienteViewModel oCliente)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                var cliente = _miBd.clientes.Find(oCliente.Id);
                cliente.Direccion = oCliente.Direccion;
                cliente.Telefono = oCliente.Telefono;
                cliente.Nombre_Cliente = oCliente.Nombre_Cliente;
                cliente.Email = oCliente.Email;
                cliente.Nro_DNI = oCliente.Nro_DNI;
                cliente.Fecha_Nacimiento = oCliente.Fecha_Nacimiento;
                cliente.Fecha_Inscripcion = oCliente.Fecha_Inscripcion;
                cliente.Tema_Interes = oCliente.Tema_Interes;
                cliente.Estado = oCliente.Estado;
                cliente.Estado = oCliente.Estado;
                _miBd.clientes.Update(cliente);
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
                var cliente = _miBd.clientes.Find(Id);
                _miBd.clientes.Remove(cliente);
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
