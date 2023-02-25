using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class ProductRepository : ReadRepository<Product, int>
{
    public ProductRepository(DbContext context) : base(context)
    {
    }
}