using GeekShopping.Api.Data.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVo>> FindAll();
        Task<ProductVo> FindById(long id);
        Task<ProductVo> Create(ProductVo vo);
        Task<ProductVo> Update(ProductVo vo);
        Task<bool> Delete(long id);
    }
}
