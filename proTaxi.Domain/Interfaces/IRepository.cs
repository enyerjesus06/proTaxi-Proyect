using proTaxi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace proTaxi.Domain.Interfaces
{
    public interface IRepository<TEntity, TType> where TEntity : class
    {
        /// <summary>
        /// Save Entity
        /// </summary>
        /// <param name="entity"></param>
        Task<bool> Save(TEntity entity);

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity"></param>
        Task<bool> Update(TEntity entity);

        /// <summary>
        /// Remove Entity
        /// </summary>
        /// <param name="entity"></param>
        Task<bool> Remove(TEntity entity);

        /// <summary>
        /// Remove Entity
        /// </summary>
        Task<List<TEntity>>  GetAll();

        /// <summary>
        /// Find Entity by Id
        /// </summary>
        /// <param name="Id"></param>
        Task<DataResult<TEntity>> GetEntityBy(TType Id);

        /// <summary>
        /// Exists Entity
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns></returns>

        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
        
        


        

        
    }
}
