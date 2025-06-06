using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lego.Logic
{
    internal class LegoUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        private IRepository<LegoColor> _legoColorRepository;
        private IRepository<LegoInventory> _legoInventoryRepository;
        private IRepository<LegoInventoryPart> _legoInventoryPartRepository;
        private IRepository<LegoInventorySet> _legoInventorySetRepository;
        private IRepository<LegoPart> _legoPartRepository;
        private IRepository<LegoPartCategory> _legoPartCategoryRepository;
        private IRepository<LegoSet> _legoSetRepository;
        private IRepository<LegoTheme> _legoThemeRepository;

        private IDbContextTransaction? _transaction;

        public LegoUnitOfWork(DbContext context)
        {
            _context = context;
            _legoColorRepository = new Lego_Repository<LegoColor>(_context);
            _legoInventoryRepository = new Lego_Repository<LegoInventory>(_context);
            _legoInventoryPartRepository = new Lego_Repository<LegoInventoryPart>(_context);
            _legoInventorySetRepository = new Lego_Repository<LegoInventorySet>(_context);
            _legoPartRepository = new Lego_Repository<LegoPart>(_context);
            _legoPartCategoryRepository = new Lego_Repository<LegoPartCategory>(_context);
            _legoSetRepository = new Lego_Repository<LegoSet>(_context);
            _legoThemeRepository = new Lego_Repository<LegoTheme>(_context);

        }

        public IEnumerable<LegoColor> GetLegoColors()
        {
            return _legoColorRepository.GetAll();
        }

        public void AddLegoColor(LegoColor legoColor, bool isTransaction = false)
        {
            _legoColorRepository.Add(legoColor);
            if (!isTransaction)
            {
                SaveChanges();
            }
        }
        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null)
                {
                    _context.SaveChanges();
                    _transaction?.Commit();
                    _transaction?.Dispose();
                    _transaction = null;
                }
            }
            catch (Exception)
            {
                Rollback();
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction?.Rollback();
                _transaction?.Dispose();
                _transaction = null;
            }

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
