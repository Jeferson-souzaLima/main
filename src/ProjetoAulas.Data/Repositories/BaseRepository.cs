using Microsoft.EntityFrameworkCore;
using ProjetoAulas.Business.Interfaces;
using ProjetoAulas.Business.Models;
using ProjetoAulas.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace ProjetoAulas.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(AppDbContext db) 
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            Db.Add(entity);
            await SaveChanges();
        }

        public async Task Alterar(TEntity entity)
        {
            Db.Update(entity);
            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            Db.Remove(new TEntity { Id = id});
            await SaveChanges();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking() .Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

    }
}
