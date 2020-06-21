using Microsoft.EntityFrameworkCore;
using OnFarmCore.Domain;
using OnFarmCore.Repo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OnFarmCore.WebApi.Services
{
    public class PedidosService
    {
        public readonly OnFarmContext _context;

        public PedidosService(OnFarmContext context)
        {
            _context = context;
        }

        public List<Pedidos> GetAll()
        {
            var pedidos = _context.Pedidos.ToList();
            return pedidos;
        }

        public Pedidos GetById(int id)
        {
            var pedidos = _context.Pedidos.Find(id);
            return pedidos;
        }

        public Pedidos Include(Pedidos pedidos)
        {
            _context.Pedidos.Add(pedidos);
            _context.SaveChanges();
            return pedidos;
        }

        public Pedidos Update(Pedidos pedidos, int id)
        {
            if (_context.Pedidos.AsNoTracking().FirstOrDefault(P => P.IdPedido.Equals(id)) != null)
            {
                pedidos.IdPedido = id;
                _context.Pedidos.Update(pedidos);
                _context.SaveChanges();
            }
            else
            {
                pedidos = null;
            }
            return pedidos;
        }

        public bool Delete(int id)
        {
            Pedidos pedidos = _context.Pedidos.Find(id);
            if (pedidos != null)
            {
                _context.Remove(pedidos);
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
