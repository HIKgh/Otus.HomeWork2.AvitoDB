using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class ProductTypeRepository : Repository<ProductType, int>
{
    public ProductTypeRepository(DbContext context) : base(context)
    {
    }
}