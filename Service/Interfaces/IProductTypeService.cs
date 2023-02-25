using Services.Contracts;

namespace Services.Interfaces;

public interface IProductTypeService
{
    int Add(ProductTypeDto dto);

    void Update(int id, ProductTypeDto dto);

    bool Delete(int id);

    ProductTypeDto? Get(int id);
}