using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class AnnoucementRepository : ReadRepository<Annoucement, int>
{
    public AnnoucementRepository(DbContext context) : base(context)
    {
    }
}