using VotacaoAlterData.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace VotacaoAlterData.Repository
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public Task<T[]> GetAllAsync<T>() where T : class
        {
            return _context.Set<T>().ToArrayAsync();
        }

        public async Task<T> GetById<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        //public async Task<Emprestimo[]> GetAllEmprestimoByLivroIdAsync(int livroId)
        //{
        //    return await _context.Emprestimos.Where(x => x.LivroId == livroId && x.DataEntrega == null).ToArrayAsync();
        //}

    }
}
