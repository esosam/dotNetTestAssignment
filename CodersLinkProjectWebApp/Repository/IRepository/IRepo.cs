using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersLinkProjectWebApp.Repository.IRepository
{
    public interface IRepo<T> where T : class
    {
        Task<T> GetAsync(string url, int Id);

        Task<IEnumerable<T>> GetAllAsync(string url);

        Task<IEnumerable<T>> GetFilterAsync(string url, string lastname, int? sortby);

        Task<bool> CreateAsync(string url, T objToCreate);

        Task<bool> UpdateAsync(string url, T objToUpdate);

        Task<bool> DeleteAsync(string url, int Id);
    }
}
