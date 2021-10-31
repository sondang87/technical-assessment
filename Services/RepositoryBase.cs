using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext Context { get; set; }
        //protected ILogger _logger;
        protected IMapper _mapper; 

        public RepositoryBase(DatabaseContext context, IMapper mapper)
        {
            this.Context = context;
            //_logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await this.Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await this.Context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            try
            {
                var entityEntry = await this.Context.Set<T>().AddAsync(entity);
                return entityEntry.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T entity)
        {
            this.Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
        }

        public async Task<T> Single(Expression<Func<T, bool>> expression)
        {
            return await this.Context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public long ExecuteFunction(string seqName)
        {
            var p = new SqlParameter("@result", System.Data.SqlDbType.BigInt);
            p.Direction = System.Data.ParameterDirection.Output;
            Context.Database.ExecuteSqlRaw("set @result = next value for " + seqName, p);
            var nextVal = (long)p.Value;

            return nextVal;
        }
    }
}
