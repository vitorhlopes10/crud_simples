
using crud_simples.Data;
using crud_simples.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace crud_simples.Services
{
    public class ClienteService
    {
        private readonly CrudSimplesContext _context;

        public ClienteService(CrudSimplesContext context)
        {
            _context = context;
        }

        public void Inserir(Cliente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Atualizar(Cliente obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var obj = _context.cliente.Find(id);
            _context.cliente.Remove(obj);
            _context.SaveChanges();
        }

        public Cliente Buscar(int id)
        {
            var cliente = _context.cliente.Find(id);
            return cliente;
        }

        public IQueryable<Cliente> BuscarTodos()
        {
            var clientes = _context.cliente.AsQueryable();
            return clientes;
        }
    }
}
