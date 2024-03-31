using AutoMapper;
using MongoDB.Driver;
using Shofy.Catalog.Dtos.CategoryDtos;
using Shofy.Catalog.Dtos.ProductDtos;
using Shofy.Catalog.Entities;
using Shofy.Catalog.Settings;

namespace Shofy.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        readonly IMongoCollection<Product> _productCollection;
        readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task AddProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            var results = _mapper.Map<List<ResultProductDto>>(values);
            return results;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            var result = _mapper.Map<GetByIdProductDto>(value);
            return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId == updateProductDto.ProductId,values);
        }
    }
}
