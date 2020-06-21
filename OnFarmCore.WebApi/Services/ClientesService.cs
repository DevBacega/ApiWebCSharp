using Microsoft.EntityFrameworkCore;
using OnFarmCore.Domain;
using OnFarmCore.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnFarmCore.WebApi.Services
{
    public class ClientesService
    {
        public readonly OnFarmContext _context;
        public ClientesService(OnFarmContext context)
        {
            _context = context;
        }

        public List<Clientes> GetAll()
        {
            var clientes = _context.Clientes.ToList();

            clientes.ForEach(cli =>
            {
                var pedidos = _context.Pedidos.Where(p => p.IdCliente == cli.IdCliente).ToList();
                pedidos.ForEach(p => { cli.Pedidos.Add(p); });
            });

            return clientes;
        }

        public Clientes GetById(int id)
        {
            var cliente = _context.Clientes.Find(id);
            var pedidos = _context.Pedidos
                                  .Where(p => p.IdCliente == cliente.IdCliente)
                                  .ToList();

            pedidos.ForEach(p => {cliente.Pedidos.Add(p);});

            return cliente;
        }

        public Clientes Include(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Clientes Update(Clientes cliente, int id)
        {
            if (_context.Clientes.AsNoTracking().FirstOrDefault(C => C.IdCliente.Equals(id)) != null)
            {
                cliente.IdCliente = id;
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
            }
            else
            {
                cliente = null;
            }
            return cliente;
        }

        public bool Delete(int id)
        {
            Clientes cliente = _context.Clientes.Find(id);
            if ( cliente != null)
            {
                _context.Remove(cliente);
                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
