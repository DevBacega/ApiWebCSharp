using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnFarmCore.Domain;
using OnFarmCore.Repo;
using OnFarmCore.WebApi.Services;

namespace OnFarmCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public readonly OnFarmContext _context;
        public readonly ClientesService _service;
        public ClientesController(OnFarmContext context)
        {
            _context = context;
            _service = new ClientesService(_context);
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult  Get()
        {
            try
            {
                List<Clientes> Response = _service.GetAll();
                return Response != null ?  Ok(Response) :  Ok("Lista de Clientes vazia.");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro:{ex}");
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Clientes Response = _service.GetById(id);
                return Response != null ? Ok(Response) : Ok("Cliente não encontrado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex}");
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post(Clientes Required)
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

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Clientes Required, int id)
        {
            try
            {
               Clientes Response = _service.Update(Required, id);
                return (Response != null) ? Ok(Required) : Ok("Cliente não encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex}");
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool Response = _service.Delete(id);
                return (Response == true) ? Ok("Cliente foi deletado com Sucesso.") : StatusCode(400,"Impossivel de deletar o Cliente, o mesmo contem Pedidos cadastrados! Por favor, delete os pedidos antes de continuar!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:{ex}");
            }
        }

       
    }
}
