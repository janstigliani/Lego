using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lego.Logic
{
    internal class LegoUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public LegoUnitOfWork(DbContext context)
        {
           _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
