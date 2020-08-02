using AutoMapper;
using Core.IRepository;
using Core.UnitOfWork;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task UpdateLocalUrl()
        {
            var products = await _productRepository.GetAsync().ConfigureAwait(true);
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Content/PDF"));
            foreach (var product in products)
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), $"Content/PDF", product.Id.ToString()));
                product.LocalUrl = $"{product.ProductName}.pdf";
                _productRepository.Edit(product);
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileAsync(
                        new Uri(product.Url),
                         Path.Combine(Directory.GetCurrentDirectory(), "Content/PDF", product.Id.ToString(), $"{product.ProductName}.pdf")
                    );
                }
            }
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
        }
    }
}
