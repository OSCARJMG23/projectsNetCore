using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWorf, IDisposable
    {
        private readonly TiendaContext context;
        private PaisRepository _paises;
        public UnitOfWork(TiendaContext _context)
        {
            context = _context;
        }
        public IPaisInterface Paises
        {
            get{
                if(_paises == null){
                    _paises = new PaisRepository(context);
                }
                return _paises;
            }
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public async Task<int>SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}