using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class SellerRepository : ReadRepository<Seller, int>
{
    public SellerRepository(DbContext context) : base(context)
    {
    }
}