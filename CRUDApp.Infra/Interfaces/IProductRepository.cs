using CRUDApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Infra.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Getall();

        Task<Product> GetById(int id);
        Task add(Product model);
        Task update(Product model); 

        Task delete(int id);
    }
}
