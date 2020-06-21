using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnFarmCore.Domain;
using OnFarmCore.Repo;
using OnFarmCore.WebApi.Services;


namespace OnFarmCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        public readonly OnFarmContext _context;
        public readonly PedidosService _service;

        public PedidosController(OnFarmContext context)
        {
            _context = context;
            _service = new PedidosService(_context);
        }

        // GET: api/<PedidosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                List<Pedidos> Response = _service.GetAll();
                return Response != null ? Ok(Response) : Ok("Lista de Pedidos vazia.");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // GET api/<PedidosController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Pedidos Response = _service.GetById(id);
                return Response != null ? Ok(Response) : Ok("Pedido não encontrado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex}");
            }
        }

        // POST api/<PedidosController>
        [HttpPost]
        public ActionResult Post(Pedidos Required)
        {
            try
            {
                Required = _service.Include(Required);
                return Ok(Required);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Pedidos Required, int id)
        {
            try
            {
                Pedidos Response = _service.Update(Required, id);
                return (Response != null) ? Ok(Response) : Ok("Pedido não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex}");
            }
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool Response = _service.Delete(id);
                return (Response == true) ? Ok("Pedido foi deletado com Sucesso.") : StatusCode(400, "Pedido não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex}");
            }
        }
    }
}
